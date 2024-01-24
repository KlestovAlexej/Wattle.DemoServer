using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using System;
using ShtrihM.DemoServer.Processing.Generated.Interface;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.ChangeTracker;

[DomainObjectDataMapper]
// ReSharper disable once ClassNeverInstantiated.Global
public sealed class DomainObjectChangeTracker : BaseDomainObject<DomainObjectChangeTracker>, IDomainObjectChangeTracker
{
    #region Template - шаблон создания объекта

    /// <summary>
    /// Шаблон создания объекта <see cref="DomainObjectChangeTracker"/>.
    /// </summary>
    public class Template : IDomainObjectTemplate
    {
        public static readonly Template Instance = new();
    }

    #endregion

    #region Конструкторы

    // ReSharper disable once UnusedMember.Global
    public DomainObjectChangeTracker(ChangeTrackerDtoActual data)
        : base(data.Id, false)
    {
        /* NONE */
    }

    // ReSharper disable once UnusedMember.Global
    // ReSharper disable once UnusedParameter.Local
    public DomainObjectChangeTracker(long identity, Template _)
        : base(identity, true)
    {
        /* NONE */
    }

    #endregion

    public override Guid TypeId => WellknownDomainObjects.ChangeTracker;
}