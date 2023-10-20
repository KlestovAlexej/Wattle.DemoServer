using System;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorkLocks;
using ShtrihM.Wattle3.Primitives;
using System.Runtime.CompilerServices;
using ShtrihM.DemoServer.Processing.Api.Common;

namespace ShtrihM.DemoServer.Processing.Model.Implements.UnitOfWorkLocks;

public sealed class UnitOfWorkLocks : AbstractUnitOfWorkLocks
{
    private readonly WorkflowExceptionPolicy m_workflowExceptionPolicy;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public UnitOfWorkLocks(
        WorkflowExceptionPolicy workflowExceptionPolicy,
        IUnitOfWorkLocksHub unitOfWorkLocksHub)
        : base(unitOfWorkLocksHub)
    {
        if (workflowExceptionPolicy == null)
        {
            ThrowsHelper.ThrowArgumentNullException(nameof(workflowExceptionPolicy));
        }

        m_workflowExceptionPolicy = workflowExceptionPolicy;
    }

    protected override WorkflowException CreateTooBusy(Guid lockId)
    {
        var result = m_workflowExceptionPolicy.CreateTooBusy();

        result.Data.Add(WellknownWorkflowExceptionDataKeys.LockId, lockId.ToString("N"));

        return result;
    }
}