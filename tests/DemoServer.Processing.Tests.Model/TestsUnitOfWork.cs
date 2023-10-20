using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;
using ShtrihM.DemoServer.Processing.Model.Implements;
using ShtrihM.DemoServer.Processing.Tests.Model.Environment;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Testing;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShtrihM.DemoServer.Processing.Tests.Model;

[TestFixture]
public class TestsUnitOfWork : BaseTestsDomainObjects
{
    private class UnitOfWorkCommitState
    {
        public bool IsSuccessful;
        public bool IsFail;
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public void Test_NewDbContext()
    {
        using (var unitOfWork = (UnitOfWork)m_entryPoint.CreateUnitOfWork())
        {
            using var dbContext = unitOfWork.NewDbContext(false);

            Assert.AreEqual(0, dbContext.PdSystemLog.Count());

            Assert.IsNotNull(dbContext.Database.GetDbConnection());
            Assert.IsNull(dbContext.Database.CurrentTransaction);

            var items = dbContext.Systemsetting.Select(s => s).ToList();
            Assert.AreEqual(3, items.Count);

            dbContext.SaveChanges();
        }

        using (var unitOfWork = (UnitOfWork)m_entryPoint.CreateUnitOfWork())
        {
            using var dbContext = unitOfWork.NewDbContext(true);

            Assert.IsNotNull(dbContext.Database.GetDbConnection());
            Assert.IsNotNull(dbContext.Database.CurrentTransaction);

            var items = dbContext.Systemsetting.Select(s => s).ToList();
            Assert.AreEqual(3, items.Count);

            dbContext.Systemsetting.Add(
                new Systemsetting
                {
                    Id = new Guid("AE46F447-2B40-4428-82A5-C836A860674B"),
                    Name = "Name",
                    Value = "Value",
                });

            dbContext.SaveChanges();

            items = dbContext.Systemsetting.Select(s => s).ToList();
            Assert.AreEqual(4, items.Count);
        }

        using (var unitOfWork = (UnitOfWork)m_entryPoint.CreateUnitOfWork())
        {
            using var dbContext = unitOfWork.NewDbContext(true);

            Assert.IsNotNull(dbContext.Database.GetDbConnection());
            Assert.IsNotNull(dbContext.Database.CurrentTransaction);

            var items = dbContext.Systemsetting.Select(s => s).ToList();
            Assert.AreEqual(3, items.Count);

            dbContext.Systemsetting.Add(
                new Systemsetting
                {
                    Id = new Guid("AE46F447-2B40-4428-82A5-C836A860674B"),
                    Name = "Name",
                    Value = "Value",
                });

            dbContext.SaveChanges();

            items = dbContext.Systemsetting.Select(s => s).ToList();
            Assert.AreEqual(4, items.Count);

            unitOfWork.Commit();
        }

        using (var unitOfWork = (UnitOfWork)m_entryPoint.CreateUnitOfWork())
        {
            using var dbContext = unitOfWork.NewDbContext(true);

            Assert.IsNotNull(dbContext.Database.GetDbConnection());
            Assert.IsNotNull(dbContext.Database.CurrentTransaction);

            var items = dbContext.Systemsetting.Select(s => s).ToList();
            Assert.AreEqual(4, items.Count);

            var item =
                items.SingleOrDefault(
                    i => i.Id == new Guid("AE46F447-2B40-4428-82A5-C836A860674B"));
            Assert.IsNotNull(item);
            Assert.AreEqual("Name", item.Name);
            Assert.AreEqual("Value", item.Value);

            unitOfWork.Commit();
        }
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public async Task Test_NewDbContextAsync()
    {
        await using (var unitOfWork = (UnitOfWork)await m_entryPoint.CreateUnitOfWorkAsync())
        {
            await using var dbContext = await unitOfWork.NewDbContextAsync(false);

            Assert.IsNotNull(dbContext.Database.GetDbConnection());
            Assert.IsNull(dbContext.Database.CurrentTransaction);

            var items = dbContext.Systemsetting.Select(s => s).ToList();
            Assert.AreEqual(3, items.Count);

            await dbContext.SaveChangesAsync();
        }

        await using (var unitOfWork = (UnitOfWork)await m_entryPoint.CreateUnitOfWorkAsync())
        {
            await using var dbContext = await unitOfWork.NewDbContextAsync(true);

            Assert.IsNotNull(dbContext.Database.GetDbConnection());
            Assert.IsNotNull(dbContext.Database.CurrentTransaction);

            var items = dbContext.Systemsetting.Select(s => s).ToList();
            Assert.AreEqual(3, items.Count);

            dbContext.Systemsetting.Add(
                new Systemsetting
                {
                    Id = new Guid("AE46F447-2B40-4428-82A5-C836A860674B"),
                    Name = "Name",
                    Value = "Value",
                });

            await dbContext.SaveChangesAsync();

            items = dbContext.Systemsetting.Select(s => s).ToList();
            Assert.AreEqual(4, items.Count);
        }

        await using (var unitOfWork = (UnitOfWork)await m_entryPoint.CreateUnitOfWorkAsync())
        {
            await using var dbContext = await unitOfWork.NewDbContextAsync(true);

            Assert.IsNotNull(dbContext.Database.GetDbConnection());
            Assert.IsNotNull(dbContext.Database.CurrentTransaction);

            var items = dbContext.Systemsetting.Select(s => s).ToList();
            Assert.AreEqual(3, items.Count);

            dbContext.Systemsetting.Add(
                new Systemsetting
                {
                    Id = new Guid("AE46F447-2B40-4428-82A5-C836A860674B"),
                    Name = "Name",
                    Value = "Value",
                });

            await dbContext.SaveChangesAsync();

            items = dbContext.Systemsetting.Select(s => s).ToList();
            Assert.AreEqual(4, items.Count);

            await unitOfWork.CommitAsync();
        }

        await using (var unitOfWork = (UnitOfWork)await m_entryPoint.CreateUnitOfWorkAsync())
        {
            await using var dbContext = await unitOfWork.NewDbContextAsync(true);

            Assert.IsNotNull(dbContext.Database.GetDbConnection());
            Assert.IsNotNull(dbContext.Database.CurrentTransaction);

            var items = dbContext.Systemsetting.Select(s => s).ToList();
            Assert.AreEqual(4, items.Count);

            var item =
                items.SingleOrDefault(
                    i => i.Id == new Guid("AE46F447-2B40-4428-82A5-C836A860674B"));
            Assert.IsNotNull(item);
            Assert.AreEqual("Name", item.Name);
            Assert.AreEqual("Value", item.Value);

            await unitOfWork.CommitAsync();
        }
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public void Test_DefineVerifying_UnitOfWork_Successful()
    {
        var commitState = new UnitOfWorkCommitState();
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var commitVerifying = unitOfWork.CommitVerifying;
            Assert.IsNotNull(commitVerifying);
            Assert.IsTrue(ReferenceEquals(commitVerifying, unitOfWork.CommitVerifying));

            var domainBehaviour =
                m_entryPoint.CreateDomainBehaviourWithСonfirmation()
                    .SetSuccessful(
                        () => commitState.IsSuccessful = true,
                        () =>
                        {
                            commitState.IsSuccessful = true;

                            return ValueTask.CompletedTask;
                        })
                    .SetFail(
                        () => commitState.IsFail = true,
                        () =>
                        {
                            commitState.IsFail = true;

                            return ValueTask.CompletedTask;
                        });
            unitOfWork.AddBehaviour(domainBehaviour);

            unitOfWork.Commit();
        }
        Assert.IsTrue(commitState.IsSuccessful);
        Assert.IsFalse(commitState.IsFail);

        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister(WellknownDomainObjects.ChangeTracker);
            var instances = register.GetObjectEnumerator().ToList();
            Assert.AreEqual(1, instances.Count);

            unitOfWork.Commit();
        }
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public void Test_DefineVerifying_UnitOfWork_Rollback()
    {
        var commitState = new UnitOfWorkCommitState();
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var domainBehaviour =
                m_entryPoint.CreateDomainBehaviourWithСonfirmation()
                    .SetSuccessful(
                        () => commitState.IsSuccessful = true,
                        () =>
                        {
                            commitState.IsSuccessful = true;

                            return ValueTask.CompletedTask;
                        })
                    .SetFail(
                        () => commitState.IsFail = true,
                        () =>
                        {
                            commitState.IsFail = true;

                            return ValueTask.CompletedTask;
                        });
            unitOfWork.AddBehaviour(domainBehaviour);

            unitOfWork.Rollback();

            unitOfWork.Commit();
        }

        Assert.IsFalse(commitState.IsSuccessful);
        Assert.IsTrue(commitState.IsFail);

        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister(WellknownDomainObjects.ChangeTracker);
            var instances = register.GetObjectEnumerator().ToList();
            Assert.AreEqual(0, instances.Count);

            unitOfWork.Commit();
        }
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public void Test_DefineVerifying_UnitOfWork_NoCommit()
    {
        var commitState = new UnitOfWorkCommitState();
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var domainBehaviour =
                m_entryPoint.CreateDomainBehaviourWithСonfirmation()
                    .SetSuccessful(
                        () => commitState.IsSuccessful = true,
                        () =>
                        {
                            commitState.IsSuccessful = true;

                            return ValueTask.CompletedTask;
                        })
                    .SetFail(
                        () => commitState.IsFail = true,
                        () =>
                        {
                            commitState.IsFail = true;

                            return ValueTask.CompletedTask;
                        });
            unitOfWork.AddBehaviour(domainBehaviour);
        }

        Assert.IsFalse(commitState.IsSuccessful);
        Assert.IsTrue(commitState.IsFail);

        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister(WellknownDomainObjects.ChangeTracker);
            var instances = register.GetObjectEnumerator().ToList();
            Assert.AreEqual(0, instances.Count);

            unitOfWork.Commit();
        }
    }
}
