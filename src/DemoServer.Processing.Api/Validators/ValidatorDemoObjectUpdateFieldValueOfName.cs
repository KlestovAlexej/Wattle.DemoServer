using FluentValidation;
using ShtrihM.DemoServer.Processing.Api.Common;
using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;

namespace ShtrihM.DemoServer.Processing.Api.Validators;

public class ValidatorDemoObjectUpdateFieldValueOfName : AbstractValidator<DemoObjectUpdateFieldValueOfName>
{
    public ValidatorDemoObjectUpdateFieldValueOfName()
    {
        RuleFor(x => x.Name)
            .MaximumLength(FieldsConstants.DemoObjectNameMaxLength);
    }
}