using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity, Activity>();//map from, map to 
            CreateMap<Concert, Concert>();//map from, map to 
        }
    }
}