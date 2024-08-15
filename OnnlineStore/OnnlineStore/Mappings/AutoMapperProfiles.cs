using AutoMapper;
using OnnlineStore.Models.Domain;
using OnnlineStore.Models.DTO;

namespace OnnlineStore.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() { 
        
        CreateMap<Book,BookDto>().ReverseMap();

            CreateMap<AddRequestBookDto, Book>().ReverseMap();

            CreateMap<UpdateRequestBookDto, Book>().ReverseMap();
        
        
        }
    }
}
