using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.DemoServer.Processing.Tests.Model.Environment;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Testing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShtrihM.DemoServer.Processing.Api.Common;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObjectX;
using ShtrihM.DemoServer.Processing.Model.Implements;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.Mappers.Primitives;
using ShtrihM.Wattle3.Utils;
using ShtrihM.Wattle3.DomainObjects.IdentitiesServices;

namespace ShtrihM.DemoServer.Processing.Tests.Model;

[TestFixture]
[SuppressMessage("ReSharper", "AccessToDisposedClosure")]
public class TestsDomainObjectX : BaseTestsDomainObjects
{
    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    [Description("Выборка доменных обектов с использованием Entity Framework")]
    public void Test_EntityFramework()
    {
        var template1 =
            new DomainObjectDemoObjectX.Template(
                "Name1",
                true,
                new Guid("6457CCA1-4217-4D47-B057-9668278FE290"),
                "Key21",
                1);
        var template2 =
            new DomainObjectDemoObjectX.Template(
                "Name2",
                true,
                new Guid("03B5D8E7-7528-4EED-BE17-D2882CD67C98"),
                "Key22",
                1);
        var template3 =
            new DomainObjectDemoObjectX.Template(
                "Name33",
                true,
                new Guid("601F8424-380F-4BA5-BC30-30C0C0F13972"),
                "Key23",
                1);

        long id1;
        long id2;
        long id3;
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            id1 = template1.New(m_entryPoint).Identity;
            id2 = template2.New(m_entryPoint).Identity;
            id3 = template3.New(m_entryPoint).Identity;

            unitOfWork.Commit();
        }

        using (var unitOfWork = (UnitOfWork)m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDemoObjectX>();

            using (var dbContext = unitOfWork.NewDbContext())
            {
                var instance =
                    register.Find(() =>
                        dbContext.Demoobjectx
                            .SingleOrDefault(
                                entity => entity.Id == id1)
                            ?.ToMapperDto());
                Assert.IsNotNull(instance);
                Assert.AreEqual(id1, instance.Identity);

                instance =
                    register.FindAsync(async ct =>
                            (await dbContext.Demoobjectx
                                .SingleOrDefaultAsync(
                                    entity => entity.Id == id1, ct))
                            ?.ToMapperDto())
                        .SafeGetResult();
                Assert.IsNotNull(instance);
                Assert.AreEqual(id1, instance.Identity);

                instance =
                    register.FindAsync(async ct =>
                            (await dbContext.Demoobjectx
                                .SingleOrDefaultAsync(
                                    entity => entity.Id == -1, ct))
                            ?.ToMapperDto())
                        .SafeGetResult();
                Assert.IsNull(instance);

                var instances =
                    register.GetObjectEnumerator(() =>
                            dbContext.Demoobjectx
                                .Where(entity => entity.Id == id1)
                                .Select(entity => entity.ToMapperDto()))
                        .ToList();
                Assert.IsNotNull(instances);
                Assert.AreEqual(1, instances.Count);
                Assert.AreEqual(id1, instances[0].Identity);

                using (var dbContext2 = unitOfWork.NewDbContext())
                {
                    {
                        instances = register
                        .GetObjectEnumeratorAsync(DtoCollectionSelector)
                        .ToListAsync()
                        .SafeGetResult();
                        Assert.IsNotNull(instances);
                        Assert.AreEqual(1, instances.Count);
                        Assert.AreEqual(id1, instances[0].Identity);

                        async IAsyncEnumerable<IMapperDto> DtoCollectionSelector(
                            [EnumeratorCancellation] CancellationToken ct)
                        {
                            await foreach (var entity in dbContext2.Demoobjectx
                                               .Where(entity => entity.Id == id1)
                                               .AsAsyncEnumerable()
                                               .WithCancellation(ct)
                                               .ConfigureAwait(false))
                            {
                                yield return entity.ToMapperDto();
                            }
                        }
                    }

                    {
                        instances = register
                            .GetObjectEnumeratorAsync(DtoCollectionSelector)
                            .ToListAsync()
                            .SafeGetResult();
                        Assert.IsNotNull(instances);
                        Assert.AreEqual(2, instances.Count);
                        Assert.IsTrue(instances.Any(i => i.Identity == id2));
                        Assert.IsTrue(instances.Any(i => i.Identity == id3));

                        async IAsyncEnumerable<IMapperDto> DtoCollectionSelector(
                            [EnumeratorCancellation] CancellationToken ct)
                        {
                            await foreach (var entity in dbContext2.Demoobjectx
                                               .Where(entity => entity.Id != id1)
                                               .AsAsyncEnumerable()
                                               .WithCancellation(ct)
                                               .ConfigureAwait(false))
                            {
                                yield return entity.ToMapperDto();
                            }
                        }
                    }

                    {
                        instances = register
                            .GetObjectEnumeratorAsync(DtoCollectionSelector)
                            .ToListAsync()
                            .SafeGetResult();
                        Assert.IsNotNull(instances);
                        Assert.AreEqual(0, instances.Count);

                        async IAsyncEnumerable<IMapperDto> DtoCollectionSelector(
                            [EnumeratorCancellation] CancellationToken ct)
                        {
                            await foreach (var entity in dbContext2.Demoobjectx
                                               .Where(entity => entity.Id == -1)
                                               .AsAsyncEnumerable()
                                               .WithCancellation(ct)
                                               .ConfigureAwait(false))
                            {
                                yield return entity.ToMapperDto();
                            }
                        }
                    }
                }
            }

            using (var dbContext = unitOfWork.NewDbContext(false))
            {
                var instance =
                    register.Find(() =>
                        dbContext.Demoobjectx
                            .SingleOrDefault(
                                entity => entity.Id == id1)
                            ?.ToMapperDto());
                Assert.IsNotNull(instance);
                Assert.AreEqual(id1, instance.Identity);

                instance =
                    register.FindAsync(async ct =>
                            (await dbContext.Demoobjectx
                                .SingleOrDefaultAsync(
                                    entity => entity.Id == id1, ct))
                            ?.ToMapperDto())
                        .SafeGetResult();
                Assert.IsNotNull(instance);
                Assert.AreEqual(id1, instance.Identity);

                instance =
                    register.FindAsync(async ct =>
                            (await dbContext.Demoobjectx
                                .SingleOrDefaultAsync(
                                    entity => entity.Id == -1, ct))
                            ?.ToMapperDto())
                        .SafeGetResult();
                Assert.IsNull(instance);

                var instances =
                    register.GetObjectEnumerator(() =>
                            dbContext.Demoobjectx
                                .Where(entity => entity.Id == id1)
                                .Select(entity => entity.ToMapperDto()))
                        .ToList();
                Assert.IsNotNull(instances);
                Assert.AreEqual(1, instances.Count);
                Assert.AreEqual(id1, instances[0].Identity);

                {
                    instances = register
                        .GetObjectEnumeratorAsync(DtoCollectionSelector)
                        .ToListAsync()
                        .SafeGetResult();
                    Assert.IsNotNull(instances);
                    Assert.AreEqual(1, instances.Count);
                    Assert.AreEqual(id1, instances[0].Identity);

                    async IAsyncEnumerable<IMapperDto> DtoCollectionSelector(
                        [EnumeratorCancellation] CancellationToken ct)
                    {
                        await foreach (var entity in dbContext.Demoobjectx
                                           .Where(entity => entity.Id == id1)
                                           .AsAsyncEnumerable()
                                           .WithCancellation(ct)
                                           .ConfigureAwait(false))
                        {
                            yield return entity.ToMapperDto();
                        }
                    }
                }

                {
                    instances = register
                        .GetObjectEnumeratorAsync(DtoCollectionSelector)
                        .ToListAsync()
                        .SafeGetResult();
                    Assert.IsNotNull(instances);
                    Assert.AreEqual(2, instances.Count);
                    Assert.IsTrue(instances.Any(i => i.Identity == id2));
                    Assert.IsTrue(instances.Any(i => i.Identity == id3));

                    async IAsyncEnumerable<IMapperDto> DtoCollectionSelector(
                        [EnumeratorCancellation] CancellationToken ct)
                    {
                        await foreach (var entity in dbContext.Demoobjectx
                                           .Where(entity => entity.Id != id1)
                                           .AsAsyncEnumerable()
                                           .WithCancellation(ct)
                                           .ConfigureAwait(false))
                        {
                            yield return entity.ToMapperDto();
                        }
                    }
                }

                {
                    instances = register
                        .GetObjectEnumeratorAsync(DtoCollectionSelector)
                        .ToListAsync()
                        .SafeGetResult();
                    Assert.IsNotNull(instances);
                    Assert.AreEqual(0, instances.Count);

                    async IAsyncEnumerable<IMapperDto> DtoCollectionSelector(
                        [EnumeratorCancellation] CancellationToken ct)
                    {
                        await foreach (var entity in dbContext.Demoobjectx
                                           .Where(entity => entity.Id == -1)
                                           .AsAsyncEnumerable()
                                           .WithCancellation(ct)
                                           .ConfigureAwait(false))
                        {
                            yield return entity.ToMapperDto();
                        }
                    }
                }
            }
        }

        using (var unitOfWork = (UnitOfWork)m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDemoObjectX>();
            var instance1 = register.Find(id1);
            var instance2 = register.Find(id2);
            var instance3 = register.Find(id3);

            var instances = register.GetCollectionByNameSize(1).ToList();
            Assert.AreEqual(0, instances.Count);

            instances = register.GetCollectionByNameSize(5).ToList();
            Assert.AreEqual(2, instances.Count);
            Assert.IsTrue(instances.Any(i => ReferenceEquals(i, instance1)));
            Assert.IsTrue(instances.Any(i => ReferenceEquals(i, instance2)));

            instances = register.GetCollectionByNameSize(6).ToList();
            Assert.AreEqual(1, instances.Count);
            Assert.IsTrue(instances.Any(i => ReferenceEquals(i, instance3)));

            instances = register.GetCollectionByNameSize(7).ToList();
            Assert.AreEqual(0, instances.Count);

            instances = register.GetCollectionByNameSizeAsync(1).ToListAsync().SafeGetResult();
            Assert.AreEqual(0, instances.Count);

            instances = register.GetCollectionByNameSizeAsync(5).ToListAsync().SafeGetResult();
            Assert.AreEqual(2, instances.Count);
            Assert.IsTrue(instances.Any(i => ReferenceEquals(i, instance1)));
            Assert.IsTrue(instances.Any(i => ReferenceEquals(i, instance2)));

            instances = register.GetCollectionByNameSizeAsync(6).ToListAsync().SafeGetResult();
            Assert.AreEqual(1, instances.Count);
            Assert.IsTrue(instances.Any(i => ReferenceEquals(i, instance3)));

            instances = register.GetCollectionByNameSizeAsync(7).ToListAsync().SafeGetResult();
            Assert.AreEqual(0, instances.Count);

            var instance = register.GetByName("xxx");
            Assert.IsNull(instance);

            instance = register.GetByName("Name1");
            Assert.IsNotNull(instance);
            Assert.IsTrue(ReferenceEquals(instance, instance1));

            instance = register.GetByNameAsync("xxx").SafeGetResult();
            Assert.IsNull(instance);

            instance = register.GetByNameAsync("Name1").SafeGetResult();
            Assert.IsNotNull(instance);
            Assert.IsTrue(ReferenceEquals(instance, instance1));
        }

        using (var unitOfWork = (UnitOfWork)m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDemoObjectX>();
            var instance1 = register.LockRegister(id1).Find<IDomainObjectDemoObjectX>(id1);
            var instance2 = register.LockRegister(id2).Find<IDomainObjectDemoObjectX>(id2);
            var instance3 = register.LockRegister(id3).Find<IDomainObjectDemoObjectX>(id3);

            var instances = register.GetCollectionByNameSize(1).ToList();
            Assert.AreEqual(0, instances.Count);

            instances = register.GetCollectionByNameSize(5).ToList();
            Assert.AreEqual(2, instances.Count);
            Assert.IsTrue(instances.Any(i => ReferenceEquals(i, instance1)));
            Assert.IsTrue(instances.Any(i => ReferenceEquals(i, instance2)));

            instances = register.GetCollectionByNameSize(6).ToList();
            Assert.AreEqual(1, instances.Count);
            Assert.IsTrue(instances.Any(i => ReferenceEquals(i, instance3)));

            instances = register.GetCollectionByNameSize(7).ToList();
            Assert.AreEqual(0, instances.Count);

            instances = register.GetCollectionByNameSizeAsync(1).ToListAsync().SafeGetResult();
            Assert.AreEqual(0, instances.Count);

            instances = register.GetCollectionByNameSizeAsync(5).ToListAsync().SafeGetResult();
            Assert.AreEqual(2, instances.Count);
            Assert.IsTrue(instances.Any(i => ReferenceEquals(i, instance1)));
            Assert.IsTrue(instances.Any(i => ReferenceEquals(i, instance2)));

            instances = register.GetCollectionByNameSizeAsync(6).ToListAsync().SafeGetResult();
            Assert.AreEqual(1, instances.Count);
            Assert.IsTrue(instances.Any(i => ReferenceEquals(i, instance3)));

            instances = register.GetCollectionByNameSizeAsync(7).ToListAsync().SafeGetResult();
            Assert.AreEqual(0, instances.Count);

            var instance = register.GetByName("xxx");
            Assert.IsNull(instance);

            instance = register.GetByName("Name1");
            Assert.IsNotNull(instance);
            Assert.IsTrue(ReferenceEquals(instance, instance1));

            instance = register.GetByNameAsync("xxx").SafeGetResult();
            Assert.IsNull(instance);

            instance = register.GetByNameAsync("Name1").SafeGetResult();
            Assert.IsNotNull(instance);
            Assert.IsTrue(ReferenceEquals(instance, instance1));

            var newName1 = "00000000000001";
            var newName2 = "00000000000002";
            var newName3 = "00000000000003";

            // Изменяем доменные объекты
            // Теперь поиск по БД их находит
            // Но на уровне прокси-реестра проверка определяет что объекты в памяти не соответствуют критериям выборки
            instance1.Name = newName1;
            instance2.Name = newName2;
            instance3.Name = newName3;

            instances = register.GetCollectionByNameSize(1).ToList();
            Assert.AreEqual(0, instances.Count);

            instances = register.GetCollectionByNameSize(5).ToList();
            Assert.AreEqual(0, instances.Count);

            instances = register.GetCollectionByNameSize(6).ToList();
            Assert.AreEqual(0, instances.Count);

            instances = register.GetCollectionByNameSize(7).ToList();
            Assert.AreEqual(0, instances.Count);

            instances = register.GetCollectionByNameSize(newName1.Length).ToList();
            Assert.AreEqual(3, instances.Count);
            Assert.IsTrue(instances.Any(i => ReferenceEquals(i, instance1)));
            Assert.IsTrue(instances.Any(i => ReferenceEquals(i, instance2)));
            Assert.IsTrue(instances.Any(i => ReferenceEquals(i, instance3)));

            instances = register.GetCollectionByNameSizeAsync(1).ToListAsync().SafeGetResult();
            Assert.AreEqual(0, instances.Count);

            instances = register.GetCollectionByNameSizeAsync(5).ToListAsync().SafeGetResult();
            Assert.AreEqual(0, instances.Count);

            instances = register.GetCollectionByNameSizeAsync(6).ToListAsync().SafeGetResult();
            Assert.AreEqual(0, instances.Count);

            instances = register.GetCollectionByNameSizeAsync(7).ToListAsync().SafeGetResult();
            Assert.AreEqual(0, instances.Count);

            instances = register.GetCollectionByNameSizeAsync(newName1.Length).ToListAsync().SafeGetResult();
            Assert.AreEqual(3, instances.Count);
            Assert.IsTrue(instances.Any(i => ReferenceEquals(i, instance1)));
            Assert.IsTrue(instances.Any(i => ReferenceEquals(i, instance2)));
            Assert.IsTrue(instances.Any(i => ReferenceEquals(i, instance3)));

            instance = register.GetByName("xxx");
            Assert.IsNull(instance);

            instance = register.GetByName("Name1");
            Assert.IsNull(instance);

            instance = register.GetByName(newName1);
            Assert.IsNotNull(instance);
            Assert.IsTrue(ReferenceEquals(instance, instance1));

            instance = register.GetByNameAsync("xxx").SafeGetResult();
            Assert.IsNull(instance);

            instance = register.GetByNameAsync("Name1").SafeGetResult();
            Assert.IsNull(instance);

            instance = register.GetByNameAsync(newName1).SafeGetResult();
            Assert.IsNotNull(instance);
            Assert.IsTrue(ReferenceEquals(instance, instance1));
        }
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public void Test_New_No_Commit()
    {
        var template =
            new DomainObjectDemoObjectX.Template(
                "Name",
                true,
                new Guid("6457CCA1-4217-4D47-B057-9668278FE290"),
                "Key2",
                1);

        using (m_entryPoint.CreateUnitOfWork())
        {
            template.New(m_entryPoint);
        }

#if DEBUG
        {
            var register = m_entryPoint.Registers.GetRegisterAs<IDomainObjectRegisterDemoObjectX, DomainObjectRegisterDemoObjectX>();
            Assert.AreEqual(IdentitiesServiceResult.NotFound, register.IdentitiesService!.AlternativeKey.FindKey(template.GetKey(), out _));
            Assert.AreEqual(IdentitiesServiceResult.NotFound, register.IdentitiesService.Contexts.TryGetCount(template.Group, out _));
        }
#endif

        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDemoObjectX>();

            var instance2 = register.FindByKey(template.GetKey());
            Assert.IsNull(instance2);

            var instances = register.GetEnumeratorByContext(template.Group).ToList();
            Assert.IsNotNull(instances);
            Assert.AreEqual(0, instances.Count);

            unitOfWork.Commit();
        }
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public void Test_New_Delete()
    {
        var template =
            new DomainObjectDemoObjectX.Template(
                "Name",
                true,
                new Guid("6457CCA1-4217-4D47-B057-9668278FE290"),
                "Key2",
                1);

        long id;
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var instance = template.New(m_entryPoint);
            id = instance.Identity;
            Assert.AreEqual(template.Group, instance.Group);
            Assert.AreEqual(template.Enabled, instance.Enabled);
            Assert.AreEqual(template.Key2, instance.Key2);
            Assert.AreEqual(template.Key1, instance.Key1);
            Assert.AreEqual(template.Name, instance.Name);

            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDemoObjectX>();

            var instance2 = register.FindByKey(template.GetKey());
            Assert.IsNotNull(instance2);
            Assert.IsTrue(ReferenceEquals(instance, instance2));

            instance2 = register.FindByDemoAlternativeKey(template.GetKey());
            Assert.IsNotNull(instance2);
            Assert.IsTrue(ReferenceEquals(instance, instance2));

            instance2 = register.FindByDemoAlternativeKeyAsync(template.GetKey()).SafeGetResult();
            Assert.IsNotNull(instance2);
            Assert.IsTrue(ReferenceEquals(instance, instance2));

            var instances = register.GetEnumeratorByContext(template.Group).ToList();
            Assert.IsNotNull(instances);
            Assert.AreEqual(0, instances.Count);

            instances = register.GetCollectionByDemoGroup(template.Group).ToList();
            Assert.IsNotNull(instances);
            Assert.AreEqual(0, instances.Count);

            instances = register.GetCollectionByDemoGroupAsync(template.Group).ToListAsync().SafeGetResult();
            Assert.IsNotNull(instances);
            Assert.AreEqual(0, instances.Count);

            unitOfWork.Commit();
        }

#if DEBUG
        {
            var register = m_entryPoint.Registers.GetRegisterAs<IDomainObjectRegisterDemoObjectX, DomainObjectRegisterDemoObjectX>();
            Assert.AreEqual(IdentitiesServiceResult.Exists, register.IdentitiesService!.AlternativeKey.FindKey(template.GetKey(), out var tempId));
            Assert.AreEqual(id, tempId);
            Assert.AreEqual(IdentitiesServiceResult.Exists, register.IdentitiesService.Contexts.TryGetCount(template.Group, out var count));
            Assert.AreEqual(1, count);
        }
#endif

        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDemoObjectX>();
            var instance = register.Find<IDomainObjectDemoObjectX>(id);
            Assert.IsNotNull(instance);
            Assert.AreEqual(template.Group, instance.Group);
            Assert.AreEqual(template.Enabled, instance.Enabled);
            Assert.AreEqual(template.Key2, instance.Key2);
            Assert.AreEqual(template.Key1, instance.Key1);
            Assert.AreEqual(template.Name, instance.Name);

            var instance2 = register.FindByKey(template.GetKey());
            Assert.IsNotNull(instance2);
            Assert.IsTrue(ReferenceEquals(instance, instance2));

            instance2 = register.FindByDemoAlternativeKey(template.GetKey());
            Assert.IsNotNull(instance2);
            Assert.IsTrue(ReferenceEquals(instance, instance2));

            instance2 = register.FindByDemoAlternativeKeyAsync(template.GetKey()).SafeGetResult();
            Assert.IsNotNull(instance2);
            Assert.IsTrue(ReferenceEquals(instance, instance2));

            var instances = register.GetEnumeratorByContext(template.Group).ToList();
            Assert.IsNotNull(instances);
            Assert.AreEqual(1, instances.Count);
            instance2 = instances[0];
            Assert.IsTrue(ReferenceEquals(instance, instance2));

            instances = register.GetCollectionByDemoGroup(template.Group).ToList();
            Assert.IsNotNull(instances);
            Assert.AreEqual(1, instances.Count);
            instance2 = instances[0];
            Assert.IsTrue(ReferenceEquals(instance, instance2));

            instances = register.GetCollectionByDemoGroupAsync(template.Group).ToListAsync().SafeGetResult();
            Assert.IsNotNull(instances);
            Assert.AreEqual(1, instances.Count);
            instance2 = instances[0];
            Assert.IsTrue(ReferenceEquals(instance, instance2));

            instance.Delete();
            instance.Delete();
            instance.Delete();

            unitOfWork.Commit();
        }

#if DEBUG
        {
            var register = m_entryPoint.Registers.GetRegisterAs<IDomainObjectRegisterDemoObjectX, DomainObjectRegisterDemoObjectX>();
            Assert.AreEqual(IdentitiesServiceResult.NotFound, register.IdentitiesService!.AlternativeKey.FindKey(template.GetKey(), out _));
            Assert.AreEqual(IdentitiesServiceResult.NotFound, register.IdentitiesService.Contexts.TryGetCount(template.Group, out _));
        }
#endif

        var mapper = m_entryPoint.Mappers.GetMapper<IMapperDemoObjectX>();

        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var dtoActual = mapper.GetRaw(unitOfWork.MappersSession, id);
            Assert.IsNull(dtoActual);

            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDemoObjectX>();
            var instance = register.Find<IDomainObjectDemoObjectX>(id);
            Assert.IsNull(instance);

            var instance2 = register.FindByKey(template.GetKey());
            Assert.IsNull(instance2);

            var instances = register.GetEnumeratorByContext(template.Group).ToList();
            Assert.IsNotNull(instances);
            Assert.AreEqual(0, instances.Count);

            unitOfWork.Commit();
        }

        ReCreateEntryPoint();

        mapper = m_entryPoint.Mappers.GetMapper<IMapperDemoObjectX>();

        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var dtoActual = mapper.GetRaw(unitOfWork.MappersSession, id);
            Assert.IsNull(dtoActual);

            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDemoObjectX>();
            var instance = register.Find<IDomainObjectDemoObjectX>(id);
            Assert.IsNull(instance);

            var instance2 = register.FindByKey(template.GetKey());
            Assert.IsNull(instance2);

            var instances = register.GetEnumeratorByContext(template.Group).ToList();
            Assert.IsNotNull(instances);
            Assert.AreEqual(0, instances.Count);

            unitOfWork.Commit();
        }
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public async Task Test_New_Delete_Async()
    {
        var template =
            new DomainObjectDemoObjectX.Template(
                "Name",
                true,
                new Guid("6457CCA1-4217-4D47-B057-9668278FE290"),
                "Key2",
                1);

        var id =
            await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
                async (unitOfWork, cancellationToken) =>
                {
                    var instance = await template.NewAsync(m_entryPoint, cancellationToken);
                    var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDemoObjectX>();
                    var instance2 = await register.FindByKeyAsync(template.GetKey(), cancellationToken);
                    Assert.IsNotNull(instance2);
                    Assert.IsTrue(ReferenceEquals(instance, instance2));

                    return instance.Identity;
                },
                autoCommit: true);

#if DEBUG
        {
            var register = m_entryPoint.Registers.GetRegisterAs<IDomainObjectRegisterDemoObjectX, DomainObjectRegisterDemoObjectX>();
            Assert.AreEqual(IdentitiesServiceResult.Exists, register.IdentitiesService!.AlternativeKey.FindKey(template.GetKey(), out var tempId));
            Assert.AreEqual(id, tempId);
            Assert.AreEqual(IdentitiesServiceResult.Exists, register.IdentitiesService.Contexts.TryGetCount(template.Group, out var count));
            Assert.AreEqual(1, count);
        }
#endif

        await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
            (unitOfWork, _) =>
            {
                var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDemoObjectX>();
                var instance = register.Find<IDomainObjectDemoObjectX>(id);
                Assert.IsNotNull(instance);
                Assert.AreEqual(template.Group, instance.Group);
                Assert.AreEqual(template.Enabled, instance.Enabled);
                Assert.AreEqual(template.Key2, instance.Key2);
                Assert.AreEqual(template.Key1, instance.Key1);
                Assert.AreEqual(template.Name, instance.Name);

                instance.Delete();

                return ValueTask.CompletedTask;
            },
            autoCommit: true);

#if DEBUG
        {
            var register = m_entryPoint.Registers.GetRegisterAs<IDomainObjectRegisterDemoObjectX, DomainObjectRegisterDemoObjectX>();
            Assert.AreEqual(IdentitiesServiceResult.NotFound, register.IdentitiesService!.AlternativeKey.FindKey(template.GetKey(), out _));
            Assert.AreEqual(IdentitiesServiceResult.NotFound, register.IdentitiesService.Contexts.TryGetCount(template.Group, out _));
        }
#endif

        await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
            (unitOfWork, _) =>
            {
                var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDemoObjectX>();
                var instance = register.Find<IDomainObjectDemoObjectX>(id);
                Assert.IsNull(instance);

                return ValueTask.CompletedTask;
            },
            autoCommit: true);
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public void Test_Key_Duplicate()
    {
        var template1 =
            new DomainObjectDemoObjectX.Template(
                "Name1",
                true,
                new Guid("6457CCA1-4217-4D47-B057-9668278FE290"),
                "Key2",
                1);
        var template2 =
            new DomainObjectDemoObjectX.Template(
                "Name2",
                true,
                new Guid("6457CCA1-4217-4D47-B057-9668278FE290"),
                "Key2",
                1);

        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            template1.New(m_entryPoint);

            unitOfWork.Commit();
        }

        var workflowException =
            Assert.Throws<WorkflowException>(
                () =>
                {
                    using var unitOfWork = m_entryPoint.CreateUnitOfWork();

                    template2.New(m_entryPoint);

                    unitOfWork.Commit();
                });
        Assert.AreEqual(WorkflowErrorCodes.DemoObjectXKeyAlreadyExists, workflowException!.Code);
    }

#if DEBUG
    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public void Test_Update()
    {
        var template =
            new DomainObjectDemoObjectX.Template(
                "Name",
                true,
                new Guid("6457CCA1-4217-4D47-B057-9668278FE290"),
                "Key2",
                1);

        long id;
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            Assert.IsFalse(unitOfWork.IsDefinedCommitVerifying);

            var instance = template.New(m_entryPoint);

            Assert.IsTrue(unitOfWork.IsDefinedCommitVerifying);

            id = instance.Identity;

            unitOfWork.Commit();
        }

        var internalException =
            Assert.Throws<InternalException>(
                () =>
                {
                    using var unitOfWork = m_entryPoint.CreateUnitOfWork();

                    var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDemoObjectX>();
                    var instance = register.Find<IDomainObjectDemoObjectX>(id);
                    Assert.IsNotNull(instance);

                    instance.Enabled = false;
                });
        Assert.AreEqual($"Для объекта '11edfd22-32bf-4d00-847d-4023118b11df' для пула лок-объектов типа '{typeof(long).AssemblyQualifiedName}' для ключа '{id}' не создан лок-объект.", internalException!.Message, internalException.Message);

        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDemoObjectX>();

            var instance = 
                register
                    .LockRegister(id) // Тут создаётся стратегия IUnitOfWorkCommitVerifying по умолчанию для проверки успешности завершения IUnitOfWork.
                    .Find<IDomainObjectDemoObjectX>(id);
            Assert.IsNotNull(instance);
            Assert.AreEqual("Name", instance.Name);

            instance.Enabled = false;

            Assert.AreEqual(false, instance.Enabled);

            internalException = Assert.Throws<InternalException>(() => unitOfWork.Commit());
            Assert.AreEqual("Стратегия проверки успешности завершения IUnitOfWork не определена.", internalException!.Message, internalException.Message);
        }

        UnitOfWork.ThrowOnDefaultCommitVerifying = false;
        try
        {
            using var unitOfWork = m_entryPoint.CreateUnitOfWork();

            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDemoObjectX>();
            var instance = register.LockRegister(id).Find<IDomainObjectDemoObjectX>(id);
            Assert.IsNotNull(instance);
            Assert.AreEqual(true, instance.Enabled);
            Assert.AreEqual("Name", instance.Name);

            instance.Enabled = false;
            instance.Name = "Name2";

            Assert.AreEqual(false, instance.Enabled);
            Assert.AreEqual("Name2", instance.Name);

            instance = register.LockRegister(id).Find<IDomainObjectDemoObjectX>(id);
            Assert.IsNotNull(instance);
            Assert.AreEqual(false, instance.Enabled);
            Assert.AreEqual("Name2", instance.Name);

            unitOfWork.Commit();
        }
        finally
        {
            UnitOfWork.ThrowOnDefaultCommitVerifying = true;
        }

        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDemoObjectX>();
            var instance = register.Find<IDomainObjectDemoObjectX>(id);
            Assert.IsNotNull(instance);
            Assert.AreEqual(false, instance.Enabled);
            Assert.AreEqual("Name2", instance.Name);

            unitOfWork.Commit();
        }
    }
#endif
}
