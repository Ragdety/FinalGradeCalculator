using FinalGradeCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalGradeCalculator.Data.Dtos
{
    public class CourseDto
    {
        public string Name { get; set; }
        public string Instructor { get; set; }
        public ICollection<GradedItemDto> GradeItems { get; set; }
    }
}
