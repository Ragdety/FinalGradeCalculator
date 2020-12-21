using FinalGradeCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalGradeCalculator.Web.CourseRequests
{
    public class NewCourseRequest
    {
        public string Name { get; set; }
        public string Instructor { get; set; }
        public ICollection<GradedItem> GradeItems { get; set; }
    }
}
