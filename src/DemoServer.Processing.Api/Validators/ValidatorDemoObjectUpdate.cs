using FluentValidation;
using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;

namespace ShtrihM.DemoServer.Processing.Api.Validators;

public sealed class ValidatorDemoObjectUpdate : AbstractValidator<DemoObjectUpdate>
{
    public ValidatorDemoObjectUpdate()
    {
        RuleForEach(x => x.Fields).SetValidator(new ValidatorBaseDemoObjectUpdateFieldValue());
    }
}