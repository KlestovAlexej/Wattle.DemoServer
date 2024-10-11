using Acme.DemoServer.Processing.Api.Common;
using Acme.Wattle.Common.Exceptions;
using Acme.Wattle.DomainObjects.Common;
using System.Globalization;
using System.Runtime.CompilerServices;
using Acme.Wattle.Swashbuckle.AspNetCore;

namespace Acme.DemoServer.Processing.Model.Implements;

public sealed class WorkflowExceptionPolicy() : DefaultWorkflowExceptionPolicy(CommonWorkflowExceptionErrorCodesBuilder.New())
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public WorkflowException CreateDemoObjectXKeyAlreadyExists()
    {
        var result = new WorkflowException(
            WorkflowErrorCodes.GetDisplayName(WorkflowErrorCodes.DemoObjectXKeyAlreadyExists),
            WorkflowErrorCodes.DemoObjectXKeyAlreadyExists,
            WorkflowErrorCodes.GetSeverity(WorkflowErrorCodes.DemoObjectXKeyAlreadyExists),
            string.Empty);

        return (result);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public WorkflowException CreateTooBusy(string? details = null)
    {
        var result = new WorkflowException(
            WorkflowErrorCodes.GetDisplayName(WorkflowErrorCodes.TooBusy),
            WorkflowErrorCodes.TooBusy,
            WorkflowErrorCodes.GetSeverity(WorkflowErrorCodes.TooBusy),
            details ?? string.Empty);

        return (result);
    }

    [WorkflowErrorCodeDataKeys(WorkflowErrorCodes.DemoObjectNotFound, WellknownWorkflowExceptionDataKeys.Id)]
    public WorkflowException CreateDemoObjectNotFound(long id)
    {
        var result = new WorkflowException(
            WorkflowErrorCodes.GetDisplayName(WorkflowErrorCodes.DemoObjectNotFound),
            WorkflowErrorCodes.DemoObjectNotFound,
            WorkflowErrorCodes.GetSeverity(WorkflowErrorCodes.DemoObjectNotFound),
            string.Empty);

        AddDataKeyId(result, id);

        return (result);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void AddDataKeyId(WorkflowException workflowException, long id)
    {
        workflowException.Data.Add(WellknownWorkflowExceptionDataKeys.Id, id.ToString(CultureInfo.InvariantCulture));
    }
}