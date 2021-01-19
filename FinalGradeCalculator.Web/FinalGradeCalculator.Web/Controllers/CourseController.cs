using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalGradeCalculator.Data.Models;
using FinalGradeCalculator.Services;
using FinalGradeCalculator.Data.Requests;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using AutoMapper;

namespace FinalGradeCalculator.Web.Controllers
{
    [Route("/api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseController(
            ILogger<CourseController> logger, 
            ICourseService courseService, 
            IMapper mapper)
        {
            _logger = logger;
            _courseService = courseService;
            _mapper = mapper;
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
        public async Task<IActionResult> PostCourse([FromBody] CourseRequest courseRequest)
        {
            var now = DateTime.UtcNow;
            var courseToAdd = new Course
            {
                Name = courseRequest.Name,
                Instructor = courseRequest.Instructor,
                FinalGrade = null,
                GradedItems = null,
                CreatedOn = now,
                UpdatedOn = now
            };

            await _courseService.AddCourse(courseToAdd);
            return Ok($"Course added: {courseToAdd.Name}");


            /*In method before: [FromBody] JObject objData ^^^*/

            //ICollection<GradedItemRequest> gradedItemsLstRequest = new List<GradedItemRequest>();
            //dynamic course = objData;
            //JArray gradedItemsJson = course.GradedItems;

            //if(gradedItemsJson != null)
            //{
            //    foreach (var gradedItem in gradedItemsJson)
            //    {
            //        gradedItemsLstRequest.Add(gradedItem.ToObject<GradedItemRequest>());
            //    }
            //}
            //ICollection<GradedItem> gradedItems = new List<GradedItem>();

            //foreach (var gradedItem in gradedItemsLstRequest)
            //{
            //    var gradedItemModel = new GradedItem
            //    {
            //        Name = gradedItem.Name,
            //        Grade = gradedItem.Grade,
            //        CreatedOn = now,
            //        UpdatedOn = now
            //    };

            //    gradedItems.Add(gradedItemModel);
            //}
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
                return NotFound(ex.Message);
            }
            return Ok($"Course deleted with id: {id}");
        }

        [HttpPut("/api/courses/{id}")]
        public async Task<IActionResult> UpdateCourse(
            [FromRoute] int id, 
            [FromBody] CourseRequest courseRequest)
        {
            var now = DateTime.UtcNow;
            var course = await _courseService.GetCourse(id);

            if(course == null)
                return NotFound($"No course found with id: {id}");

            course.Name = courseRequest.Name;
            course.Instructor = courseRequest.Instructor;
            course.UpdatedOn = now;

            var updated = await _courseService.UpdateCourse(course);

            if (updated)
                return Ok($"Course Updated with id: {id}");

            return NotFound($"No course found with id: ${id}");           
        }
    }
}
