using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalGradeCalculator.Data.Models;
using FinalGradeCalculator.Services;
using FinalGradeCalculator.Web.CourseRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

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
        public async Task<IActionResult> PostCourse([FromBody] JObject objData)
        {
            var now = DateTime.UtcNow;

            ICollection<NewGradedItemRequest> gradedItemsLstRequest = new List<NewGradedItemRequest>();
            dynamic course = objData;
            JArray gradedItemsJson = course.GradedItems;

            foreach (var gradedItem in gradedItemsJson)
            {
                gradedItemsLstRequest.Add(gradedItem.ToObject<NewGradedItemRequest>());
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
                FinalGrade = 100,
                GradedItems = gradedItems,
                CreatedOn = now,
                UpdatedOn = now
            };

            await _courseService.AddCourse(courseToAdd);
            return Ok($"Course added: {courseToAdd.Name}");
        }

        //[HttpPost("/api/courses/")]
        //public async Task<IActionResult> PostCourse([FromBody] NewCourseRequest courseRequest)
        //{
        //    courseRequest.GradeItems = new List<GradedItem>();



        //    var now = DateTime.UtcNow;
        //    var course = new Course
        //    {
        //        Name = courseRequest.Name,
        //        Instructor = courseRequest.Instructor,
        //        FinalGrade = null,
        //        GradedItems = courseRequest.GradeItems,
        //        CreatedOn = now,
        //        UpdatedOn = now
        //    };

        //    await _courseService.AddCourse(course);
        //    return Ok($"Course added: {course.Name}");
        //}

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
    }
}
