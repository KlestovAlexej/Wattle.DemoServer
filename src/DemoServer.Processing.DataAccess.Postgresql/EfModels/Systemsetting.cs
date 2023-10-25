using System;
using System.Collections.Generic;

namespace ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;

public partial class Systemsetting
{
    public Guid Id { get; set; }

    public string Value { get; set; }

    public string Name { get; set; }
}
