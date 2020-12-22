using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FinalGradeCalculator.Data.Models
{
    public class GradedItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Grade { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int CourseId { get; set; }
    }
}
