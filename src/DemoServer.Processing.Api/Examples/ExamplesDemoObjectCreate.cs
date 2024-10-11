using Acme.DemoServer.Processing.Api.Common.Dtos.DemoObject;
using Swashbuckle.AspNetCore.Filters;

namespace Acme.DemoServer.Processing.Api.Examples;

public sealed class ExamplesDemoObjectCreate : IExamplesProvider<DemoObjectCreate>
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