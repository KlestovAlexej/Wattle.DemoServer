using Microsoft.AspNetCore.Mvc.Formatters;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace ShtrihM.DemoServer.Processing.Application.Startups;

#pragma warning disable CS1591
public class TextPlainInputFormatter : InputFormatter
{
    private const string ContentType = "text/plain";

    public TextPlainInputFormatter()
    {
        SupportedMediaTypes.Add(ContentType);
    }

    public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
    {
        var request = context.HttpContext.Request;
        using var reader = new StreamReader(request.Body);
        var content = await reader.ReadToEndAsync();

        return await InputFormatterResult.SuccessAsync(content);
    }

    public override bool CanRead(InputFormatterContext context)
    {
        var contentType = context.HttpContext.Request.ContentType;
        Debug.Assert(contentType != null, nameof(contentType) + " != null");

        return contentType.StartsWith(ContentType);
    }
}