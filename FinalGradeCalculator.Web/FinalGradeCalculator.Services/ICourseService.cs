using FinalGradeCalculator.Data.Models;
using FinalGradeCalculator.Data.Requests;
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
        Task UpdateCourse(int courseToUpdateId, UpdateCourseRequest courseRequest);
    }
}