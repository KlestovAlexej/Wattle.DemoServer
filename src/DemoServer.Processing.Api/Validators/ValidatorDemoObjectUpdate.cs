using FluentValidation;
using Acme.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;

namespace Acme.DemoServer.Processing.Api.Validators;

public sealed class ValidatorDemoObjectUpdate : AbstractValidator<DemoObjectUpdate>
{
    public ValidatorDemoObjectUpdate()
    {
        RuleForEach(x => x.Fields).SetValidator(new ValidatorBaseDemoObjectUpdateFieldValue());
    }
}