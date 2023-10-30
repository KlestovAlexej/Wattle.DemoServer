using System;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters.IdentitiesServices;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using ShtrihM.DemoServer.Processing.Model.Implements;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObjectX;

public class DomainObjectRegisterDemoObjectX : DomainObjectRegisterWithContextWithAlternativeKeyStatelessDefault<IDomainObjectDemoObjectX, DemoObjectXIdentitiesService.AlternativeKey, long /* Group */, DemoObjectXDtoActual, IMapperDemoObjectX>
{
    #region ProxyDomainObjectRegister

    [SuppressMessage("ReSharper", "AccessToDisposedClosure")]
    private class ProxyDomainObjectRegister : AltProxyDomainObjectRegisterWithContextWithAlternativeKey<IDomainObjectDemoObjectX, DemoObjectXIdentitiesService.AlternativeKey, long /* Group */>, IDomainObjectRegisterDemoObjectX
    {
        public ProxyDomainObjectRegister() : base(DecodeDomainObject)
        // ReSharper disable once ConvertToPrimaryConstructor
        {
        }

        #region IDomainObjectRegisterDemoObject

        public IDomainObjectDemoObjectX GetByName(
            string name)
        {
            var result = DoFind(
                entity => entity.Name == name,
                domainObject => domainObject.Name == name);

            return result;
        }

        public ValueTask<IDomainObjectDemoObjectX> GetByNameAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            var result =
                DoFindAsync(
                    entity => entity.Name == name,
                    domainObject => domainObject.Name == name,
                    cancellationToken);

            return result;
        }

        public IEnumerable<IDomainObjectDemoObjectX> GetCollectionByNameSize(
            int size)
        {
            var result =
                DoGetObjectEnumerator(
                    entity => entity.Name.Length == size,
                    domainObject => domainObject.Name.Length == size);

            return result;
        }

        public IAsyncEnumerable<IDomainObjectDemoObjectX> GetCollectionByNameSizeAsync(
            int size,
            CancellationToken cancellationToken = default)
        {
            var result =
                DoGetObjectEnumeratorAsync(
                    entity => entity.Name.Length == size,
                    domainObject => domainObject.Name.Length == size,
                    cancellationToken);

            return result;
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

        #region Common

        private async IAsyncEnumerable<IDomainObjectDemoObjectX> DoGetObjectEnumeratorAsync(
            Expression<Func<Demoobjectx, bool>> dtoSelector,
            Func<IDomainObjectDemoObjectX, bool> domainObjectSelector = null,
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
                                .Where(dtoSelector)
                                .Select(entity => entity.ToMapperDto())
                                .AsAsyncEnumerable(),
                        (domainObjects, _) =>
                            (domainObjectSelector != null)
                                ? domainObjects
                                    .Cast<IDomainObjectDemoObjectX>()
                                    .Where(domainObjectSelector)
                                    .ToAsyncEnumerable()
                                : null,
                        cancellationToken)
                    .Cast<IDomainObjectDemoObjectX>()
                    .ConfigureAwait(false);

            await foreach (var instance in instances)
            {
                yield return instance;
            }
        }

        private IEnumerable<IDomainObjectDemoObjectX> DoGetObjectEnumerator(
            Expression<Func<Demoobjectx, bool>> dtoSelector,
            Func<IDomainObjectDemoObjectX, bool> domainObjectSelector = null)
        {
            var unitOfWork = (UnitOfWork)UnitOfWorkProvider.Instance;
            using var dbContext = unitOfWork.NewDbContext();
            var instances =
                GetObjectEnumerator(
                        () =>
                            dbContext.Demoobjectx
                                .Where(dtoSelector)
                                .Select(entity => entity.ToMapperDto()),
                        (domainObjectSelector != null)
                            ? domainObjects =>
                                domainObjects.Cast<IDomainObjectDemoObjectX>()
                                    .Where(domainObjectSelector)
                            : null)
                    .Cast<IDomainObjectDemoObjectX>();

            foreach (var instance in instances)
            {
                yield return instance;
            }
        }

        private IDomainObjectDemoObjectX DoFind(
            Expression<Func<Demoobjectx, bool>> dtoSelector,
            Func<IDomainObjectDemoObjectX, bool> domainObjectSelector = null)
        {
            var unitOfWork = (UnitOfWork)UnitOfWorkProvider.Instance;
            using var dbContext = unitOfWork.NewDbContext();
            var result =
                Find(() =>
                        dbContext.Demoobjectx
                            .FirstOrDefault(dtoSelector)
                            ?.ToMapperDto(),
                    (domainObjectSelector != null)
                        ? domainObjects =>
                            domainObjects.Cast<IDomainObjectDemoObjectX>()
                                .FirstOrDefault(domainObjectSelector)
                        : null);

            return (IDomainObjectDemoObjectX)result;
        }

        private async ValueTask<IDomainObjectDemoObjectX> DoFindAsync(
            Expression<Func<Demoobjectx, bool>> dtoSelector,
            Func<IDomainObjectDemoObjectX, bool> domainObjectSelector = null,
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
                                .FirstOrDefaultAsync(dtoSelector, cancellationToken: ct)
                                .ConfigureAwait(false))
                            ?.ToMapperDto(),
                        (domainObjectSelector != null)
                            ? async (domainObjects, ct) =>
                                await domainObjects.Cast<IDomainObjectDemoObjectX>()
                                    .ToAsyncEnumerable()
                                    .FirstOrDefaultAsync(domainObjectSelector, cancellationToken: ct)
                                    .ConfigureAwait(false)
                            : null,
                        cancellationToken)
                    .ConfigureAwait(false);

            return (IDomainObjectDemoObjectX)result;
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
            entryPoint.CommitVerifyingFactory,
            () => new ProxyDomainObjectRegister())
    // ReSharper disable once ConvertToPrimaryConstructor
    {
    }

    private static (DemoObjectXIdentitiesService.AlternativeKey, long) DecodeDomainObject(IDomainObject domainObject)
    {
        var instance = (IDomainObjectDemoObjectX)domainObject;
        var result = (instance.GetKey(), instance.Group);

        return result;
    }
}
