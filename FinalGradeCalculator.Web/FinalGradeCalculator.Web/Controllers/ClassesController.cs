using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinalGradeCalculator.Web.Controllers
{
    [Route("/api/classes")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly ILogger<ClassesController> _logger;

        public ClassesController(ILogger<ClassesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetGrades()
        {
            return Ok("Grades!");
        }
    }
}
