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
using ShtrihM.Wattle3.Mappers.Primitives;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObjectX;

public class DomainObjectRegisterDemoObjectX : DomainObjectRegisterWithContextWithAlternativeKeyStatelessDefault<IDomainObjectDemoObjectX, DemoObjectXIdentitiesService.AlternativeKey, long /* Group */, DemoObjectXDtoActual, IMapperDemoObjectX>, IDomainObjectRegisterDemoObjectX
{
    #region ProxyDomainObjectRegister

    private class ProxyDomainObjectRegister : AltProxyDomainObjectRegisterWithContextWithAlternativeKey<IDomainObjectDemoObjectX, DemoObjectXIdentitiesService.AlternativeKey, long /* Group */>, IDomainObjectRegisterDemoObjectX
    {
        public IDomainObjectDemoObjectX GetByName(
            string name)
        {
            var register = (IDomainObjectRegisterDemoObjectX)m_register;
            var result = register.GetByName(name);

            // Любой доменный объект полученный из реестра необходимо всегда регистрировать в локальном реестре.
            result = SafeTryRegister(result);

            // Поле Name изменяемое
            // Проверка объекта соответсвия критерию выборки т.к. он могбыть взят из локального реестра и не соответствует критерию выборки т.к. мог быть изменён до коммита UoW
            result = DoGetByName(result, name);

            return result;
        }

        public async ValueTask<IDomainObjectDemoObjectX> GetByNameAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            var register = (IDomainObjectRegisterDemoObjectX)m_register;
            var result = await register.GetByNameAsync(name, cancellationToken).ConfigureAwait(false);

            // Любой доменный объект полученный из реестра необходимо всегда регистрировать в локальном реестре.
            result = SafeTryRegister(result);

            // Поле Name изменяемое
            // Проверка объекта соответсвия критерию выборки т.к. он могбыть взят из локального реестра и не соответствует критерию выборки т.к. мог быть изменён до коммита UoW
            result = DoGetByName(result, name);

            return result;
        }

        public IEnumerable<IDomainObjectDemoObjectX> GetCollectionByNameSize(
            int size)
        {
            var register = (IDomainObjectRegisterDemoObjectX)m_register;

            // Любой доменный объект полученный из реестра необходимо всегда регистрировать в локальном реестре.
            var instances = DoForEach(register.GetCollectionByNameSize(size));

            foreach (var domainObject in instances)
            {
                // Поле Name изменяемое
                // Проверка объекта соответсвия критерию выборки т.к. он могбыть взят из локального реестра и не соответствует критерию выборки т.к. мог быть изменён до коммита UoW
                var result = DoGetByNameSize(domainObject, size);

                if (result == null)
                {
                    continue;
                }

                yield return result;
            }
        }

        public async IAsyncEnumerable<IDomainObjectDemoObjectX> GetCollectionByNameSizeAsync(
            int size,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            var register = (IDomainObjectRegisterDemoObjectX)m_register;

            // Любой доменный объект полученный из реестра необходимо всегда регистрировать в локальном реестре.
            var instances = DoForEachAsync(register.GetCollectionByNameSizeAsync(size, cancellationToken), cancellationToken);

            await foreach (var domainObject in instances.ConfigureAwait(false))
            {
                // Поле Name изменяемое
                // Проверка объекта соответсвия критерию выборки т.к. он могбыть взят из локального реестра и не соответствует критерию выборки т.к. мог быть изменён до коммита UoW
                var result = DoGetByNameSize(domainObject, size);

                if (result == null)
                {
                    continue;
                }

                yield return result;
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

        protected override void GetKey(IDomainObjectDemoObjectX domainObject, out DemoObjectXIdentitiesService.AlternativeKey keyEntry)
        {
            keyEntry = domainObject.GetKey();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private IDomainObjectDemoObjectX DoGetByName(
            IDomainObjectDemoObjectX demoObject,
            string name)
        {
            if (demoObject.Name == name)
            {
                return demoObject;
            }

            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private IDomainObjectDemoObjectX DoGetByNameSize(
            IDomainObjectDemoObjectX demoObject,
            int size)
        {
            if (demoObject.Name.Length == size)
            {
                return demoObject;
            }

            return null;
        }
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
            WellknownDomainObjectFields.DemoObjectX.NameCollection)
    // ReSharper disable once ConvertToPrimaryConstructor
    {
    }

    public IEnumerable<IDomainObjectDemoObjectX> GetCollectionByDemoGroup(
        long group)
    {
        throw new NotSupportedException("Реализация в прокси.");
    }

    [SuppressMessage("ReSharper", "AccessToDisposedClosure")]
    public IEnumerable<IDomainObjectDemoObjectX> GetCollectionByNameSize(
        int size)
    {
        var unitOfWork = (UnitOfWork)UnitOfWorkProvider.Instance;
        using var dbContext = unitOfWork.NewDbContext();
        var instances =
            GetObjectEnumerator(
                    () => dbContext.Demoobjectx
                        .Where(entity => entity.Name.Length == size)
                        .Select(entity => entity.ToMapperDto()))
                .Cast<IDomainObjectDemoObjectX>();

        foreach (var instance in instances)
        {
            yield return instance;
        }
    }

    [SuppressMessage("ReSharper", "AccessToDisposedClosure")]
    public async IAsyncEnumerable<IDomainObjectDemoObjectX> GetCollectionByNameSizeAsync(
        int size,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var unitOfWork = (UnitOfWork)UnitOfWorkProvider.Instance;
        await using var dbContext = await unitOfWork.NewDbContextAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
        var instances = GetObjectEnumeratorAsync(Selector, cancellationToken);

        await foreach (var instance in instances.ConfigureAwait(false))
        {
            yield return (IDomainObjectDemoObjectX)instance;
        }

        yield break;

        async IAsyncEnumerable<IMapperDto> Selector([EnumeratorCancellation] CancellationToken ct)
        {
            await foreach (var entity in dbContext.Demoobjectx
                               .Where(entity => entity.Name.Length == size)
                               .AsAsyncEnumerable()
                               .WithCancellation(ct)
                               .ConfigureAwait(false))
            {
                yield return entity.ToMapperDto();
            }
        }
    }

    [SuppressMessage("ReSharper", "AccessToDisposedClosure")]
    public IDomainObjectDemoObjectX GetByName(
        string name)
    {
        var unitOfWork = (UnitOfWork)UnitOfWorkProvider.Instance;
        using var dbContext = unitOfWork.NewDbContext();
        var result =
            Find(
                () => dbContext.Demoobjectx
                    .SingleOrDefault(entity => entity.Name == name)
                    .ToMapperDto());

        return (IDomainObjectDemoObjectX)result;
    }

    [SuppressMessage("ReSharper", "AccessToDisposedClosure")]
    public async ValueTask<IDomainObjectDemoObjectX> GetByNameAsync(
        string name,
        CancellationToken cancellationToken = default)
    {
        var unitOfWork = (UnitOfWork)UnitOfWorkProvider.Instance;
        await using var dbContext = await unitOfWork.NewDbContextAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
        var result =
            await FindAsync(
                async ct =>
                    (await dbContext.Demoobjectx
                        .SingleOrDefaultAsync(entity => entity.Name == name, cancellationToken: ct)
                        .ConfigureAwait(false))
                    .ToMapperDto(),
                cancellationToken);

        return (IDomainObjectDemoObjectX)result;
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

    protected override AltProxyDomainObjectRegisterWithContextWithAlternativeKey<IDomainObjectDemoObjectX, DemoObjectXIdentitiesService.AlternativeKey, long>
        DoCreateProxy()
    {
        var result = new ProxyDomainObjectRegister();

        return result;
    }
}