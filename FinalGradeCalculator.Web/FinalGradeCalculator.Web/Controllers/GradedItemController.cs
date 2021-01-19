using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalGradeCalculator.Data.Models;
using FinalGradeCalculator.Data.Requests;
using FinalGradeCalculator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalGradeCalculator.Web.Controllers
{
    [Route("/api/gradedItems")]
    [ApiController]
    public class GradedItemController : ControllerBase
    {
        private readonly IGradedItemService _gradedItemService;

        public GradedItemController(IGradedItemService gradedItemService)
        {
            _gradedItemService = gradedItemService;
        }

        [HttpGet("/api/gradedItems/{courseId}")]
        public async Task<IActionResult> GetAllGradedItemsFromCourse([FromRoute] int courseId)
        {
            try
            {
                var gradedItems = await _gradedItemService.GetAllGradedItemsFromCourse(courseId);

                if (gradedItems == null)
                    return NotFound($"No graded items found for course with id: {courseId}");

                return Ok(gradedItems);
            }
            catch(InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("/api/gradedItems/{courseId}/{gradedItemId}")]
        public async Task<IActionResult> GetGradedItemFromCourse(
            [FromRoute] int courseId, 
            [FromRoute] int gradedItemId)
        {
            try
            {
                var gradedItem = await _gradedItemService.GetGradedItemFromCourse(courseId, gradedItemId);

                if (gradedItem == null)
                    return NotFound($"No graded item found for course with id: {courseId}");

                return Ok(gradedItem);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("/api/gradedItems/{courseId}")]
        public async Task<IActionResult> AddGradedItem(
            [FromRoute] int courseId, 
            [FromBody] GradedItemRequest gradedItemRequest)
        {
            var now = DateTime.UtcNow;
            var gradedItem = new GradedItem
            {
                Name = gradedItemRequest.Name,
                Grade = gradedItemRequest.Grade,
                CreatedOn = now,
                UpdatedOn = now,
                CourseId = courseId
            };

            try
            {
                await _gradedItemService.AddGradedItemToCourse(courseId, gradedItem);
                return Ok($"Graded Item added to course with id: {courseId}");
            }
            catch(InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("/api/gradedItems/{courseId}/{gradedItemId}")]
        public async Task<IActionResult> DeleteGradedItemFromCourse(
            [FromRoute] int courseId, 
            [FromRoute] int gradedItemId)
        {
            try
            {
                await _gradedItemService.DeleteGradedItemFromCourse(courseId, gradedItemId);
                return Ok($"Graded Item deleted from course with id: {courseId}");
            }
            catch(InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("/api/gradedItems/{courseId}/{gradedItemId}")]
        public async Task<IActionResult> UpdateGradedItemFromCourse(
            [FromRoute] int courseId, 
            [FromRoute] int gradedItemId,
            [FromBody] GradedItemRequest gradedItemRequest)
        {
            var now = DateTime.UtcNow;

            try
            {
                var gradedItemToUpdate = 
                    await _gradedItemService.GetGradedItemFromCourse(courseId, gradedItemId);

                if (gradedItemToUpdate == null)
                    return NotFound($"Graded Item with Id: {gradedItemId} does not exist");

                gradedItemToUpdate.Name = gradedItemRequest.Name;
                gradedItemToUpdate.Grade = gradedItemRequest.Grade;
                gradedItemToUpdate.UpdatedOn = now;

                await _gradedItemService.UpdateGradedItemFromCourse(courseId, gradedItemToUpdate);
                return Ok($"Graded Item with id: {gradedItemId} updated");
            }
            catch(InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}