using ShtrihM.Wattle3.Common.Interfaces;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace ShtrihM.DemoServer.Processing.Api.Examples;

public class ExamplesMetaServerDescription : IExamplesProvider<MetaServerDescription>
{
    public MetaServerDescription GetExamples()
    {
        var result = new MetaServerDescription
        {
            ProductBuildVersion = new(1, 2, 3, 4),
            ProductVersion = new(5, 6, 7, 8),
            ProductId = Guid.NewGuid(),
            InstallationName = "InstallationName",
            InstallationId = Guid.NewGuid(),
            DateTime = DateTimeOffset.Now,
            Properties =
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