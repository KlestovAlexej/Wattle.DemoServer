using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject;
using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace ShtrihM.DemoServer.Processing.Model.Interfaces;

/// <summary>
/// Объект.
/// </summary>
[DomainObjectInterface(WellknownDomainObjects.Text.DemoObject)]
[SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
public interface IDomainObjectDemoObject : IDomainObject
{
    ValueTask UpdateAsync(DemoObjectUpdate parameters, CancellationToken cancellationToken = default);
    DemoObjectInfo GetInfo();

    /// <summary>
    /// Дата создания.
    /// </summary>
    DateTime CreateDate { get; }

    /// <summary>
    /// Дата модификации.
    /// </summary>
    DateTime ModificationDate { get; }

    /// <summary>
    /// Название.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Признак разрешения работы.
    /// </summary>
    bool Enabled { get; }
}