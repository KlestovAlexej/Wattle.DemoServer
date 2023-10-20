using ShtrihM.DemoServer.Processing.DataAccess.Interface;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using System;

namespace ShtrihM.DemoServer.Processing.DataAccess.PostgreSql;

public class MappersContext
{
    public MappersContext(
        ITimeService timeService,
        MappersCacheActualStateDtoSettings mappersCacheActualStateDtoSettings,
        TimeSpan timeStatisticsStep,
        IExceptionPolicy exceptionPolicy)
    {
        TimeService = timeService ?? throw new ArgumentNullException(nameof(timeService));
        MappersCacheActualStateDtoSettings = mappersCacheActualStateDtoSettings ?? throw new ArgumentNullException(nameof(mappersCacheActualStateDtoSettings));
        TimeStatisticsStep = timeStatisticsStep;
        ExceptionPolicy = exceptionPolicy ?? throw new ArgumentNullException(nameof(exceptionPolicy));
    }

    public readonly ITimeService TimeService;
    public readonly MappersCacheActualStateDtoSettings MappersCacheActualStateDtoSettings;
    public readonly TimeSpan TimeStatisticsStep;
    public readonly IExceptionPolicy ExceptionPolicy;
}