using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace ShtrihM.DemoServer.Processing.Api.Examples;

public class ExamplesDemoObjectUpdate : IExamplesProvider<DemoObjectUpdate>
{
    public DemoObjectUpdate GetExamples()
    {
        var result =
            new DemoObjectUpdate
            {
                Id = -1,
                Fields =
                    new List<BaseDemoObjectUpdateFieldValue>
                    {
                        new DemoObjectUpdateFieldValueOfEnabled
                        {
                            Enabled = false,
                        },
                        new DemoObjectUpdateFieldValueOfName
                        {
                            Name = "test",
                        },
                    },
            };

        return result;
    }
}