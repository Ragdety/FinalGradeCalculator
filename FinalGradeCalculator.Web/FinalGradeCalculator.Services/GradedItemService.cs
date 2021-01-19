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

        //Question: Can I inject services into other services?
        private readonly ICourseService _courseService;

        public GradedItemService(FinalGradeCalculatorDbContext db, ICourseService courseService)
        {
            _db = db;
            _courseService = courseService;
        }

        public async Task AddGradedItemToCourse(int courseId, GradedItem gradedItem)
        {
            await ValidateCourse(courseId);
            await _db.GradedItems.AddAsync(gradedItem);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteGradedItemFromCourse(int courseId, int gradedItemId)
        {
            await ValidateCourse(courseId);
            var gradedItem = await GetGradedItemFromCourse(courseId, gradedItemId);

            if(gradedItem == null)
                throw new InvalidOperationException(
                    $"No graded item exists with id {gradedItemId}");

            _db.GradedItems.Remove(gradedItem);
            await _db.SaveChangesAsync();
        }

        public async Task<IList<GradedItem>> GetAllGradedItemsFromCourse(int courseId)
        {
            //Might throw exception
            await ValidateCourse(courseId);

            return await _db.GradedItems
                .Where(c => c.CourseId == courseId)
                .ToListAsync();
        }

        public async Task<GradedItem> GetGradedItemFromCourse(int courseId, int gradedItemId)
        {
            await ValidateCourse(courseId);

            var gradedItem = await _db.GradedItems
                .Where(g => g.CourseId == courseId && g.Id == gradedItemId)
                .FirstOrDefaultAsync();
            return gradedItem;
        }

        public async Task<bool> UpdateGradedItemFromCourse(int courseId, GradedItem gradedItemToUpdate)
        {
            await ValidateCourse(courseId);

            _db.GradedItems.Update(gradedItemToUpdate);
            var updated = await _db.SaveChangesAsync();
            return updated > 0;
        }

        private async Task ValidateCourse(int courseId)
        {
            var course = await _courseService.GetCourse(courseId);

            if (course == null)
                throw new InvalidOperationException(
                    $"No course exists with id {courseId}");
        }
    }
}