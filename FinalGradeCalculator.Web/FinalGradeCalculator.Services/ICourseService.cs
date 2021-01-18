using FinalGradeCalculator.Data.Models;
using FinalGradeCalculator.Data.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalGradeCalculator.Services
{
    public interface ICourseService
    {
        Task<IList<Course>> GetAllCourses();
        Task<Course> GetCourse(int courseId);
        Task AddCourse(Course course);
        Task DeleteCourse(int courseId);
        Task UpdateCourse(int courseToUpdateId, CourseDto courseRequest);
    }
}