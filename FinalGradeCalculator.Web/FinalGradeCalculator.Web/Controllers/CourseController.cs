using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalGradeCalculator.Data.Models;
using FinalGradeCalculator.Services;
using FinalGradeCalculator.Data.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace FinalGradeCalculator.Web.Controllers
{
    [Route("/api/courses")]
    [ApiController]
    //[EnableCors("AllowOrigin")]
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
        public async Task<IActionResult> PostCourse([FromBody] JObject objData)
        {
            var now = DateTime.UtcNow;

            ICollection<GradedItemDto> gradedItemsLstRequest = new List<GradedItemDto>();
            dynamic course = objData;
            JArray gradedItemsJson = course.GradedItems;

            if(gradedItemsJson != null)
            {
                foreach (var gradedItem in gradedItemsJson)
                {
                    gradedItemsLstRequest.Add(gradedItem.ToObject<GradedItemDto>());
                }
            }
            ICollection<GradedItem> gradedItems = new List<GradedItem>();

            foreach (var gradedItem in gradedItemsLstRequest)
            {
                var gradedItemModel = new GradedItem
                {
                    Name = gradedItem.Name,
                    Grade = gradedItem.Grade,
                    CreatedOn = now,
                    UpdatedOn = now
                };

                gradedItems.Add(gradedItemModel);
            }

            var courseToAdd = new Course
            {
                Name = course.Name,
                Instructor = course.Instructor,
                FinalGrade = null,
                GradedItems = gradedItems,
                CreatedOn = now,
                UpdatedOn = now
            };

            await _courseService.AddCourse(courseToAdd);
            return Ok($"Course added: {courseToAdd.Name}");
        }

        [HttpDelete("/api/courses/{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            try
            {
                await _courseService.DeleteCourse(id);
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok($"Course deleted with id: {id}");
        }

        [HttpPut("/api/courses/{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseDto courseRequest)
        {
            try
            {
                await _courseService.UpdateCourse(id, courseRequest);
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok($"Course Updated with id: {id}");
        }
    }
}
