using FinalGradeCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalGradeCalculator.Data.Requests
{
    public class CourseRequest
    {
        public string Name { get; set; }
        public string Instructor { get; set; }
        public ICollection<GradedItemRequest> GradeItems { get; set; }
    }
}