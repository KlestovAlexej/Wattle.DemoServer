using FluentValidation;
using Acme.DemoServer.Processing.Api.Common;
using Acme.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;

namespace Acme.DemoServer.Processing.Api.Validators;

public sealed class ValidatorDemoObjectUpdateFieldValueOfName : AbstractValidator<DemoObjectUpdateFieldValueOfName>
{
    public ValidatorDemoObjectUpdateFieldValueOfName()
    {
        RuleFor(x => x.Name)
            .MaximumLength(FieldsConstants.DemoObjectNameMaxLength);
    }
}