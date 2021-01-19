using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAllGradedItemsFromCourse(int courseId)
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
    }
}
