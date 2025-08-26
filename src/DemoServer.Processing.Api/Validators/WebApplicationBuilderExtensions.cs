using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Acme.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;

namespace Acme.DemoServer.Processing.Api.Validators;

public static class WebApplicationBuilderExtensions
{
    // ReSharper disable once UnusedMethodReturnValue.Global
    public static WebApplicationBuilder AddCustomValidators(this WebApplicationBuilder builder)
    {
        builder.Services.AddFluentValidationAutoValidation();

        builder.Services.AddSingleton<IValidator<DemoObjectUpdate>, ValidatorDemoObjectUpdate>();

        return builder;
    }
}