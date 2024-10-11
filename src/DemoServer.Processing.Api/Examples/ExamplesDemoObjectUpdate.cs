using Acme.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;
using Swashbuckle.AspNetCore.Filters;

namespace Acme.DemoServer.Processing.Api.Examples;

public sealed class ExamplesDemoObjectUpdate : IExamplesProvider<DemoObjectUpdate>
{
    public DemoObjectUpdate GetExamples()
    {
        var result =
            new DemoObjectUpdate
            {
                Id = -1,
                Fields =
                [
                    new DemoObjectUpdateFieldValueOfEnabled
                    {
                        Enabled = false,
                    },

                    new DemoObjectUpdateFieldValueOfName
                    {
                        Name = "test",
                    },
                ],
            };

        return result;
    }
}