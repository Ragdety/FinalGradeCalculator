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
        private readonly ICourseService _courseService;

        public GradedItemService(FinalGradeCalculatorDbContext db, ICourseService courseService)
        {
            _db = db;
            _courseService = courseService;
        }

        public async Task AddGradedItemToCourse(int courseId, GradedItem gradedItem)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteGradedItemFromCourse(int courseId, int gradedItemId)
        {
            throw new NotImplementedException();
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

        private async Task ValidateCourse(int courseId)
        {
            var course = await _courseService.GetCourse(courseId);

            if (course == null)
                throw new InvalidOperationException(
                    $"No course exists with id {courseId}");
        }
    }
}
