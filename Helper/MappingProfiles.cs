using AutoMapper;
using BookApi.Dto;
using BookApi.Models;

namespace BookApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookDto>();
            CreateMap<Author, AuthorDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Review, ReviewDto>();
        }
    }
}