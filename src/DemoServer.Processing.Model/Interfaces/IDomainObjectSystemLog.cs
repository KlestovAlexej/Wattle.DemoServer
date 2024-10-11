using Acme.DemoServer.Common;
using Acme.DemoServer.Processing.Common;
using Acme.Wattle.DomainObjects.Interfaces;
using System;

namespace Acme.DemoServer.Processing.Model.Interfaces;

/// <summary>
/// Системный лог.
/// </summary>
[DomainObjectInterface(WellknownDomainObjects.Text.SystemLog)]
public interface IDomainObjectSystemLog : IDomainObject
{
    /// <summary>
    /// Код записи <seealso cref="WellknownSytemLogCodes"/>.
    /// </summary>
    int Code { get; }

    /// <summary>
    /// Дата создания.
    /// </summary>
    DateTimeOffset CreateDate { get; }

    /// <summary>
    /// Данные.
    /// </summary>
    string Data { get; }

    /// <summary>
    /// Сообщение.
    /// </summary>
    string Message { get; }

    /// <summary>
    /// Тип записи <seealso cref="WellknownSytemLogTypes"/>.
    /// </summary>
    int Type { get; }
}