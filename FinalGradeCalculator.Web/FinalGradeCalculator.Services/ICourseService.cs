using FinalGradeCalculator.Data.Models;
using System.Collections.Generic;

namespace FinalGradeCalculator.Services
{
    public interface ICourseService
    {
        IList<Course> GetAllCourses();
        Course GetCourse(int courseId);
        void AddCourse(Course course);
        void DeleteCourse(int courseId);
    }
}