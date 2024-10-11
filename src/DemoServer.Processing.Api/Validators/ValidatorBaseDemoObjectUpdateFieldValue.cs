using FluentValidation;
using Acme.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;

namespace Acme.DemoServer.Processing.Api.Validators;

public sealed class ValidatorBaseDemoObjectUpdateFieldValue : AbstractValidator<BaseDemoObjectUpdateFieldValue>
{
    public ValidatorBaseDemoObjectUpdateFieldValue()
    {
        When(model => model is DemoObjectUpdateFieldValueOfName,
            () =>
                RuleFor(entity => entity as DemoObjectUpdateFieldValueOfName)
                    .SetValidator(new ValidatorDemoObjectUpdateFieldValueOfName()!));
    }
}