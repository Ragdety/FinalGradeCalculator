using FinalGradeCalculator.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalGradeCalculator.Data
{
    public class FinalGradeCalculatorDbContext : DbContext
    {
        public FinalGradeCalculatorDbContext() { }
        public FinalGradeCalculatorDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<GradedItem> GradedItems { get; set; }
    }
}