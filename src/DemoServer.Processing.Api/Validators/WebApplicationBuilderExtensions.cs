using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;

namespace ShtrihM.DemoServer.Processing.Api.Validators;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddCustomValidators(this WebApplicationBuilder builder)
    {
        builder.Services.AddFluentValidationAutoValidation();

        builder.Services.AddScoped<IValidator<DemoObjectUpdate>, ValidatorDemoObjectUpdate>();

        return builder;
    }
}