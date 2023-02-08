using Api.Dto;
using Api.Models;
using AutoMapper;

namespace Api.Helper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
