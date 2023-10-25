using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using System;
using System.Runtime.CompilerServices;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.Wattle3.Primitives;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.SystemLog;

[DomainObjectDataMapper(WellknownMappersAsText.SystemLog, DomainObjectDataTarget.Create)]
// ReSharper disable once ClassNeverInstantiated.Global
public sealed class DomainObjectSystemLog : BaseDomainObject<DomainObjectSystemLog>, IDomainObjectSystemLog
{
    #region Template

    public class Template : IDomainObjectTemplate
    {
        public Template(
            int code,
            int type,
            string message,
            string data)
        {
            Code = code;
            Type = type;
            Message = message ?? throw new ArgumentNullException(nameof(message));
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public readonly int Code;
        public readonly int Type;
        public readonly string Message;
        public readonly string Data;
    }
    #endregion

    // ReSharper disable once UnusedMember.Global
    public DomainObjectSystemLog(SystemLogDtoActual data)
        : base(data.Id, false)
    {
        Code = data.Code;
        CreateDate = data.CreateDate.SpecifyKindLocal();
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
        CreateDate = timeService.NowDateTime;
        Data = template.Data;
        Message = template.Message;
        Type = template.Type;

        if (Message.Length > Constants.SystemLogFieldMaxSizeMessage)
        {
            Message = Message.Substring(0, Constants.SystemLogFieldMaxSizeMessage);
        }
    }

    public override Guid TypeId => WellknownDomainObjects.SystemLog;

    [DomainObjectFieldValue(DomainObjectDataTarget.Create)]
    public int Code
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
    }

    [DomainObjectFieldValue(DomainObjectDataTarget.Create)]
    public DateTime CreateDate
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
    }

    [DomainObjectFieldValue(DomainObjectDataTarget.Create)]
    public string Data
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
    }

    [DomainObjectFieldValue(DomainObjectDataTarget.Create)]
    public string Message
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
    }

    [DomainObjectFieldValue(DomainObjectDataTarget.Create)]
    public int Type
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
    }
}