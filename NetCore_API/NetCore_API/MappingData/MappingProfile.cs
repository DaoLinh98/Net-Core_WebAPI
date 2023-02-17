using AutoMapper;
using NetCore_API.Entity;
using NetCore_API.Model;

namespace NetCore_API.MappingData
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserVM>();
            CreateMap<User, UserRespone>();

        }
    }
}
