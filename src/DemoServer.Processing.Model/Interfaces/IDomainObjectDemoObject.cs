using Acme.DemoServer.Processing.Api.Common.Dtos.DemoObject;
using Acme.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;
using Acme.DemoServer.Processing.Common;
using Acme.Wattle.DomainObjects.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Acme.DemoServer.Processing.Model.Interfaces;

/// <summary>
/// Объект.
/// </summary>
[DomainObjectInterface(WellknownDomainObjects.Text.DemoObject)]
[SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
public interface IDomainObjectDemoObject : IDomainObject, IDomainObjectVersion
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
