using System.Runtime.CompilerServices;
using AutoMapper;
using Acme.DemoServer.Processing.Generated.Interface;

// ReSharper disable once CheckNamespace
namespace Acme.DemoServer.Processing.DataAccess.PostgreSql.EfModels;

public partial class Demoobjectx
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DemoObjectXDtoActual ToMapperDto(IMapper mapper)
    {
        var result = mapper.Map<DemoObjectXDtoActual>(this);

        return result;
    }
}
