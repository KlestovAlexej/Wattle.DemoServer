using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject;
using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;
using System.Threading;
using System.Threading.Tasks;

namespace ShtrihM.DemoServer.Processing.Model.Interfaces;

public interface IEntryPointFacade
{
    ValueTask<DemoObjectInfo> DemoObjectCreateAsync(
        DemoObjectCreate parameters,
        CancellationToken cancellationToken = default);

    ValueTask<DemoObjectInfo> DemoObjectReadAsync(
        long id,
        CancellationToken cancellationToken = default);

    ValueTask<DemoObjectInfo> DemoObjectUpdateAsync(
        DemoObjectUpdate parameters,
        CancellationToken cancellationToken = default);
}