using FinalGradeCalculator.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalGradeCalculator.Services
{
    public interface IGradedItemService
    {
        Task<IList<GradedItem>> GetAllGradedItemsFromCourse(int courseId);
        Task<GradedItem> GetGradedItemFromCourse(int gradedItemId, int courseId);
        Task AddGradedItem(GradedItem gradedItem);
        Task DeleteGradedItem(int gradedItemId, int courseId);
    }
}
