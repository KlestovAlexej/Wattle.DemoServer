using FluentValidation;
using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;

namespace ShtrihM.DemoServer.Processing.Api.Validators;

public class ValidatorBaseDemoObjectUpdateFieldValue : AbstractValidator<BaseDemoObjectUpdateFieldValue>
{
    public ValidatorBaseDemoObjectUpdateFieldValue()
    {
        When(model => model is DemoObjectUpdateFieldValueOfName,
            () =>
                RuleFor(entity => entity as DemoObjectUpdateFieldValueOfName)
                    .SetValidator(new ValidatorDemoObjectUpdateFieldValueOfName()!));
    }
}