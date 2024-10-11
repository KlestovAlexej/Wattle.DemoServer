using Acme.DemoServer.Processing.Common;
using Acme.DemoServer.Processing.DataAccess.Interface;
using Acme.DemoServer.Processing.DataAccess.PostgreSql;
using Acme.DemoServer.Processing.Generated.Interface;
using Acme.Wattle.DomainObjects;
using Acme.Wattle.Mappers;
using Acme.Wattle.Mappers.Interfaces;
using Acme.Wattle.Mappers.PostgreSql;
using Acme.Wattle.Primitives;
using Acme.Wattle.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using Acme.Wattle.Mappers.Primitives;
using Acme.Wattle.Caching;
using Acme.Wattle.Caching.Interfaces;
using Acme.Wattle.Infrastructures.Interfaces.Monitors;

// ReSharper disable once CheckNamespace
namespace Acme.DemoServer.Processing.Generated.PostgreSql.Implements;

public partial class Mappers : ICustomMappers
{
    partial void OnExitConstructor(object context)
    {
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (context is null)
        {
            return;
        }

        var mappersContext = (MappersContext)context;

        AddMapper(
            CreateMapper<MapperDemoObject, DemoObjectDtoActual>(
                mappersContext,
                WellknownCommonInfrastructureMonitors.MapperDemoObject,
                mappersContext.MappersCacheActualStateDtoSettings.DemoObject.Value));

        AddMapper(
            CreateMapper<MapperDemoObjectX, DemoObjectXDtoActual>(
                mappersContext,
                WellknownCommonInfrastructureMonitors.MapperDemoObjectX,
                mappersContext.MappersCacheActualStateDtoSettings.DemoObjectX.Value));
    }

    public IDictionary<Guid, string> GetSystemSettings(IMappersSession session)
    {
        var typedSession = (IPostgreSqlMappersSession)session;

        var result = new Dictionary<Guid, string>();

        using var command = typedSession.CreateCommand(false);
        command.CommandText = "SELECT Id, Value FROM SystemSetting";
        command.CommandType = CommandType.Text;

        using var reader = command.ExecuteReader();
        var indexId = reader.GetOrdinal("Id");
        var indexValue = reader.GetOrdinal("Value");

        while (reader.Read())
        {
            result.Add(reader.GetGuid(indexId), reader.GetString(indexValue));
        }

        return (result);
    }

    private new void AddMapper(IMapper mapper)
    {
        RemoveMapper(mapper.MapperId).SilentDispose();
        base.AddMapper(mapper);
    }

    private TMapper CreateMapper<TMapper, TMapperActualStateDto>(
        IMappersExceptionPolicy exceptionPolicy,
        IPostgreSqlMapperSelectFilterFactory selectFilterFactory,
        IInfrastructureMonitorMapper infrastructureMonitor,
        IMemoryCache<TMapperActualStateDto, long> actualDtoMemoryCache)
    {
        var constructorInfo =
            typeof(TMapper)
                .GetConstructor(
                    new[]
                    {
                        typeof(IMappersExceptionPolicy),
                        typeof(IPostgreSqlMapperSelectFilterFactory),
                        typeof(IInfrastructureMonitorMapper),
                        typeof(IMemoryCache<TMapperActualStateDto, long>)
                    });
        if (constructorInfo == null)
        {
            throw new InvalidOperationException(
                $"Для маппера '{typeof(TMapper).AssemblyQualifiedName}' не найден конструктор.");
        }

        var result =
            (TMapper)constructorInfo.Invoke(
                new object[]
                {
                    exceptionPolicy,
                    selectFilterFactory,
                    infrastructureMonitor,
                    actualDtoMemoryCache
                });

        return (result);
    }

    private TMapper CreateMapper<TMapper, TMapperActualStateDto>(
        MappersContext mappersContext,
        Guid mapperIdInfrastructureMonitor,
        MemoryCacheSettings memoryCacheSettings)
        where TMapperActualStateDto : IMapperDtoVersion
    {
        memoryCacheSettings.Enabled.Value =
            memoryCacheSettings.Enabled.Value
            && mappersContext.MappersCacheActualStateDtoSettings.Enabled.Value;

        var cacheName = "Кэш актуальных данных состояния доменного объекта в БД";
        var mapperCacheIdInfrastructureMonitor = GuidGenerator.New(typeof(TMapper).FullName);
        var actualDtoMemoryCache =
            new MemoryCacheMapperActualStateDto<TMapperActualStateDto>(
                mappersContext.TimeService,
                memoryCacheSettings,
                cacheName,
                new LocksPoolEx<long>(
                    GuidGenerator.New($"{mapperCacheIdInfrastructureMonitor} {cacheName}"),
                    $"Пул лок-объектов '{cacheName}'.",
                    $"Пул лок-объектов '{cacheName}'.",
                    mappersContext.TimeService),
                new BinarySerializerAsMessagePack<TMapperActualStateDto>(),
                mappersContext.ExceptionPolicy,
                cacheName,
                mapperCacheIdInfrastructureMonitor,
                timeStatisticsStep: mappersContext.TimeStatisticsStep);
        var infrastructureMonitorMapper =
            new InfrastructureMonitorMapper(
                mappersContext.TimeService,
                mapperIdInfrastructureMonitor,
                WellknownCommonInfrastructureMonitors.GetDisplayName(mapperIdInfrastructureMonitor),
                WellknownCommonInfrastructureMonitors.GetDisplayName(mapperIdInfrastructureMonitor),
                actualDtoMemoryCache.InfrastructureMonitor);
        var mapper =
            CreateMapper<TMapper, TMapperActualStateDto>(
                ExceptionPolicy,
                m_selectFilterFactory,
                infrastructureMonitorMapper,
                actualDtoMemoryCache);

        return mapper;
    }
}