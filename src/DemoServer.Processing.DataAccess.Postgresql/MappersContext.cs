using Acme.DemoServer.Processing.DataAccess.Interface;
using Acme.Wattle.DomainObjects.Interfaces;
using System;

namespace Acme.DemoServer.Processing.DataAccess.PostgreSql;

public class MappersContext
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public MappersContext(
        ITimeService timeService,
        MappersCacheActualStateDtoSettings mappersCacheActualStateDtoSettings,
        TimeSpan timeStatisticsStep,
        IExceptionPolicy exceptionPolicy)
    {
        TimeService = timeService;
        MappersCacheActualStateDtoSettings = mappersCacheActualStateDtoSettings;
        TimeStatisticsStep = timeStatisticsStep;
        ExceptionPolicy = exceptionPolicy;
    }

    public readonly ITimeService TimeService;
    public readonly MappersCacheActualStateDtoSettings MappersCacheActualStateDtoSettings;
    public readonly TimeSpan TimeStatisticsStep;
    public readonly IExceptionPolicy ExceptionPolicy;
}