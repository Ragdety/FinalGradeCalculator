using FinalGradeCalculator.Data;
using FinalGradeCalculator.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalGradeCalculator.Services
{
    public class CourseService : ICourseService
    {
        private readonly FinalGradeCalculatorDbContext _db;
        public CourseService(FinalGradeCalculatorDbContext db)
        {
            _db = db;
        }

        public async Task AddCourse(Course course)
        {
            if (course.GradedItems.Count != 0)
            {
                foreach (GradedItem gradedItem in course.GradedItems)
                {
                    //To Update the GradedItems DB table as well
                    await _db.GradedItems.AddAsync(gradedItem);
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
                    _db.GradedItems.Remove(gradedItem);
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
            IList<Course> coursesFromDb = await _db.Courses.ToListAsync();
            
            foreach (var course in coursesFromDb)
            {
                IQueryable<GradedItem> gradedItems = _db.GradedItems.Where(a => a.CourseId == course.Id);
                course.GradedItems = await gradedItems.ToListAsync();
            }

            return coursesFromDb;
        }

        public async Task<Course> GetCourse(int courseId)
        {
            var course = await _db.Courses.FindAsync(courseId);

            if (course == null)
                return null;

            IList<GradedItem> gradedItems = await
                _db.GradedItems.Where(a => a.CourseId == courseId).ToListAsync();

            course.GradedItems = gradedItems;
            return course;
        }
    }
}
