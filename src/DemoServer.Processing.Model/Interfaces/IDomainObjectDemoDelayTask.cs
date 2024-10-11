using Acme.DemoServer.Processing.Common;
using Acme.Wattle.DomainObjects.AsyncTasks;
using Acme.Wattle.DomainObjects.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Acme.DemoServer.Processing.Model.Interfaces;

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
    /// Состояние сценария.
    /// </summary>
    string ScenarioState { get; }

    /// <summary>
    /// Дата запуска.
    /// </summary>
    [AsyncTaskRunDateTime]
    DateTimeOffset? StartDate { get; }
}