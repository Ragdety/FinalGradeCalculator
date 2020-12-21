using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalGradeCalculator.Services;
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
    }
}
