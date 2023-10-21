using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;
using ShtrihM.DemoServer.Processing.Model.Implements;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.IdentitiesServices;

#pragma warning disable IDE0290

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObjectX;

public sealed class DemoObjectXIdentitiesService : BaseIdentitiesWithContextWithAlternativeKeyService<DemoObjectXAlternativeKey, long /* Group */>
{
    private readonly ICustomEntryPoint m_entryPoint;

    public DemoObjectXIdentitiesService(ICustomEntryPoint entryPoint)
        : base(
            entryPoint,
            entryPoint.ExceptionPolicy,
            entryPoint.TimeService,
            entryPoint.SystemSettings.DomainObjectRegistersSettings.Value.InitializeEmergencyTimeout.Value,
            new Guid("CD1F66C3-9E12-47B4-B028-8D36BEC6D7EA"),
            $"Реестр идентити объектов '{WellknownDomainObjects.GetDisplayName(WellknownDomainObjects.DemoObjectX)}'",
            $"Реестр идентити объектов '{WellknownDomainObjects.GetDisplayName(WellknownDomainObjects.DemoObjectX)}'",
            entryPoint.LoggerFactory.CreateLogger<DemoObjectXIdentitiesService>(),
            new LocksPoolAsync<long>(
                new Guid("75738FB6-ABBB-4EEA-950F-D456EF3A4674"),
                $"Пул лок-объектов реестра идентити объектов '{WellknownDomainObjects.GetDisplayName(WellknownDomainObjects.DemoObjectX)}'",
                $"Пул лок-объектов реестра идентити объектов '{WellknownDomainObjects.GetDisplayName(WellknownDomainObjects.DemoObjectX)}'",
                entryPoint.TimeService),
            new LocksPoolAsync<DemoObjectXAlternativeKey>(
                new Guid("7CD9ECD7-49C0-42EB-ABA6-B915F6D0FDB5"),
                $"Пул лок-объектов альтернативных ключей реестра идентити объектов '{WellknownDomainObjects.GetDisplayName(WellknownDomainObjects.DemoObjectX)}'",
                $"Пул лок-объектов альтернативных ключей реестра идентити объектов '{WellknownDomainObjects.GetDisplayName(WellknownDomainObjects.DemoObjectX)}'",
                entryPoint.TimeService),
            new LocksPoolAsync<long>(
                new Guid("A92F4C35-C29F-4D17-82C7-E3B5DB284773"),
                $"Пул лок-объектов контекстов реестра идентити объектов '{WellknownDomainObjects.GetDisplayName(WellknownDomainObjects.DemoObjectX)}'",
                $"Пул лок-объектов контекстов реестра идентити объектов '{WellknownDomainObjects.GetDisplayName(WellknownDomainObjects.DemoObjectX)}'",
                entryPoint.TimeService))
    {
        m_entryPoint = entryPoint;
    }

    protected override IEnumerable<(long Identity, DemoObjectXAlternativeKey Key, long Context)> DoGetIdentitiesFromMaxToMin(long? maxIdentity)
    {
        var unitOfWork = (UnitOfWork)m_entryPoint.UnitOfWorkProvider.Instance;
        using var dbContext = unitOfWork.NewDbContext(false);

        IOrderedQueryable<Demoobjectx> query;
        if (maxIdentity.HasValue)
        {
            var currentMaxIdentity = maxIdentity.Value;
            query = dbContext
                .Demoobjectx
                .Where(a => a.Id > currentMaxIdentity)
                .OrderBy(a => a.Id);
        }
        else
        {
            query = dbContext
                .Demoobjectx
                .OrderBy(a => a.Id);
        }

        var identities =
            query.Select(
                a => new
                {
                    a.Id,
                    a.Key1,
                    a.Key2,
                    a.Group,
                });

        foreach (var identity in identities)
        {
            yield return (identity.Id, new DemoObjectXAlternativeKey(identity.Key1, identity.Key2), identity.Group);
        }
    }
}