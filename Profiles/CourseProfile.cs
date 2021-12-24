using AutoMapper;

namespace Evaluasi.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Models.Course, Dtos.CourseDto>();

            CreateMap<Dtos.CourseForCreateDto, Models.Course>();
        }
    }
}
