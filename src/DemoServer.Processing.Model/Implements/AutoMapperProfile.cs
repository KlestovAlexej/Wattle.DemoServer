using AutoMapper;
using ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;
using ShtrihM.DemoServer.Processing.Generated.Interface;

namespace ShtrihM.DemoServer.Processing.Model.Implements;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Demoobjectx, DemoObjectXDtoActual>();
    }
}