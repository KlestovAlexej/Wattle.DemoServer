using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject;
using Swashbuckle.AspNetCore.Filters;

namespace ShtrihM.DemoServer.Processing.Api.Examples;

public class ExamplesDemoObjectCreate : IExamplesProvider<DemoObjectCreate>
{
    public DemoObjectCreate GetExamples()
    {
        var result =
            new DemoObjectCreate
            {
                Name = "test",
                Enabled = false,
            };

        return result;
    }
}