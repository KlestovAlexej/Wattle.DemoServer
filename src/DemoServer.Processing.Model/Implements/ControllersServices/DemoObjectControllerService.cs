using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject;
using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShtrihM.DemoServer.Processing.Model.Implements.ControllersServices;

public class DemoObjectControllerService : IDemoObjectControllerService
{
    private readonly ICustomEntryPoint m_entryPoint;

    public DemoObjectControllerService(ICustomEntryPoint entryPoint)
    {
        m_entryPoint = entryPoint ?? throw new ArgumentNullException(nameof(entryPoint));
    }

    public async ValueTask<DemoObjectInfo> CreateAsync(
        DemoObjectCreate parameters,
        CancellationToken cancellationToken = default)
    {
        if (parameters == null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        var result =
            await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
                    async (_, _) =>
                    await m_entryPoint.Facade
                    .DemoObjectCreateAsync(
                        parameters,
                        cancellationToken)
                    .ConfigureAwait(false),
                    autoCommit: true,
                    cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        return result;
    }

    public async ValueTask<DemoObjectInfo> ReadAsync(
        long id,
        CancellationToken cancellationToken = default)
    {
        var result =
            await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
                    async (_, _) =>
                        await m_entryPoint.Facade
                            .DemoObjectReadAsync(
                                id,
                                cancellationToken)
                            .ConfigureAwait(false),
                    autoCommit: true,
                    cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        return result;
    }

    public async ValueTask<DemoObjectInfo> UpdateAsync(
        DemoObjectUpdate parameters,
        CancellationToken cancellationToken = default)
    {
        if (parameters == null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        var result =
            await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
                    async (_, _) =>
                        await m_entryPoint.Facade
                            .DemoObjectUpdateAsync(
                                parameters,
                                cancellationToken)
                            .ConfigureAwait(false),
                    autoCommit: true,
                    cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        return result;
    }
}