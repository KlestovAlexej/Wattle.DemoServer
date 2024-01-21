using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.Wattle3.DomainObjects.AsyncTasks;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;

namespace ShtrihM.DemoServer.Processing.Model.Interfaces;

/// <summary>
/// Задача с отложенным запуском.
/// </summary>
[DomainObjectInterface(WellknownDomainObjects.Text.DemoDelayTask)]
[SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
public interface IDomainObjectDemoDelayTask : IDomainObject, IDomainObjectVersion, IDomainAsyncTask
{
    /// <summary>
    /// Дата создания.
    /// </summary>
    DateTimeOffset CreateDate { get; }

    /// <summary>
    /// Дата модификации.
    /// </summary>
    DateTimeOffset ModificationDate { get; }

    /// <summary>
    /// Сценарий.
    /// </summary>
    string Scenario { get; }

    /// <summary>
    /// Дата запуска.
    /// </summary>
    [AsyncTaskRunDateTime]
    DateTimeOffset? StartDate { get; }
}