using System;
using Acme.DemoServer.Processing.Common;
using Acme.DemoServer.Processing.Generated.Interface;
using Acme.DemoServer.Processing.Model.Interfaces;
using Acme.Wattle.DomainObjects.DomainObjectsRegisters.IdentitiesServices;
using Acme.Wattle.DomainObjects.Interfaces;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Acme.DemoServer.Processing.Model.Implements;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Trace;
using Acme.DemoServer.Processing.DataAccess.PostgreSql.EfModels;
using Acme.Wattle.Utils;

namespace Acme.DemoServer.Processing.Model.DomainObjects.DemoObjectX;

public sealed class DomainObjectRegisterDemoObjectX : DomainObjectRegisterWithContextWithAlternativeKeyStatelessDefault<IDomainObjectDemoObjectX, DomainObjectDemoObjectX.AlternativeKey, long /* Group */, DemoObjectXDtoActual, IMapperDemoObjectX>
{
    #region ProxyDomainObjectRegister

    [SuppressMessage("ReSharper", "AccessToDisposedClosure")]
    private class ProxyDomainObjectRegister : AltProxyDomainObjectRegisterWithContextWithAlternativeKey<IDomainObjectDemoObjectX, DomainObjectDemoObjectX.AlternativeKey, long /* Group */>, IDomainObjectRegisterDemoObjectX
    {
        private ICustomEntryPoint EntryPoint
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (ICustomEntryPoint)UnitOfWorkProvider.Instance.EntryPoint;
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

        public ValueTask<IDomainObjectDemoObjectX?> GetByNameAsync(
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
            using var span = EntryPoint.Tracer?.StartActiveSpan(nameof(GetCollectionByDemoGroup), SpanKind.Server);

            var result = GetEnumeratorByContext(group);

            if (span != null)
            {
                result = result.ToList();
            }

            return result;
        }

        public IAsyncEnumerable<IDomainObjectDemoObjectX> GetCollectionByDemoGroupAsync(
            long group,
            CancellationToken cancellationToken = default)
        {
            using var span = EntryPoint.Tracer?.StartActiveSpan(nameof(GetCollectionByDemoGroupAsync), SpanKind.Server);

            var result = GetEnumeratorByContextAsync(group, cancellationToken);

            if (span != null)
            {
                result = result.ToListAsync(cancellationToken: cancellationToken).SafeGetResult().ToAsyncEnumerable();
            }

            return result;
        }

        public IDomainObjectDemoObjectX? FindByDemoAlternativeKey(
            DomainObjectDemoObjectX.AlternativeKey alternativeKey)
        {
            using var span = EntryPoint.Tracer?.StartActiveSpan(nameof(FindByDemoAlternativeKey), SpanKind.Server);

            var result = FindByKey(alternativeKey);

            return result;
        }

        public ValueTask<IDomainObjectDemoObjectX?> FindByDemoAlternativeKeyAsync(
            DomainObjectDemoObjectX.AlternativeKey alternativeKey,
            CancellationToken cancellationToken = default)
        {
            using var span = EntryPoint.Tracer?.StartActiveSpan(nameof(FindByDemoAlternativeKeyAsync), SpanKind.Server);

            var result = FindByKeyAsync(alternativeKey, cancellationToken);

            if (span != null)
            {
                result = ValueTask.FromResult(result.SafeGetResult());
            }

            return result;
        }

        #endregion

        #region Common

        private async IAsyncEnumerable<IDomainObjectDemoObjectX> DoGetObjectEnumeratorAsync(
            Expression<Func<Demoobjectx, bool>> dtoSelector,
            Func<IDomainObjectDemoObjectX, bool>? domainObjectSelector = null,
            [EnumeratorCancellation] CancellationToken cancellationToken = default,
            [CallerMemberName] string? caller = null)
        {
            using var span = EntryPoint.Tracer?.StartActiveSpan(caller!, SpanKind.Server);

            var unitOfWork = (UnitOfWork)UnitOfWorkProvider.Instance;
            await using var dbContext =
                await unitOfWork.NewDbContextAsync(cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            var instances =
                GetObjectEnumeratorAsync(
                        _ =>
                            dbContext.Demoobjectx
                                .Where(dtoSelector)
                                .Select(entity => entity.ToMapperDto(EntryPoint.AutoMapper))
                                .AsAsyncEnumerable(),
                        (domainObjectSelector != null)
                            ? (domainObjects, _) =>
                                domainObjects
                                    .Cast<IDomainObjectDemoObjectX>()
                                    .Where(domainObjectSelector)
                                    .ToAsyncEnumerable()
                            : null,
                        cancellationToken)
                    .Cast<IDomainObjectDemoObjectX>();

            if (span != null)
            {
                instances = instances.ToListAsync(cancellationToken: cancellationToken).SafeGetResult()
                    .ToAsyncEnumerable();
            }

            await foreach (var instance in instances.ConfigureAwait(false))
            {
                yield return instance;
            }
        }

        private IEnumerable<IDomainObjectDemoObjectX> DoGetObjectEnumerator(
            Expression<Func<Demoobjectx, bool>> dtoSelector,
            Func<IDomainObjectDemoObjectX, bool>? domainObjectSelector = null,
            [CallerMemberName] string? caller = null)
        {
            using var span = EntryPoint.Tracer?.StartActiveSpan(caller!, SpanKind.Server);

            var unitOfWork = (UnitOfWork)UnitOfWorkProvider.Instance;
            using var dbContext = unitOfWork.NewDbContext();
            var instances =
                GetObjectEnumerator(
                        () =>
                            dbContext.Demoobjectx
                                .Where(dtoSelector)
                                .Select(entity => entity.ToMapperDto(EntryPoint.AutoMapper)),
                        (domainObjectSelector != null)
                            ? domainObjects =>
                                domainObjects.Cast<IDomainObjectDemoObjectX>()
                                    .Where(domainObjectSelector)
                            : null)
                    .Cast<IDomainObjectDemoObjectX>();

            if (span != null)
            {
                instances = instances.ToList();
            }

            foreach (var instance in instances)
            {
                yield return instance;
            }
        }

        private IDomainObjectDemoObjectX DoFind(
            Expression<Func<Demoobjectx, bool>> dtoSelector,
            Func<IDomainObjectDemoObjectX, bool>? domainObjectSelector = null,
            [CallerMemberName] string? caller = null)
        {
            using var span = EntryPoint.Tracer?.StartActiveSpan(caller!, SpanKind.Server);

            var unitOfWork = (UnitOfWork)UnitOfWorkProvider.Instance;
            using var dbContext = unitOfWork.NewDbContext();
            var result =
                Find(() =>
                        dbContext.Demoobjectx
                            .FirstOrDefault(dtoSelector)
                            ?.ToMapperDto(EntryPoint.AutoMapper),
                    (domainObjectSelector != null)
                        ? domainObjects =>
                            domainObjects.Cast<IDomainObjectDemoObjectX>()
                                .FirstOrDefault(domainObjectSelector)
                        : null);

            return (IDomainObjectDemoObjectX)result!;
        }

        private async ValueTask<IDomainObjectDemoObjectX?> DoFindAsync(
            Expression<Func<Demoobjectx, bool>> dtoSelector,
            Func<IDomainObjectDemoObjectX, bool>? domainObjectSelector = null,
            CancellationToken cancellationToken = default,
            [CallerMemberName] string? caller = null)
        {
            using var span = EntryPoint.Tracer?.StartActiveSpan(caller!, SpanKind.Server);

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
                            ?.ToMapperDto(EntryPoint.AutoMapper),
                        (domainObjectSelector != null)
                            ? async (domainObjects, ct) =>
                                await domainObjects.Cast<IDomainObjectDemoObjectX>()
                                    .ToAsyncEnumerable()
                                    .FirstOrDefaultAsync(domainObjectSelector, cancellationToken: ct)
                                    .ConfigureAwait(false)
                            : null,
                        cancellationToken)
                    .ConfigureAwait(false);

            return (IDomainObjectDemoObjectX)result!;
        }

        #endregion
    }

    #endregion

    // ReSharper disable once ConvertToPrimaryConstructor
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
            entryPoint.Context.UnitOfWorkCommitVerifyingFactory,
            () => new ProxyDomainObjectRegister())
    {
    }

    private static (DomainObjectDemoObjectX.AlternativeKey, long) DecodeDomainObject(IDomainObject domainObject)
    {
        var instance = (IDomainObjectDemoObjectX)domainObject;
        var result = (instance.GetKey(), instance.Group);

        return result;
    }
}
