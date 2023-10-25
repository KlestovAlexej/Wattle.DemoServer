using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShtrihM.DemoServer.Processing.Application.Startups;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

public static class HealthCheckExtensions
{
    public const string Path = "/health";

    public static WebApplication UseCustomHealthCheck(this WebApplication builder)
    {
        builder.MapHealthChecks(
            Path,
            new HealthCheckOptions
            {
                AllowCachingResponses = false,
                ResponseWriter = WriteResponse
            });

        return builder;
    }

    // ReSharper disable once UnusedMethodReturnValue.Global
    public static WebApplicationBuilder AddCustomHealthCheck(
        this WebApplicationBuilder builder,
        string name = "Entrypoint")
    {
        builder.Services
            .AddHealthChecks()
            .AddCheck<HealthCheck>(name, failureStatus: HealthStatus.Degraded, timeout: TimeSpan.FromSeconds(1));

        builder.Services.Configure<SwaggerGenOptions>(
            options =>
                options.DocumentFilter<DocumentFilterHealthCheck>());

        return builder;
    }

    private static Task WriteResponse(HttpContext context, HealthReport healthReport)
    {
        context.Response.ContentType = "application/json; charset=utf-8";

        var options = new JsonWriterOptions { Indented = true };

        using var memoryStream = new MemoryStream();
        using (var jsonWriter = new Utf8JsonWriter(memoryStream, options))
        {
            jsonWriter.WriteStartObject();
            jsonWriter.WriteString("status", healthReport.Status.ToString());
            jsonWriter.WriteStartObject("results");

            foreach (var healthReportEntry in healthReport.Entries)
            {
                jsonWriter.WriteStartObject(healthReportEntry.Key);
                jsonWriter.WriteString("status", healthReportEntry.Value.Status.ToString());
                jsonWriter.WriteString("description", healthReportEntry.Value.Description);
                jsonWriter.WriteStartObject("data");

                foreach (var item in healthReportEntry.Value.Data)
                {
                    jsonWriter.WritePropertyName(item.Key);

                    // ReSharper disable once ConstantNullCoalescingCondition
                    // ReSharper disable once ConstantConditionalAccessQualifier
                    JsonSerializer.Serialize(jsonWriter, item.Value, item.Value?.GetType() ?? typeof(object));
                }

                jsonWriter.WriteEndObject();
                jsonWriter.WriteEndObject();
            }

            jsonWriter.WriteEndObject();
            jsonWriter.WriteEndObject();
        }

        return context.Response.WriteAsync(Encoding.UTF8.GetString(memoryStream.ToArray()));
    }
}