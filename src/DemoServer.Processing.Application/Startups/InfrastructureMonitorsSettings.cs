namespace ShtrihM.DemoServer.Processing.Application.Startups;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

public class InfrastructureMonitorsSettings
{
    public static readonly string SectionName = "InfrastructureMonitors";

    public string Endpoint { get; set; }
}