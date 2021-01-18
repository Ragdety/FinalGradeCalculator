using AutoMapper;
using FinalGradeCalculator.Data.Models;
using FinalGradeCalculator.Data.Dtos;

namespace FinalGradeCalculator.Web.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>();
        }
    }
}
