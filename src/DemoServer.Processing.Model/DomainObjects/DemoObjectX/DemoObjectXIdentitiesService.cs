using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Model.Implements;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters.IdentitiesServices;
using ShtrihM.Wattle3.DomainObjects.IdentitiesServices;
using ShtrihM.Wattle3.DomainObjects.Interfaces;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObjectX;

public sealed class DemoObjectXIdentitiesService : BaseIdentitiesWithContextWithAlternativeKeyService<DemoObjectXIdentitiesService.AlternativeKeyEntry, long /* Group */>
{
    #region AlternativeKeyEntry - Альтернативный ключ объекта X

    [SuppressMessage("ReSharper", "NotAccessedPositionalProperty.Global")]
    public readonly record struct AlternativeKeyEntry(
        [property: AlternativeKeyIndex(WellknownDomainObjectFields.DemoObjectX.IndexAlternateKeyValue1)] Guid Key1,
        [property: AlternativeKeyIndex(WellknownDomainObjectFields.DemoObjectX.IndexAlternateKeyValue2)] string Key2);

    #endregion

    private readonly IUnitOfWorkProvider m_unitOfWorkProvider;

    private DemoObjectXIdentitiesService(ICustomEntryPoint entryPoint)
        : base(
            entryPoint.Context,
            new Guid("CD1F66C3-9E12-47B4-B028-8D36BEC6D7EA"))
    {
        m_unitOfWorkProvider = entryPoint.UnitOfWorkProvider;
    }

    public static DemoObjectXIdentitiesService New(ICustomEntryPoint entryPoint)
    {
        var result =
            entryPoint.SystemSettings.DomainObjectRegistersSettings.Value.UseIdentitiesServices.Value
                ? new DemoObjectXIdentitiesService(entryPoint)
                : null;

        return result;
    }

    protected override IEnumerable<(long Identity, AlternativeKeyEntry Key, long Context)> DoGetIdentitiesFromMaxToMin(long? maxIdentity)
    {
        var unitOfWork = (UnitOfWork)m_unitOfWorkProvider.Instance;
        using var dbContext = unitOfWork.NewDbContext(false);
        var query = BaseIdentitiesService.GetIdentitiesFromMaxToMin(maxIdentity, dbContext.Demoobjectx);
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
            yield return (identity.Id, new AlternativeKeyEntry(identity.Key1, identity.Key2), identity.Group);
        }
    }
}
