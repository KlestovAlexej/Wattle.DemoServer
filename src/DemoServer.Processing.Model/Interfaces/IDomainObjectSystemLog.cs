using ShtrihM.DemoServer.Common;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using System;

namespace ShtrihM.DemoServer.Processing.Model.Interfaces;

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
    DateTime CreateDate { get; }

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