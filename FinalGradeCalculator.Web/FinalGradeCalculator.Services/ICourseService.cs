using FinalGradeCalculator.Data.Models;
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
    }
}