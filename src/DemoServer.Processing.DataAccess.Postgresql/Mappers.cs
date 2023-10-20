using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.DataAccess.Interface;
using ShtrihM.DemoServer.Processing.DataAccess.PostgreSql;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.Wattle3.DomainObjects;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.Mappers.PostgreSql;
using ShtrihM.Wattle3.Primitives;
using ShtrihM.Wattle3.Utils;
using System;
using System.Collections.Generic;
using System.Data;

// ReSharper disable once CheckNamespace
namespace ShtrihM.DemoServer.Processing.Generated.PostgreSql.Implements;

public partial class Mappers : ICustomMappers
{
    partial void OnExitConstructor(object context)
    {
        if (context == null)
        {
            return;
        }

        var mappersContext = (MappersContext)context;

        #region DemoObject

        {
            mappersContext.MappersCacheActualStateDtoSettings.DemoObject.Value.Enabled.Value =
                mappersContext.MappersCacheActualStateDtoSettings.DemoObject.Value.Enabled.Value
                && mappersContext.MappersCacheActualStateDtoSettings.Enabled.Value;

            var actualDtoMemoryCache =
                new MemoryCacheMapperActualStateDto<DemoObjectDtoActual>(
                    mappersContext.TimeService,
                    mappersContext.MappersCacheActualStateDtoSettings.DemoObject.Value,
                    WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.MapperDemoObjectCacheActualStateDto),
                    new LocksPoolEx<long>(
                        GuidGenerator.New($"{WellknownCommonInfrastructureMonitors.MapperDemoObjectCacheActualStateDto} {nameof(MapperDemoObject)}"),
                        "Пул лок-объектов." + Environment.NewLine + WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.MapperDemoObjectCacheActualStateDto),
                        "Пул лок-объектов." + Environment.NewLine + WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.MapperDemoObjectCacheActualStateDto),
                        mappersContext.TimeService),
                    new BinarySerializerAsMessagePack<DemoObjectDtoActual>(),
                    mappersContext.ExceptionPolicy,
                    WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.MapperDemoObjectCacheActualStateDto),
                    WellknownCommonInfrastructureMonitors.MapperDemoObjectCacheActualStateDto,
                    timeStatisticsStep: mappersContext.TimeStatisticsStep);
            var mapper =
                new MapperDemoObject(
                    ExceptionPolicy,
                    m_selectFilterFactory,
                    new InfrastructureMonitorMapper(
                        mappersContext.TimeService,
                        WellknownCommonInfrastructureMonitors.MapperDemoObject,
                        WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.MapperDemoObject),
                        WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.MapperDemoObject),
                        actualDtoMemoryCache.InfrastructureMonitor),
                    actualDtoMemoryCache);
            RemoveMapper(mapper.MapperId).SilentDispose();
            AddMapper(mapper);
        }

        #endregion

        #region DemoObjectX

        {
            mappersContext.MappersCacheActualStateDtoSettings.DemoObjectX.Value.Enabled.Value =
                mappersContext.MappersCacheActualStateDtoSettings.DemoObjectX.Value.Enabled.Value
                && mappersContext.MappersCacheActualStateDtoSettings.Enabled.Value;

            var actualDtoMemoryCache =
                new MemoryCacheMapperActualStateDto<DemoObjectXDtoActual>(
                    mappersContext.TimeService,
                    mappersContext.MappersCacheActualStateDtoSettings.DemoObjectX.Value,
                    WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.MapperDemoObjectXCacheActualStateDto),
                    new LocksPoolEx<long>(
                        GuidGenerator.New($"{WellknownCommonInfrastructureMonitors.MapperDemoObjectXCacheActualStateDto} {nameof(MapperDemoObjectX)}"),
                        "Пул лок-объектов." + Environment.NewLine + WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.MapperDemoObjectXCacheActualStateDto),
                        "Пул лок-объектов." + Environment.NewLine + WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.MapperDemoObjectXCacheActualStateDto),
                        mappersContext.TimeService),
                    new BinarySerializerAsMessagePack<DemoObjectXDtoActual>(),
                    mappersContext.ExceptionPolicy,
                    WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.MapperDemoObjectXCacheActualStateDto),
                    WellknownCommonInfrastructureMonitors.MapperDemoObjectXCacheActualStateDto,
                    timeStatisticsStep: mappersContext.TimeStatisticsStep);
            var mapper =
                new MapperDemoObjectX(
                    ExceptionPolicy,
                    m_selectFilterFactory,
                    new InfrastructureMonitorMapper(
                        mappersContext.TimeService,
                        WellknownCommonInfrastructureMonitors.MapperDemoObjectX,
                        WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.MapperDemoObjectX),
                        WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.MapperDemoObjectX),
                        actualDtoMemoryCache.InfrastructureMonitor),
                    actualDtoMemoryCache);
            RemoveMapper(mapper.MapperId).SilentDispose();
            AddMapper(mapper);
        }

        #endregion
    }

    public IDictionary<Guid, string> GetSystemSettings(IMappersSession session)
    {
        if (session == null)
        {
            throw new ArgumentNullException(nameof(session));
        }
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
}