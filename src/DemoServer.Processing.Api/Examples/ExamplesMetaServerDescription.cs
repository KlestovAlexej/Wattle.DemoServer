using Acme.Wattle.Common.Interfaces;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;

namespace Acme.DemoServer.Processing.Api.Examples;

public sealed class ExamplesMetaServerDescription : IExamplesProvider<MetaServerDescription>
{
    public MetaServerDescription GetExamples()
    {
        var result = new MetaServerDescription
        {
            ProductBuildVersion = new Version(1, 2, 3, 4),
            ProductVersion = new Version(5, 6, 7, 8),
            ProductId = Guid.NewGuid(),
            InstallationName = "InstallationName",
            InstallationId = Guid.NewGuid(),
            DateTime = DateTimeOffset.Now,
            Properties =
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