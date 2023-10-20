using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject;
using Swashbuckle.AspNetCore.Filters;

namespace ShtrihM.DemoServer.Processing.Api.Examples;

public class ExamplesDemoObjectInfo : IExamplesProvider<DemoObjectInfo>
{
    public DemoObjectInfo GetExamples()
    {
        var result =
            new DemoObjectInfo
            {
                Name = "test",
                Enabled = false,
                Id = -1,
            };

        return result;
    }
}