using System;
using NUnit.Framework;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.DemoServer.Processing.Tests.Model.Environment;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Testing;
using System.Linq;
using ShtrihM.DemoServer.Processing.Api.Common;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObjectX;
using ShtrihM.Wattle3.Common.Exceptions;

namespace ShtrihM.DemoServer.Processing.Tests.Model;

[TestFixture]
public class TestsDomainObjectX : BaseTestsDomainObjects
{
    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public void Test_New_No_Commit()
    {
        var template =
            new DomainObjectTemplateDemoObjectX(
                "Name",
                true,
                new Guid("6457CCA1-4217-4D47-B057-9668278FE290"),
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
            new DomainObjectTemplateDemoObjectX(
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
            new DomainObjectTemplateDemoObjectX(
                "Name1",
                true,
                new Guid("6457CCA1-4217-4D47-B057-9668278FE290"),
                "Key2",
                1);
        var template2 =
            new DomainObjectTemplateDemoObjectX(
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

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public void Test_Update()
    {
        var template =
            new DomainObjectTemplateDemoObjectX(
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

            unitOfWork.Commit();
        }

        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDemoObjectX>();
            var instance = register.Find<IDomainObjectDemoObjectX>(id);
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
