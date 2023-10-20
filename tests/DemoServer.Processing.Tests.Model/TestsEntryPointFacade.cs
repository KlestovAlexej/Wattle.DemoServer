using NUnit.Framework;
using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject;
using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.DemoServer.Processing.Tests.Model.Environment;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Testing;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace ShtrihM.DemoServer.Processing.Tests.Model;

[TestFixture]
[SuppressMessage("ReSharper", "MethodHasAsyncOverload")]
[SuppressMessage("ReSharper", "UseAwaitUsing")]
public class TestsEntryPointFacade : BaseTestsDomainObjects
{
    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public async Task Test_DemoObjectCreateAsync()
    {
        using var unitOfWork = m_entryPoint.CreateUnitOfWork();

        var info =
            await m_entryPoint.Facade.DemoObjectCreateAsync(
                new DemoObjectCreate
                {
                    Enabled = true,
                    Name = "Name",
                });
        Assert.True(info.Enabled);
        Assert.AreEqual("Name", info.Name);

        await unitOfWork.CommitAsync();
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public async Task Test_DemoObjectReadAsync()
    {
        DemoObjectInfo info;
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            info =
                await m_entryPoint.Facade.DemoObjectCreateAsync(
                    new DemoObjectCreate
                    {
                        Enabled = true,
                        Name = "Name",
                    });

            await unitOfWork.CommitAsync();
        }

        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            info = await m_entryPoint.Facade.DemoObjectReadAsync(info.Id);
            Assert.True(info.Enabled);
            Assert.AreEqual("Name", info.Name);

            await unitOfWork.CommitAsync();
        }
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public async Task Test_DemoObjectUpdateAsync()
    {
        DemoObjectInfo info;
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            info =
                await m_entryPoint.Facade.DemoObjectCreateAsync(
                    new DemoObjectCreate
                    {
                        Enabled = true,
                        Name = "Name",
                    });
            Assert.True(info.Enabled);
            Assert.AreEqual("Name", info.Name);

            var registerDemoObject = unitOfWork.Registers.GetRegister(WellknownDomainObjects.DemoObject);
            var demoObject = await registerDemoObject
                .FindAsync<IDomainObjectDemoObject>(info.Id, CancellationToken.None)
                .ConfigureAwait(false);
            Assert.IsNotNull(demoObject);

            await demoObject.UpdateAsync(
                new DemoObjectUpdate
                {
                    Id = info.Id,
                    Fields =
                        new List<BaseDemoObjectUpdateFieldValue>
                        {
                            new DemoObjectUpdateFieldValueOfEnabled
                            {
                                Enabled = false,
                            },
                            new DemoObjectUpdateFieldValueOfName
                            {
                                Name = "Name2",
                            },
                        },
                });
            info = demoObject.GetInfo();
            Assert.False(info.Enabled);
            Assert.AreEqual("Name2", info.Name);

            await unitOfWork.CommitAsync();
        }

        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            info =
                await m_entryPoint.Facade.DemoObjectUpdateAsync(
                    new DemoObjectUpdate
                    {
                        Id = info.Id,
                        Fields =
                            new List<BaseDemoObjectUpdateFieldValue>
                            {
                                new DemoObjectUpdateFieldValueOfEnabled
                                {
                                    Enabled = true,
                                },
                                new DemoObjectUpdateFieldValueOfName
                                {
                                    Name = "Name3",
                                },
                            },
                    });
            Assert.True(info.Enabled);
            Assert.AreEqual("Name3", info.Name);

            await unitOfWork.CommitAsync();
        }

        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            info = await m_entryPoint.Facade.DemoObjectReadAsync(info.Id);
            Assert.True(info.Enabled);
            Assert.AreEqual("Name3", info.Name);

            await unitOfWork.CommitAsync();
        }
    }
}