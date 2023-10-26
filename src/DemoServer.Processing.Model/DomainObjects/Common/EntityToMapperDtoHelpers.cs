using System.Runtime.CompilerServices;
using ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.Wattle3.Mappers.Primitives;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.Common;

public static class EntityToMapperDtoHelpers
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IMapperDto ToMapperDto(this Demoobjectx entity)
    {
        if (entity == null)
        {
            return null;
        }

        var result =
            new DemoObjectXDtoActual
            {
                Name = entity!.Name,
                CreateDate = entity.Createdate,
                Enabled = entity.Enabled,
                Group = entity.Group,
                Id = entity.Id,
                Key1 = entity.Key1,
                Key2 = entity.Key2,
                ModificationDate = entity.Modificationdate,
                Revision = entity.Revision,
            };

        return result;
    }
}