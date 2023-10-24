using System;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.Mappers.PostgreSql;
using ShtrihM.Wattle3.Primitives;

namespace ShtrihM.DemoServer.Processing.Model.Implements;

public static class DomainObjectIntergratorHelpers
{
    public static Func<TMapper, long, long> GetIdentityPrepare<TMapper>(ICustomEntryPoint entryPoint)
        where TMapper : IMapper
    {
        var mapper = entryPoint.Mappers.GetMapper<TMapper>();
        if (mapper is IPartitionsMapper partitionsMapper)
        {
            var partitionsLevel = partitionsMapper.Partitions.Level;
            var partitionsDay = entryPoint.PartitionsDay;

            return (_, identity) =>
            {
                var nowDayIndex = partitionsDay.NowDayIndex;
                identity = ComplexIdentity.Build(partitionsLevel, nowDayIndex, identity);

                return identity;
            };
        }

        throw new InvalidOperationException($"Маппер '{typeof(TMapper).AssemblyQualifiedName}' не поддерживает партиционирование.");
    }
}