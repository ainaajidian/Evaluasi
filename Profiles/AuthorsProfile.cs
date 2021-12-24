using AutoMapper;
using System;

namespace Evaluasi.Profiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            CreateMap<Models.Author, Dtos.AuthorDto>()
                .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));



            /*CreateMap<Models.Author, Dtos.AuthorDto>()
               .ForMember(dest => dest.Age,
               opt => opt.MapFrom(src => $"{src.DateOfBirth}"));*/

            CreateMap<Dtos.AuthorForCreateDto, Models.Author>();
        }
    }
}
