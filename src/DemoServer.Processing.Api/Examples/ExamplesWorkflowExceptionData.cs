using ShtrihM.Wattle3.Common.Exceptions;
using Swashbuckle.AspNetCore.Filters;

namespace ShtrihM.DemoServer.Processing.Api.Examples;

public class ExamplesWorkflowExceptionData : IExamplesProvider<WorkflowExceptionData>
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
                new()
                {
                    ["Key 1"] = "Value 1",
                    ["Key 2"] = "Value 2",
                    ["Key 3"] = "Value 3",
                },
        };

        return result;
    }
}