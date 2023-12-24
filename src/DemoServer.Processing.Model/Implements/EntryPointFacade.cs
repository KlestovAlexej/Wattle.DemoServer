using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject;
using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;
using ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObject;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ShtrihM.DemoServer.Processing.Model.Implements;

public class EntryPointFacade : IEntryPointFacade
{
    private readonly ICustomEntryPoint m_entryPoint;

    // ReSharper disable once ConvertToPrimaryConstructor
    public EntryPointFacade(ICustomEntryPoint entryPoint)
    {
        m_entryPoint = entryPoint;
    }

    public async ValueTask<DemoObjectInfo> DemoObjectReadAsync(
        long id,
        CancellationToken cancellationToken = default)
    {
        var domainObject =
            await m_entryPoint
                .GetRegister<IDomainObjectDemoObject>()
                .FindAsync<IDomainObjectDemoObject>(id, cancellationToken)
                .ConfigureAwait(false);
        if (domainObject == null)
        {
            var workflowException = m_entryPoint.WorkflowExceptionPolicy.CreateDemoObjectNotFound(id);

            throw workflowException;
        }

        var result = domainObject.GetInfo();

        return result;
    }

    public async ValueTask<DemoObjectInfo> DemoObjectUpdateAsync(
        DemoObjectUpdate parameters,
        CancellationToken cancellationToken = default)
    {
        var domainObject =
            await m_entryPoint
                .LockRegister<IDomainObjectDemoObject>(parameters.Id)
                .GetRegister<IDomainObjectDemoObject>()
                .FindAsync<IDomainObjectDemoObject>(parameters.Id, cancellationToken)
                .ConfigureAwait(false);
        if (domainObject == null)
        {
            var workflowException = m_entryPoint.WorkflowExceptionPolicy.CreateDemoObjectNotFound(parameters.Id);

            throw workflowException;
        }

        await domainObject.UpdateAsync(parameters, cancellationToken).ConfigureAwait(false);

        var result = domainObject.GetInfo();

        return result;
    }

    public async ValueTask<DemoObjectInfo> DemoObjectCreateAsync(
        DemoObjectCreate parameters,
        CancellationToken cancellationToken = default)
    {
        var domainObject =
            await new DomainObjectDemoObject.Template(
                    parameters.Name,
                    parameters.Enabled)
                .NewAsync(m_entryPoint, cancellationToken)
                .ConfigureAwait(false);

        var result = domainObject.GetInfo();

        return result;
    }
}