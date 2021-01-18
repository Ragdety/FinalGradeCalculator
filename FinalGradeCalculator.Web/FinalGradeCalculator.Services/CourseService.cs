using FinalGradeCalculator.Data;
using FinalGradeCalculator.Data.Models;
using FinalGradeCalculator.Data.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalGradeCalculator.Services
{
    public class CourseService : ICourseService
    {
        private readonly FinalGradeCalculatorDbContext _db;
        private readonly IGradedItemService _gradedItemService;
        public CourseService(FinalGradeCalculatorDbContext db, IGradedItemService gradedItemService)
        {
            _db = db;
            _gradedItemService = gradedItemService;
        }

        public async Task AddCourse(Course course)
        {
            if (course.GradedItems.Count != 0)
            {
                foreach (GradedItem gradedItem in course.GradedItems)
                {
                    await _gradedItemService.AddGradedItem(gradedItem);
                }
            }
            await _db.Courses.AddAsync(course);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteCourse(int courseId)
        {
            var courseToDelete = await GetCourse(courseId);
            if(courseToDelete != null)
            {
                foreach (var gradedItem in courseToDelete.GradedItems)
                {
                    await _gradedItemService.DeleteGradedItem(gradedItem.Id);
                }

                _db.Courses.Remove(courseToDelete);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException(
                    "Cannot delete course that doesn't exist");
            }
        }

        public async Task<IList<Course>> GetAllCourses()
        {
            return await _db.Courses
                .Include(g => g.GradedItems)
                .ToListAsync();
        }

        public async Task<Course> GetCourse(int courseId)
        {
            var course = await _db.Courses.FindAsync(courseId);

            if (course == null)
                return null;

            IList<GradedItem> gradedItems = 
                await _gradedItemService.GetAllGradedItemsFromCourse(courseId);

            course.GradedItems = gradedItems;
            return course;
        }

        public async Task UpdateCourse(int courseToUpdateId, CourseRequest courseRequest)
        {
            var now = DateTime.UtcNow;
            var course = await GetCourse(courseToUpdateId);

            if (course == null)
                throw new InvalidOperationException("Course does not exist");

            course.Name = courseRequest.Name;
            course.Instructor = courseRequest.Instructor;
            course.UpdatedOn = now;
            await _db.SaveChangesAsync();
        }
    }
}