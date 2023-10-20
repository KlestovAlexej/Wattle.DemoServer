using ShtrihM.DemoServer.Processing.Api.Common;
using ShtrihM.Wattle3.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace ShtrihM.DemoServer.Processing.Model.Implements;

[AttributeUsage(AttributeTargets.Method)]
public class WorkflowErrorCodeDataKeysAttribute : Attribute
{
    public WorkflowErrorCodeDataKeysAttribute(int code, params string[] keys)
    {
        Code = code;
        Keys = keys ?? throw new ArgumentNullException(nameof(keys));
    }

    public int Code { get; }
    public string[] Keys { get; }

    public static Dictionary<int, string> GetRemarks(IReadOnlyDictionary<int, string> remarks)
    {
        var map = new Dictionary<int, HashSet<string>>();
        foreach (var methodInfo in typeof(WorkflowExceptionPolicy).GetMethods(BindingFlags.Instance | BindingFlags.Public))
        {
            if (false == methodInfo.IsDefined(typeof(WorkflowErrorCodeDataKeysAttribute)))
            {
                continue;
            }

            var attribute = methodInfo.GetCustomAttribute<WorkflowErrorCodeDataKeysAttribute>();
            Debug.Assert(attribute != null, nameof(attribute) + " != null");

            if (false == map.TryGetValue(attribute!.Code, out var keys))
            {
                keys = new HashSet<string>();
                map.Add(attribute.Code, keys);
            }

            foreach (var key in attribute.Keys)
            {
                keys.Add(key);
            }
        }

        var result = new Dictionary<int, string>(remarks);

        foreach (var entry in map)
        {
            if (result.TryGetValue(entry.Key, out var remark))
            {
                result[entry.Key] = DoGetRemarks(entry.Value) + "<br>" + remark;
            }
            else
            {
                result.Add(entry.Key, DoGetRemarks(entry.Value));
            }
        }

        return result;
    }

    private static string DoGetRemarks(HashSet<string> keys)
    {
        var result = string.Empty;
        var index = keys.Count;
        foreach (var key in keys)
        {
            --index;
            result += $"В поле '{nameof(WorkflowException.Data)}' по ключу '{key}' находится '{WellknownWorkflowExceptionDataKeys.GetDisplayName(key)}'.";

            if (index != 0)
            {
                result += "<br>";
            }
        }

        return result;
    }
}