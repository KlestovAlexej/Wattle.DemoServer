using Acme.DemoServer.Processing.Api.Common.Dtos.DemoObject;
using Swashbuckle.AspNetCore.Filters;

namespace Acme.DemoServer.Processing.Api.Examples;

public sealed class ExamplesDemoObjectInfo : IExamplesProvider<DemoObjectInfo>
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