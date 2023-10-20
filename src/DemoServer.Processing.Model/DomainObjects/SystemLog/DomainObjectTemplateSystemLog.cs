using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using System;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.SystemLog;

public class DomainObjectTemplateSystemLog : IDomainObjectTemplate
{
    public DomainObjectTemplateSystemLog(
        int code,
        int type,
        string message,
        string data)
    {
        Code = code;
        Type = type;
        Message = message ?? throw new ArgumentNullException(nameof(message));
        Data = data ?? throw new ArgumentNullException(nameof(data));

        if (Message.Length > Constants.SystemLogFieldMaxSizeMessage)
        {
            Message = Message.Substring(0, Constants.SystemLogFieldMaxSizeMessage);
        }
    }

    public readonly int Code;
    public readonly int Type;
    public readonly string Message;
    public readonly string Data;
}