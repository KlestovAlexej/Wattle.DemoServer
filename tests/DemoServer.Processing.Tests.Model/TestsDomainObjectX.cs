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
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObjectX;
using ShtrihM.DemoServer.Processing.Model.Implements;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.Mappers.Primitives;
using ShtrihM.Wattle3.Utils;
using ShtrihM.DemoServer.Processing.Model.DomainObjects.Common;

namespace ShtrihM.DemoServer.Processing.Tests.Model;

[TestFixture]
public class TestsDomainObjectX : BaseTestsDomainObjects
{
    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    [Description("Выборка доменных обектов с использованием Entity Framework")]
    [SuppressMessage("ReSharper", "AccessToDisposedClosure")]
    public void Test_EntityFramework()
    {
        var template1 =
            new DomainObjectDemoObjectX.Template(
                "Name1",
                true,
                new("6457CCA1-4217-4D47-B057-9668278FE290"),
                "Key21",
                1);
        var template2 =
            new DomainObjectDemoObjectX.Template(
                "Name2",
                true,
                new("03B5D8E7-7528-4EED-BE17-D2882CD67C98"),
                "Key22",
                1);
        var template3 =
            new DomainObjectDemoObjectX.Template(
                "Name3",
                true,
                new("601F8424-380F-4BA5-BC30-30C0C0F13972"),
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
            using var dbContext = unitOfWork.NewDbContext();

            var instance =
                register.Find(() =>
                    dbContext.Demoobjectx
                        .SingleOrDefault(
                            entity => entity.Id == id1)
                        .ToMapperDto());
            Assert.IsNotNull(instance);
            Assert.AreEqual(id1, instance.Identity);

            instance =
                register.FindAsync(async ct =>
                        (await dbContext.Demoobjectx
                            .SingleOrDefaultAsync(
                                entity => entity.Id == id1, ct))
                        .ToMapperDto())
                    .SafeGetResult();
            Assert.IsNotNull(instance);
            Assert.AreEqual(id1, instance.Identity);

            instance =
                register.FindAsync(async ct =>
                        (await dbContext.Demoobjectx
                            .SingleOrDefaultAsync(
                                entity => entity.Id == -1, ct))
                        .ToMapperDto())
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

                async IAsyncEnumerable<IMapperDto> DtoCollectionSelector([EnumeratorCancellation] CancellationToken ct)
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

                async IAsyncEnumerable<IMapperDto> DtoCollectionSelector([EnumeratorCancellation] CancellationToken ct)
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

                async IAsyncEnumerable<IMapperDto> DtoCollectionSelector([EnumeratorCancellation] CancellationToken ct)
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

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public void Test_New_No_Commit()
    {
        var template =
            new DomainObjectDemoObjectX.Template(
                "Name",
                true,
                new("6457CCA1-4217-4D47-B057-9668278FE290"),
                "Key2",
                1);

        using (m_entryPoint.CreateUnitOfWork())
        {
            template.New(m_entryPoint);
        }

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
                new("6457CCA1-4217-4D47-B057-9668278FE290"),
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

            unitOfWork.Commit();
        }

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

            var instances = register.GetEnumeratorByContext(template.Group).ToList();
            Assert.IsNotNull(instances);
            Assert.AreEqual(1, instances.Count);
            instance2 = instances[0];
            Assert.IsTrue(ReferenceEquals(instance, instance2));

            instance.Delete();

            unitOfWork.Commit();
        }

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
    public void Test_Key_Duplicate()
    {
        var template1 =
            new DomainObjectDemoObjectX.Template(
                "Name1",
                true,
                new("6457CCA1-4217-4D47-B057-9668278FE290"),
                "Key2",
                1);
        var template2 =
            new DomainObjectDemoObjectX.Template(
                "Name2",
                true,
                new("6457CCA1-4217-4D47-B057-9668278FE290"),
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

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public void Test_Update()
    {
        var template =
            new DomainObjectDemoObjectX.Template(
                "Name",
                true,
                new("6457CCA1-4217-4D47-B057-9668278FE290"),
                "Key2",
                1);

        long id;
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var instance = template.New(m_entryPoint);
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
        Assert.AreEqual($"Для объекта '{WellknownCommonInfrastructureMonitors.LocksUpdateDemoObjectX}' для пула лок-объектов типа '{typeof(long).AssemblyQualifiedName}' для ключа '{id}' не создан лок-объект.", internalException!.Message, internalException.Message);

        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDemoObjectX>();
            var instance = register.LockRegister(id).Find<IDomainObjectDemoObjectX>(id);
            Assert.IsNotNull(instance);
            Assert.AreEqual(true, instance.Enabled);
            Assert.AreEqual("Name", instance.Name);

            instance.Enabled = false;
            instance.Name = "Name2";

            Assert.AreEqual(false, instance.Enabled);
            Assert.AreEqual("Name2", instance.Name);

            unitOfWork.Commit();
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
}
