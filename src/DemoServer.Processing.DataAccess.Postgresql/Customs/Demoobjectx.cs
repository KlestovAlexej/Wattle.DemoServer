using ShtrihM.Wattle3.Mappers.Primitives;
using System.Runtime.CompilerServices;
using ShtrihM.DemoServer.Processing.Generated.Interface;

// ReSharper disable once CheckNamespace
namespace ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;

public partial class Demoobjectx
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IMapperDto ToMapperDto()
    {
        var result =
            new DemoObjectXDtoActual
            {
                Name = Name,
                CreateDate = Createdate,
                Enabled = Enabled,
                Group = Group,
                Id = Id,
                Key1 = Key1,
                Key2 = Key2,
                ModificationDate = Modificationdate,
                Revision = Revision,
            };

        return result;
    }
}
