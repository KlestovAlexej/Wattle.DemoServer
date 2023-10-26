using System;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorkLocks;
using ShtrihM.Wattle3.Utils;

namespace ShtrihM.DemoServer.Processing.Model.Implements.UnitOfWorkLocks;

public class UnitOfWorkLocksHubTyped : IDisposable
{
    public UnitOfWorkLocksHubTyped(ICustomEntryPoint entryPoint)
    {
        if (entryPoint == null)
        {
            throw new ArgumentNullException(nameof(entryPoint));
        }

        Hub = new UnitOfWorkLocksHub(entryPoint);
        Actions = new(Hub);

        var unitOfWorkProvider = entryPoint.UnitOfWorkProvider;
        var unitOfWorkLocks = () => ((UnitOfWork)unitOfWorkProvider.Instance).CurrentLocksGetOrCreate;

        UpdateDemoObject = new(
            Hub,
            WellknownCommonInfrastructureMonitors.LocksUpdateDemoObject,
            WellknownDomainObjects.DemoObject,
            unitOfWorkLocks);

        UpdateDemoObjectX = new(
            Hub,
            WellknownCommonInfrastructureMonitors.LocksUpdateDemoObjectX,
            WellknownDomainObjects.DemoObjectX,
            unitOfWorkLocks);
    }

    public IUnitOfWorkLocksHub Hub { get; private set; }
    public readonly UnitOfWorkLocksActions Actions;
    public readonly DomainObjectUnitOfWorkLocks UpdateDemoObject;
    public readonly DomainObjectUnitOfWorkLocks UpdateDemoObjectX;

    public void Dispose()
    {
        var temp = Hub;
        Hub = null;
        temp.SilentDispose();

        GC.SuppressFinalize(this);
    }
}