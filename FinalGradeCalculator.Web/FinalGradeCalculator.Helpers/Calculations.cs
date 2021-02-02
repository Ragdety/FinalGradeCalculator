using System.Collections.Generic;
using FinalGradeCalculator.Data.Models;
using System.Linq;

namespace FinalGradeCalculator.Helpers
{
    public class Calculations
    {
        public static double CalculateFinalGrade(IList<GradedItem> gradedItems)
        {
            var grades = new double[gradedItems.Count];

            for (int i = 0; i < gradedItems.Count; i++)
            {
                var gradedItem = gradedItems[i];
                grades[i] = gradedItem.Grade;
            }

            return Queryable.Average(grades.AsQueryable());
        }
    }
}