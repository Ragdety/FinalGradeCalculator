using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalGradeCalculator.Data.Models;
using FinalGradeCalculator.Services;
using FinalGradeCalculator.Web.CourseRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinalGradeCalculator.Web.Controllers
{
    [Route("/api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;
        private readonly ICourseService _courseService;

        public CourseController(ILogger<CourseController> logger, ICourseService courseService)
        {
            _logger = logger;
            _courseService = courseService;
        }

        [HttpGet("/api/courses")]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _courseService.GetAllCourses();
            if (courses.Count == 0)
                return NotFound("No courses found");

            return Ok(courses);
        }

        [HttpGet("/api/courses/{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            var course = await _courseService.GetCourse(id);

            if (course == null)
                return NotFound($"No course found with id {id}");

            return Ok(course);
        }

        [HttpPost("/api/courses/")]
        public async Task<IActionResult> PostCourse([FromBody] NewCourseRequest courseRequest)
        {
            var now = DateTime.UtcNow;
            var course = new Course
            {
                Name = courseRequest.Name,
                Instructor = courseRequest.Instructor,
                FinalGrade = null,
                GradedItems = courseRequest.GradeItems,
                CreatedOn = now,
                UpdatedOn = now
            };

            await _courseService.AddCourse(course);
            return Ok($"Course added: {course.Name}");
        }
    }
}
