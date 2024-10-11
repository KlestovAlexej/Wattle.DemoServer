using AutoMapper;
using Acme.DemoServer.Processing.DataAccess.PostgreSql.EfModels;
using Acme.DemoServer.Processing.Generated.Interface;

namespace Acme.DemoServer.Processing.Model.Implements;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Demoobjectx, DemoObjectXDtoActual>();
    }
}