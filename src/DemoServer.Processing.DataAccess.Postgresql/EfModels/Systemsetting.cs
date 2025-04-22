using System;

namespace Acme.DemoServer.Processing.DataAccess.PostgreSql.EfModels;

public partial class Systemsetting
{
    public Guid Id { get; set; }

    public string Value { get; set; } = null!;

    public string Name { get; set; } = null!;
}
