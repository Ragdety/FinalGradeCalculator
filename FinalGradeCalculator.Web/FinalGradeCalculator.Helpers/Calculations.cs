using System.Collections.Generic;
using FinalGradeCalculator.Data.Models;
using System.Linq;
using System;

namespace FinalGradeCalculator.Helpers
{
    public class Calculations
    {
        public static double? CalculateFinalGrade(ICollection<GradedItem> gradedItems)
        {
            var gradedItemsList = gradedItems.ToList();

            if(gradedItemsList.Count == 0)
                return null;

            var grades = new double[gradedItems.Count];

            for (int i = 0; i < gradedItemsList.Count; i++)
            {
                var gradedItem = gradedItemsList[i];
                grades[i] = gradedItem.Grade;
            }

            return Queryable.Average(grades.AsQueryable());            
        }
    }
}