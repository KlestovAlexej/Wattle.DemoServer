using Acme.DemoServer.Processing.Api.Common.Dtos.DemoObject;
using Acme.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;
using Acme.DemoServer.Processing.Model.Interfaces;
using Acme.Wattle.DomainObjects.Interfaces;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Acme.DemoServer.Processing.Model.Implements.ControllersServices;

public sealed class DemoObjectControllerService : IDemoObjectControllerService
{
    private readonly ICustomEntryPoint m_entryPoint;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // ReSharper disable once ConvertToPrimaryConstructor
    public DemoObjectControllerService(ICustomEntryPoint entryPoint)
    {
        m_entryPoint = entryPoint;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueTask<DemoObjectInfo> CreateAsync(
        DemoObjectCreate parameters,
        CancellationToken cancellationToken = default)
    {
        var result =
            m_entryPoint.CreateAndUsingUnitOfWorkAsync(
                (_, _) =>
                    m_entryPoint.Facade
                        .DemoObjectCreateAsync(
                            parameters,
                            cancellationToken),
                autoCommit: true,
                cancellationToken: cancellationToken);

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueTask<DemoObjectInfo> ReadAsync(
        long id,
        CancellationToken cancellationToken = default)
    {
        var result =
            m_entryPoint.CreateAndUsingUnitOfWorkAsync(
                (_, _) =>
                    m_entryPoint.Facade
                        .DemoObjectReadAsync(
                            id,
                            cancellationToken),
                autoCommit: true,
                cancellationToken: cancellationToken);

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueTask<DemoObjectInfo> UpdateAsync(
        DemoObjectUpdate parameters,
        CancellationToken cancellationToken = default)
    {
        var result =
            m_entryPoint.CreateAndUsingUnitOfWorkAsync(
                    (_, _) =>
                        m_entryPoint.Facade
                            .DemoObjectUpdateAsync(
                                parameters,
                                cancellationToken),
                    autoCommit: true,
                    cancellationToken: cancellationToken);

        return result;
    }
}