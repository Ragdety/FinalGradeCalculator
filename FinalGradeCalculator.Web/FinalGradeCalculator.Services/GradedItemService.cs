using FinalGradeCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalGradeCalculator.Services
{
    public class GradedItemService : IGradedItemService
    {
        public Task AddGradedItem(GradedItem gradedItem)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGradedItem(int gradedItemId, int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<GradedItem>> GetAllGradedItemsFromCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<GradedItem> GetGradedItemFromCourse(int gradedItemId, int courseId)
        {
            throw new NotImplementedException();
        }
    }
}
