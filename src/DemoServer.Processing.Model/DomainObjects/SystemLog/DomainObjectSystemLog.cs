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
public sealed class DomainObjectSystemLog : BaseDomainObject<DomainObjectSystemLog>, IDomainObjectSystemLog
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DomainObjectSystemLog(SystemLogDtoActual data)
        : base(data.Id, false)
    {
        Code = data.Code;
        CreateDate = data.CreateDate.SpecifyKindLocal();
        Data = data.Data;
        Message = data.Message;
        Type = data.Type;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DomainObjectSystemLog(
        long identity,
        DomainObjectTemplateSystemLog template,
        DateTime createDate)
        : base(identity, true)
    {
        Code = template.Code;
        CreateDate = createDate;
        Data = template.Data;
        Message = template.Message;
        Type = template.Type;
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