using System;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters.IdentitiesServices;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using ShtrihM.DemoServer.Processing.Model.DomainObjects.Common;
using ShtrihM.DemoServer.Processing.Model.Implements;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObjectX;

public class DomainObjectRegisterDemoObjectX : DomainObjectRegisterWithContextWithAlternativeKeyStatelessDefault<IDomainObjectDemoObjectX, DemoObjectXIdentitiesService.AlternativeKey, long /* Group */, DemoObjectXDtoActual, IMapperDemoObjectX>, IDomainObjectRegisterDemoObjectX
{
    #region ProxyDomainObjectRegister

    [SuppressMessage("ReSharper", "AccessToDisposedClosure")]
    private class ProxyDomainObjectRegister : AltProxyDomainObjectRegisterWithContextWithAlternativeKey<IDomainObjectDemoObjectX, DemoObjectXIdentitiesService.AlternativeKey, long /* Group */>, IDomainObjectRegisterDemoObjectX
    {
        public ProxyDomainObjectRegister()
            : base(DecodeDomainObject)
        {
        }

        #region IDomainObjectRegisterDemoObject

        public IDomainObjectDemoObjectX GetByName(
            string name)
        {
            var unitOfWork = (UnitOfWork)UnitOfWorkProvider.Instance;
            using var dbContext = unitOfWork.NewDbContext();
            var result =
                Find(() =>
                        dbContext.Demoobjectx
                            .FirstOrDefault(entity => entity.Name == name)
                            .ToMapperDto(),
                    domainObjects =>
                        domainObjects.Cast<IDomainObjectDemoObjectX>()
                            .FirstOrDefault(domainObject => domainObject.Name == name));

            return (IDomainObjectDemoObjectX)result;
        }

        public async ValueTask<IDomainObjectDemoObjectX> GetByNameAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            var unitOfWork = (UnitOfWork)UnitOfWorkProvider.Instance;
            await using var dbContext =
                await unitOfWork.NewDbContextAsync(cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

            var result =
                await FindAsync(
                        async ct =>
                            (await dbContext.Demoobjectx
                                .FirstOrDefaultAsync(entity => entity.Name == name, cancellationToken: ct)
                                .ConfigureAwait(false))
                            .ToMapperDto(),
                        async (domainObjects, ct) =>
                            await domainObjects.Cast<IDomainObjectDemoObjectX>()
                                .ToAsyncEnumerable()
                                .FirstOrDefaultAsync(entity => entity.Name == name, cancellationToken: ct)
                                .ConfigureAwait(false),
                        cancellationToken)
                    .ConfigureAwait(false);

            return (IDomainObjectDemoObjectX)result;
        }

        public IEnumerable<IDomainObjectDemoObjectX> GetCollectionByNameSize(
            int size)
        {
            var unitOfWork = (UnitOfWork)UnitOfWorkProvider.Instance;
            using var dbContext = unitOfWork.NewDbContext();
            var instances =
                GetObjectEnumerator(
                        () =>
                            dbContext.Demoobjectx
                                .Where(entity => entity.Name.Length == size)
                                .Select(entity => entity.ToMapperDto()),
                        domainObjects =>
                            domainObjects.Cast<IDomainObjectDemoObjectX>()
                                .Where(domainObject => domainObject.Name.Length == size))
                    .Cast<IDomainObjectDemoObjectX>();

            foreach (var instance in instances)
            {
                yield return instance;
            }
        }

        public async IAsyncEnumerable<IDomainObjectDemoObjectX> GetCollectionByNameSizeAsync(
            int size,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            var unitOfWork = (UnitOfWork)UnitOfWorkProvider.Instance;
            await using var dbContext =
                await unitOfWork.NewDbContextAsync(cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            var instances =
                GetObjectEnumeratorAsync(
                        _ =>
                            dbContext.Demoobjectx
                                .Where(entity => entity.Name.Length == size)
                                .Select(entity => entity.ToMapperDto())
                                .AsAsyncEnumerable(),
                        (domainObjects, ct) =>
                            domainObjects
                                .Cast<IDomainObjectDemoObjectX>()
                                .Where(domainObject => domainObject.Name.Length == size)
                                .ToAsyncEnumerable(),
                        cancellationToken)
                    .ConfigureAwait(false);

            await foreach (var instance in instances)
            {
                yield return (IDomainObjectDemoObjectX)instance;
            }
        }

        public IEnumerable<IDomainObjectDemoObjectX> GetCollectionByDemoGroup(
            long group)
        {
            var result = GetEnumeratorByContext(group);

            return result;
        }

        public IAsyncEnumerable<IDomainObjectDemoObjectX> GetCollectionByDemoGroupAsync(
            long group,
            CancellationToken cancellationToken = default)
        {
            var result = GetEnumeratorByContextAsync(group, cancellationToken);

            return result;
        }

        public IDomainObjectDemoObjectX FindByDemoAlternativeKey(
            DemoObjectXIdentitiesService.AlternativeKey alternativeKey)
        {
            var result = FindByKey(alternativeKey);

            return result;
        }

        public ValueTask<IDomainObjectDemoObjectX> FindByDemoAlternativeKeyAsync(
            DemoObjectXIdentitiesService.AlternativeKey alternativeKey,
            CancellationToken cancellationToken = default)
        {
            var result = FindByKeyAsync(alternativeKey, cancellationToken);

            return result;
        }

        #endregion
    }

    #endregion

    public DomainObjectRegisterDemoObjectX(
        ICustomEntryPoint entryPoint,
        IDomainObjectDataMapper dataMapper,
        IDomainObjectDataActivator dataActivator,
        IDomainObjectActivator activator)
        : base(
            entryPoint.Context,
            dataMapper,
            dataActivator,
            activator,
            entryPoint.SystemSettings.DomainObjectRegistersSettings.Value.MemoryCacheDemoObjectX.Value,
            DemoObjectXIdentitiesService.New(entryPoint),
            WellknownDomainObjectFields.DemoObjectX.NameAlternateKey,
            WellknownDomainObjectFields.DemoObjectX.NameCollection,
            DecodeDomainObject,
            /*
             * !!! ВАЖНО !!!
             *
             * Не использовать стратегию ICustomEntryPoint.CommitVerifyingFactory - проверка существования объекта в БД по идентити.
             * Это не безопасно для надёжной работы логики так как объект удаляемый.
             *
             * Если указать null, то используется стратегия IUnitOfWork.CommitVerifying - она использует неудаляемый объект ChangeTracker для проверки результата исполнения IUnitOfWork.
             */
            null,
            () => new ProxyDomainObjectRegister())
    {
    }

    private static (DemoObjectXIdentitiesService.AlternativeKey, long) DecodeDomainObject(IDomainObject domainObject)
    {
        var instance = (IDomainObjectDemoObjectX)domainObject;
        var result = DomainObjectDemoObjectX.Decode(instance);

        return result;
    }

    #region IDomainObjectRegisterDemoObjectX

    public IEnumerable<IDomainObjectDemoObjectX> GetCollectionByDemoGroup(
        long group)
    {
        throw new NotSupportedException("Реализация в прокси.");
    }

    public IEnumerable<IDomainObjectDemoObjectX> GetCollectionByNameSize(
        int size)
    {
        throw new NotSupportedException("Реализация в прокси.");
    }

    public IAsyncEnumerable<IDomainObjectDemoObjectX> GetCollectionByNameSizeAsync(
        int size,
        CancellationToken cancellationToken = default)
    {
        throw new NotSupportedException("Реализация в прокси.");
    }

    public IDomainObjectDemoObjectX GetByName(string name)
    {
        throw new NotSupportedException("Реализация в прокси.");
    }

    public ValueTask<IDomainObjectDemoObjectX> GetByNameAsync(
        string name,
        CancellationToken cancellationToken = default)
    {
        throw new NotSupportedException("Реализация в прокси.");
    }

    public IAsyncEnumerable<IDomainObjectDemoObjectX> GetCollectionByDemoGroupAsync(
        long group,
        CancellationToken cancellationToken = default)
    {
        throw new NotSupportedException("Реализация в прокси.");
    }

    public IDomainObjectDemoObjectX FindByDemoAlternativeKey(
        DemoObjectXIdentitiesService.AlternativeKey alternativeKey)
    {
        throw new NotSupportedException("Реализация в прокси.");
    }

    public ValueTask<IDomainObjectDemoObjectX> FindByDemoAlternativeKeyAsync(
        DemoObjectXIdentitiesService.AlternativeKey alternativeKey,
        CancellationToken cancellationToken = default)
    {
        throw new NotSupportedException("Реализация в прокси.");
    }

    #endregion
}