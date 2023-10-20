using OpenTelemetry.Trace;
using ShtrihM.Wattle3.OpenTelemetry;
using System.Runtime.CompilerServices;

#pragma warning disable CS1591

namespace ShtrihM.DemoServer.Processing.Model;

public static class OpenTelemetryConstants
{
    public static readonly string AttributeParametersIn = OpenTelemetryAttibutes.AttributePrefix + "parameters.in";
    public static readonly string EventNotDefinedCommitVerifying = OpenTelemetryAttibutes.EventPrefix + "NotDefinedCommitVerifying";
    public static readonly string EventDefinedCommitVerifying = OpenTelemetryAttibutes.EventPrefix + "DefinedCommitVerifying";

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SpanAttributes AddCustom(this SpanAttributes attributes, string name, string value)
    {
        attributes?.Add(OpenTelemetryAttibutes.AttributePrefix + name.ToLower(), value);

        return attributes;
    }
}