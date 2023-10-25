using ShtrihM.DemoServer.Processing.Api.Common;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.DomainObjects.Common;
using System.Globalization;

namespace ShtrihM.DemoServer.Processing.Model.Implements;

public class WorkflowExceptionPolicy() : DefaultWorkflowExceptionPolicy(CommonWorkflowExceptionErrorCodesBuilder.New())
{
    public WorkflowException CreateDemoObjectXKeyAlreadyExists()
    {
        var result = new WorkflowException(
            WorkflowErrorCodes.GetDisplayName(WorkflowErrorCodes.DemoObjectXKeyAlreadyExists),
            WorkflowErrorCodes.DemoObjectXKeyAlreadyExists,
            WorkflowErrorCodes.GetSeverity(WorkflowErrorCodes.DemoObjectXKeyAlreadyExists),
            string.Empty);

        return (result);
    }

    public WorkflowException CreateTooBusy(string details = null)
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

    private void AddDataKeyId(WorkflowException workflowException, long id)
    {
        workflowException.Data.Add(WellknownWorkflowExceptionDataKeys.Id, id.ToString(CultureInfo.InvariantCulture));
    }
}