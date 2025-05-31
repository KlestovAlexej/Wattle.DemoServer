﻿using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Acme.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;
using Acme.DemoServer.Processing.Model.Interfaces;
using Acme.DemoServer.Processing.Tests.Model.Environment;
using Acme.Wattle.Testing;
using System.Threading.Tasks;
using Acme.DemoServer.Processing.Api.Common.Dtos.DemoObject;

namespace Acme.DemoServer.Processing.Tests.Model;

public class TestsDemoObjectControllerService : BaseTestsDomainObjects
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private IDemoObjectControllerService m_demoObjectControllerService;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    private bool m_skipCountInternalException;

    [SetUp]
    public void SetUp()
    {
        m_skipCountInternalException = false;
        m_demoObjectControllerService = m_entryPoint.ServiceProvider.GetService<IDemoObjectControllerService>()!;
    }

    [TearDown]
    public void TearDown()
    {
        var snapShot = m_entryPoint.ExceptionPolicy.InfrastructureMonitor.GetSnapShot();

        if (false == m_skipCountInternalException)
        {
            Assert.AreEqual(0, snapShot.CountInternalException, GetDbLogs(m_mappers));
        }

        Assert.AreEqual(0, snapShot.CountMapperException, GetDbLogs(m_mappers));
        Assert.AreEqual(0, snapShot.CountUnexpectedException, GetDbLogs(m_mappers));
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public async Task Test_CreateAsync()
    {
        var info =
            await m_demoObjectControllerService.CreateAsync(
                new DemoObjectCreate
                {
                    Enabled = true,
                    Name = "Name",
                });
        Assert.True(info.Enabled);
        Assert.AreEqual("Name", info.Name);
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public async Task Test_ReadAsync()
    {
        var info =
            await m_demoObjectControllerService.CreateAsync(
                new DemoObjectCreate
                {
                    Enabled = true,
                    Name = "Name",
                });

        info = await m_demoObjectControllerService.ReadAsync(info.Id);
        Assert.True(info.Enabled);
        Assert.AreEqual("Name", info.Name);
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public async Task Test_UpdateAsync()
    {
        var info =
            await m_demoObjectControllerService.CreateAsync(
                new DemoObjectCreate
                {
                    Enabled = true,
                    Name = "Name",
                });

        info =
            await m_demoObjectControllerService.UpdateAsync(
                new DemoObjectUpdate
                {
                    Id = info.Id,
                    Fields =
                    [
                        new DemoObjectUpdateFieldValueOfEnabled
                        {
                            Enabled = false,
                        },

                        new DemoObjectUpdateFieldValueOfName
                        {
                            Name = "Name2",
                        }

                    ],
                });
        Assert.False(info.Enabled);
        Assert.AreEqual("Name2", info.Name);

        info = await m_demoObjectControllerService.ReadAsync(info.Id);
        Assert.False(info.Enabled);
        Assert.AreEqual("Name2", info.Name);
    }
}
