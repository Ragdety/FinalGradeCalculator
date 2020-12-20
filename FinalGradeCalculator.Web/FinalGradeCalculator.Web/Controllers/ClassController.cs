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
    public class ClassController : ControllerBase
    {
        private readonly ILogger<ClassController> _logger;

        public ClassController(ILogger<ClassController> logger)
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
