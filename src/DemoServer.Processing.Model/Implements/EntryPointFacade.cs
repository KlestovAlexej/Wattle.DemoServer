using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;
using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject;
using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObject;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.OpenTelemetry;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShtrihM.DemoServer.Processing.Model.Implements;

public class EntryPointFacade : IEntryPointFacade
{
    private static readonly SpanAttributes SpanAttributes;

    private readonly ICustomEntryPoint m_entryPoint;
    private readonly Tracer m_tracer;

    // ReSharper disable once NotAccessedField.Local
    private readonly ILogger m_logger;

    static EntryPointFacade()
    {
        SpanAttributes = new SpanAttributes()
            .AddModuleType<EntryPointFacade>();
    }

    public EntryPointFacade(
        ICustomEntryPoint entryPoint,
        Tracer tracer,
        ILogger logger)
    {
        m_entryPoint = entryPoint ?? throw new ArgumentNullException(nameof(entryPoint));
        m_tracer = tracer;
        m_logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async ValueTask<DemoObjectInfo> DemoObjectReadAsync(
        long id,
        CancellationToken cancellationToken = default)
    {
        using var mainSpan = m_tracer?.StartActiveSpan(
            nameof(DemoObjectReadAsync),
            initialAttributes: SpanAttributes,
            kind: SpanKind.Server);

        var unitOfWork = m_entryPoint.CurrentUnitOfWork;
        var registerDemoObject = unitOfWork.Registers.GetRegister(WellknownDomainObjects.DemoObject);
        var demoObject = await registerDemoObject
            .FindAsync<IDomainObjectDemoObject>(id, cancellationToken)
            .ConfigureAwait(false);
        if (demoObject == null)
        {
            var workflowException = m_entryPoint.WorkflowExceptionPolicy.CreateDemoObjectNotFound(id);

            throw workflowException;
        }

        var result = demoObject.GetInfo();

        return result;
    }

    public async ValueTask<DemoObjectInfo> DemoObjectUpdateAsync(
        DemoObjectUpdate parameters,
        CancellationToken cancellationToken = default)
    {
        using var mainSpan = m_tracer?.StartActiveSpan(
            nameof(DemoObjectUpdateAsync),
            initialAttributes: SpanAttributes,
            kind: SpanKind.Server);

        if (parameters == null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        m_entryPoint.UnitOfWorkLocks.DemoObject.Register(parameters.Id);

        var registerDemoObject = m_entryPoint.CurrentUnitOfWork.Registers.GetRegister(WellknownDomainObjects.DemoObject);
        var demoObject = await registerDemoObject
            .FindAsync<IDomainObjectDemoObject>(parameters.Id, cancellationToken)
            .ConfigureAwait(false);
        if (demoObject == null)
        {
            var workflowException = m_entryPoint.WorkflowExceptionPolicy.CreateDemoObjectNotFound(parameters.Id);

            throw workflowException;
        }

        await demoObject.UpdateAsync(parameters, cancellationToken).ConfigureAwait(false);

        var result = demoObject.GetInfo();

        return result;
    }

    public async ValueTask<DemoObjectInfo> DemoObjectCreateAsync(
        DemoObjectCreate parameters,
        CancellationToken cancellationToken = default)
    {
        using var mainSpan = m_tracer?.StartActiveSpan(
            nameof(DemoObjectCreateAsync),
            initialAttributes: SpanAttributes,
            kind: SpanKind.Server);

        if (parameters == null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        var demoObject = await new DomainObjectDemoObject.Template(
                parameters.Name,
                parameters.Enabled)
            .NewAsync(m_entryPoint, cancellationToken)
            .ConfigureAwait(false);

        var result = demoObject.GetInfo();

        return result;
    }
}