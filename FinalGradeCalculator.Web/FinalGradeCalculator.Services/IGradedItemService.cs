using FinalGradeCalculator.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalGradeCalculator.Services
{
    public interface IGradedItemService
    {
        Task<IList<GradedItem>> GetAllGradedItemsFromCourse(int courseId);
        Task<GradedItem> GetGradedItemFromCourse(int courseId, int gradedItemId);
        Task AddGradedItemToCourse(int courseId, GradedItem gradedItem);
        Task DeleteGradedItemFromCourse(int courseId, int gradedItemId);
        Task<bool> UpdateGradedItemFromCourse(int courseId, GradedItem gradedItemToUpdate);
    }
}
