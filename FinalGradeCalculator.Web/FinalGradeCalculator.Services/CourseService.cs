using FinalGradeCalculator.Data;
using FinalGradeCalculator.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            await _db.AddAsync(course);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteCourse(int courseId)
        {
            var courseToDelete = await _db.Courses.FindAsync(courseId);
            if(courseToDelete != null)
            {
                _db.Remove(courseToDelete);
                await _db.SaveChangesAsync();
            }

            throw new InvalidOperationException(
                "Cannot delete course that doesn't exist");
        }

        public async Task<IList<Course>> GetAllCourses()
        {
            return await _db.Courses.ToListAsync();
        }

        public async Task<Course> GetCourse(int courseId)
        {
            var course = await _db.Courses.FindAsync(courseId);
            return course;
        }
    }
}
