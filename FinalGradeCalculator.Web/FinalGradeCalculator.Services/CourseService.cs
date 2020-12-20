using FinalGradeCalculator.Data;
using FinalGradeCalculator.Data.Models;
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

        public Task AddCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Course>> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetCourse(int courseId)
        {
            throw new NotImplementedException();
        }
    }
}
