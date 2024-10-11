using System.Collections.Generic;
using Acme.Wattle.Common.Exceptions;
using Swashbuckle.AspNetCore.Filters;

namespace Acme.DemoServer.Processing.Api.Examples;

public sealed class ExamplesWorkflowExceptionData : IExamplesProvider<WorkflowExceptionData>
{
    public WorkflowExceptionData GetExamples()
    {
        var result = new WorkflowExceptionData
        {
            Code = 46,
            Severity = 1,
            Message = "Сообщение",
            Details = "Детали",
            Data =
                new Dictionary<string, string>
                {
                    ["Key 1"] = "Value 1",
                    ["Key 2"] = "Value 2",
                    ["Key 3"] = "Value 3",
                },
        };

        return result;
    }
}