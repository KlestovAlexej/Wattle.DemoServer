using Acme.DemoServer.Processing.Common;
using Acme.DemoServer.Processing.Model.Interfaces;
using Acme.Wattle.DomainObjects.DomainObjects;
using Acme.Wattle.DomainObjects.Interfaces;
using System;
using System.Runtime.CompilerServices;
using Acme.DemoServer.Processing.Generated.Interface;

namespace Acme.DemoServer.Processing.Model.DomainObjects.SystemLog;

[DomainObjectDataMapper]
// ReSharper disable once ClassNeverInstantiated.Global
public sealed class DomainObjectSystemLog : BaseDomainObject<DomainObjectSystemLog>, IDomainObjectSystemLog
{
    #region Template - шаблон создания объекта SystemLog

    /// <summary>
    /// Шаблон создания объекта <see cref="DomainObjectSystemLog"/>.
    /// </summary>
    public class Template : IDomainObjectTemplate
    {
        // ReSharper disable once ConvertToPrimaryConstructor
        public Template(
            int code,
            int type,
            string message,
            string data)
        {
            Code = code;
            Type = type;
            Message = message;
            Data = data;
        }

        public readonly int Code;
        public readonly int Type;
        public readonly string Message;
        public readonly string Data;
    }
    #endregion

    #region Конструкторы

    // ReSharper disable once UnusedMember.Global
    public DomainObjectSystemLog(SystemLogDtoActual data)
        : base(data.Id, false)
    {
        Code = data.Code;
        CreateDate = data.CreateDate;
        Data = data.Data;
        Message = data.Message;
        Type = data.Type;
    }

    // ReSharper disable once UnusedMember.Global
    public DomainObjectSystemLog(
        long identity,
        Template template,
        ITimeService timeService)
        : base(identity, true)
    {
        Code = template.Code;
        CreateDate = timeService.Now;
        Data = template.Data;
        Message = template.Message;
        Type = template.Type;

        if (Message.Length > Constants.SystemLogFieldMaxSizeMessage)
        {
            Message = Message.Substring(0, Constants.SystemLogFieldMaxSizeMessage);
        }
    }

    #endregion

    public override Guid TypeId => WellknownDomainObjects.SystemLog;

    [DomainObjectFieldValue]
    public int Code
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
    }

    [DomainObjectFieldValue]
    public DateTimeOffset CreateDate
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
    }

    [DomainObjectFieldValue]
    public string Data
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
    }

    [DomainObjectFieldValue]
    public string Message
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
    }

    [DomainObjectFieldValue]
    public int Type
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
    }
}