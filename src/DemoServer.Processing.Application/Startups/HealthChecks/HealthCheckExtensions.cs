using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace ShtrihM.DemoServer.Processing.Application.Startups.HealthChecks;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

public static class HealthCheckExtensions
{
    public const string PathLive = "/health/live";
    public const string PathReady = "/health/ready";
    public const string PathGlobalReady = "/health/ready/full";

    public static WebApplication UseCustomHealthCheck(this WebApplication builder)
    {
        builder.MapHealthChecks(
            PathLive,
            new HealthCheckOptions
            {
                AllowCachingResponses = false,
                ResponseWriter = WriteResponse,
                Predicate = _ => false
            })
            .ShortCircuit();

        builder.MapHealthChecks(
            PathReady,
            new HealthCheckOptions
            {
                AllowCachingResponses = false,
                ResponseWriter = WriteResponse,
                Predicate = healthCheck => healthCheck.Tags.Contains("ready")
            })
            .ShortCircuit();

        builder.MapHealthChecks(
            PathGlobalReady,
            new HealthCheckOptions
            {
                AllowCachingResponses = false,
                ResponseWriter = WriteResponse,
                Predicate = healthCheck => healthCheck.Tags.Contains("globalready")
            })
            .ShortCircuit();

        return builder;
    }

    // ReSharper disable once UnusedMethodReturnValue.Global
    public static WebApplicationBuilder AddCustomHealthCheck(
        this WebApplicationBuilder builder)
    {

        builder.Services.AddHostedService<EntryPointReadyBackgroundService>();
        builder.Services.AddSingleton<EntryPointReadyHealthCheck>();

        builder.Services
            .AddHealthChecks()
            .AddCheck<EntryPointReadyHealthCheck>("Ready", tags: ["ready"]);

        builder.Services.AddHostedService<EntryPointGlobalReadyBackgroundService>();
        builder.Services.AddSingleton<EntryPointGlobalReadyHealthCheck>();

        builder.Services
            .AddHealthChecks()
            .AddCheck<EntryPointGlobalReadyHealthCheck>("ReadyFull", tags: ["globalready"]);

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

                    // ReSharper disable once ConditionalAccessQualifierIsNonNullableAccordingToAPIContract
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