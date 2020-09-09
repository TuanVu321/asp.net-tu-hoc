using System.Linq;
using AutoMapper;
using WebApplication.Dtos;
using WebApplication.Models;

namespace WebApplication.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest=>dest.PhotoUrl,opt
                    =>opt.MapFrom(src=>src.Photos.FirstOrDefault(p=>p.IsMain).Url))
                .ForMember(dest=>dest.Age,opt
                    =>opt.MapFrom(src=>src.DateOfBirth.CaculateAge()));
            
            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest=>dest.PhotoUrl,opt
                    =>opt.MapFrom(src=>src.Photos.FirstOrDefault(p=>p.IsMain).Url))
                .ForMember(dest=>dest.Age,opt
                    =>opt.MapFrom(src=>src.DateOfBirth.CaculateAge()));
           
            CreateMap<Photo, PhotosForDetailedDto>();
        }
    }
}