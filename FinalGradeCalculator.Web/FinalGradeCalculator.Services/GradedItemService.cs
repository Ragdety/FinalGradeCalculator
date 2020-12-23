using FinalGradeCalculator.Data;
using FinalGradeCalculator.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGradeCalculator.Services
{
    public class GradedItemService : IGradedItemService
    {
        private readonly FinalGradeCalculatorDbContext _db;

        public GradedItemService(FinalGradeCalculatorDbContext db)
        {
            _db = db;
        }

        public async Task AddGradedItem(GradedItem gradedItem)
        {
            await _db.GradedItems.AddAsync(gradedItem);
        }

        public async Task DeleteGradedItem(int gradedItemId)
        {
            var gradedItemToDelete = await GetGradedItem(gradedItemId);
            if(gradedItemToDelete != null)
            {
                _db.GradedItems.Remove(gradedItemToDelete);
            }
            else
            {
                throw new InvalidOperationException(
                    "Cannot delete grade item that doesn't exist");
            }
        }

        public async Task<IList<GradedItem>> GetAllGradedItemsFromCourse(int courseId)
        {
            return await _db.GradedItems
                .Where(c => c.CourseId == courseId)
                .ToListAsync();
        }

        public async Task<GradedItem> GetGradedItem(int gradedItemId)
        {
            var gradedItem = await _db.GradedItems
                .FindAsync(gradedItemId);

            if (gradedItem == null)
                return null;

            return gradedItem;
        }
    }
}
