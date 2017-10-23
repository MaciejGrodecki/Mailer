using AutoMapper;
using Mailer.Core.Domain;
using Mailer.Core.DTO;

namespace Mailer.Core.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            return new MapperConfiguration((cfg =>
            {
                cfg.CreateMap<Email, EmailDto>();
            })).CreateMapper();
        }
    }
}