using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Model.Implements;
using ShtrihM.DemoServer.Processing.Tests.Model.Environment;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Testing;
using System;
using System.Linq;
using System.Threading.Tasks;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.Wattle3.Common.Exceptions;

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
            using var dbContext = unitOfWork.NewDbContext();

            Assert.IsNotNull(dbContext.Database.GetDbConnection());
            Assert.IsNotNull(dbContext.Database.CurrentTransaction);

            var items = dbContext.Systemsetting.Select(s => s).ToList();
            Assert.AreEqual(3, items.Count);

            dbContext.Systemsetting.Add(
                new()
                {
                    Id = new("AE46F447-2B40-4428-82A5-C836A860674B"),
                    Name = "Name",
                    Value = "Value",
                });

            dbContext.SaveChanges();

            items = dbContext.Systemsetting.Select(s => s).ToList();
            Assert.AreEqual(4, items.Count);
        }

        using (var unitOfWork = (UnitOfWork)m_entryPoint.CreateUnitOfWork())
        {
            using var dbContext = unitOfWork.NewDbContext();

            Assert.IsNotNull(dbContext.Database.GetDbConnection());
            Assert.IsNotNull(dbContext.Database.CurrentTransaction);

            var items = dbContext.Systemsetting.Select(s => s).ToList();
            Assert.AreEqual(3, items.Count);

            dbContext.Systemsetting.Add(
                new()
                {
                    Id = new("AE46F447-2B40-4428-82A5-C836A860674B"),
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
            using var dbContext = unitOfWork.NewDbContext();

            Assert.IsNotNull(dbContext.Database.GetDbConnection());
            Assert.IsNotNull(dbContext.Database.CurrentTransaction);

            var items = dbContext.Systemsetting.Select(s => s).ToList();
            Assert.AreEqual(4, items.Count);

            var item =
                items.SingleOrDefault(
                    i => i.Id == new Guid("AE46F447-2B40-4428-82A5-C836A860674B"));
            Assert.IsNotNull(item);
            Assert.AreEqual("Name", item!.Name);
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
            await using var dbContext = await unitOfWork.NewDbContextAsync();

            Assert.IsNotNull(dbContext.Database.GetDbConnection());
            Assert.IsNotNull(dbContext.Database.CurrentTransaction);

            var items = dbContext.Systemsetting.Select(s => s).ToList();
            Assert.AreEqual(3, items.Count);

            dbContext.Systemsetting.Add(
                new()
                {
                    Id = new("AE46F447-2B40-4428-82A5-C836A860674B"),
                    Name = "Name",
                    Value = "Value",
                });

            await dbContext.SaveChangesAsync();

            items = dbContext.Systemsetting.Select(s => s).ToList();
            Assert.AreEqual(4, items.Count);
        }

        await using (var unitOfWork = (UnitOfWork)await m_entryPoint.CreateUnitOfWorkAsync())
        {
            await using var dbContext = await unitOfWork.NewDbContextAsync();

            Assert.IsNotNull(dbContext.Database.GetDbConnection());
            Assert.IsNotNull(dbContext.Database.CurrentTransaction);

            var items = dbContext.Systemsetting.Select(s => s).ToList();
            Assert.AreEqual(3, items.Count);

            dbContext.Systemsetting.Add(
                new()
                {
                    Id = new("AE46F447-2B40-4428-82A5-C836A860674B"),
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
            await using var dbContext = await unitOfWork.NewDbContextAsync();

            Assert.IsNotNull(dbContext.Database.GetDbConnection());
            Assert.IsNotNull(dbContext.Database.CurrentTransaction);

            var items = dbContext.Systemsetting.Select(s => s).ToList();
            Assert.AreEqual(4, items.Count);

            var item =
                items.SingleOrDefault(
                    i => i.Id == new Guid("AE46F447-2B40-4428-82A5-C836A860674B"));
            Assert.IsNotNull(item);
            Assert.AreEqual("Name", item!.Name);
            Assert.AreEqual("Value", item.Value);

            await unitOfWork.CommitAsync();
        }
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public void Test_DefineVerifying_UnitOfWork_Successful()
    {
        var commitState1 = new UnitOfWorkCommitState();
        var commitState2 = new UnitOfWorkCommitState();
        var commitState3 = new UnitOfWorkCommitState();
        var commitState4= new UnitOfWorkCommitState();
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            Assert.IsFalse(unitOfWork.IsDefinedCommitVerifying);

            {
                var internalException =
                    Assert.Throws<InternalException>(
                        () => m_entryPoint.CurrentUnitOfWork.CreateDomainBehaviourWithСonfirmation());
                Assert.AreEqual("Стратегия проверки успешности завершения IUnitOfWork не определена.", internalException!.Message, internalException.Message);

                var domainBehaviour =
                    m_entryPoint.CurrentUnitOfWork.CreateDomainBehaviourWithСonfirmation(false)
                        .SetSuccessful(
                            () => commitState1.IsSuccessful = true,
                            () =>
                            {
                                commitState1.IsSuccessful = true;

                                return ValueTask.CompletedTask;
                            })
                        .SetFail(
                            () => commitState1.IsFail = true,
                            () =>
                            {
                                commitState1.IsFail = true;

                                return ValueTask.CompletedTask;
                            });
                unitOfWork.AddBehaviour(domainBehaviour);
            }

            Assert.IsFalse(unitOfWork.IsDefinedCommitVerifying);

            {
                var domainBehaviour =
                    m_entryPoint.CurrentUnitOfWork.CreateDomainBehaviourWithСonfirmation()
                        .SetSuccessful(
                            () => commitState2.IsSuccessful = true,
                            () =>
                            {
                                commitState2.IsSuccessful = true;

                                return ValueTask.CompletedTask;
                            })
                        .SetFail(
                            () => commitState2.IsFail = true,
                            () =>
                            {
                                commitState2.IsFail = true;

                                return ValueTask.CompletedTask;
                            });
                unitOfWork.AddBehaviour(domainBehaviour);
            }

            Assert.IsFalse(unitOfWork.IsDefinedCommitVerifying);

            var commitVerifying = unitOfWork.CommitVerifying;
            Assert.IsNotNull(commitVerifying);
            Assert.IsTrue(ReferenceEquals(commitVerifying, unitOfWork.CommitVerifying));

            Assert.IsFalse(unitOfWork.IsDefinedCommitVerifying);

            {
                var domainBehaviour =
                    m_entryPoint.CurrentUnitOfWork.CreateDomainBehaviourWithСonfirmation<IMapperDemoObject>(-1)
                        .SetSuccessful(
                            () => commitState3.IsSuccessful = true,
                            () =>
                            {
                                commitState3.IsSuccessful = true;

                                return ValueTask.CompletedTask;
                            })
                        .SetFail(
                            () => commitState3.IsFail = true,
                            () =>
                            {
                                commitState3.IsFail = true;

                                return ValueTask.CompletedTask;
                            });
                unitOfWork.AddBehaviour(domainBehaviour);
            }

            Assert.IsTrue(unitOfWork.IsDefinedCommitVerifying);
            Assert.IsTrue(ReferenceEquals(commitVerifying, unitOfWork.CommitVerifying));

            {
                var domainBehaviour =
                    m_entryPoint.CurrentUnitOfWork.CreateDomainBehaviourWithСonfirmation<IMapperDemoObjectX>(-2)
                        .SetSuccessful(
                            () => commitState4.IsSuccessful = true,
                            () =>
                            {
                                commitState4.IsSuccessful = true;

                                return ValueTask.CompletedTask;
                            })
                        .SetFail(
                            () => commitState4.IsFail = true,
                            () =>
                            {
                                commitState4.IsFail = true;

                                return ValueTask.CompletedTask;
                            });
                unitOfWork.AddBehaviour(domainBehaviour);
            }

            Assert.IsTrue(unitOfWork.IsDefinedCommitVerifying);
            Assert.IsTrue(ReferenceEquals(commitVerifying, unitOfWork.CommitVerifying));

            unitOfWork.Commit();
        }

        Assert.IsTrue(commitState1.IsSuccessful);
        Assert.IsFalse(commitState1.IsFail);

        Assert.IsTrue(commitState2.IsSuccessful);
        Assert.IsFalse(commitState2.IsFail);

        Assert.IsTrue(commitState3.IsSuccessful);
        Assert.IsFalse(commitState3.IsFail);

        Assert.IsTrue(commitState4.IsSuccessful);
        Assert.IsFalse(commitState4.IsFail);

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
    public void Test_DefineVerifying_UnitOfWork_Fail()
    {
        var commitState1 = new UnitOfWorkCommitState();
        var commitState2 = new UnitOfWorkCommitState();
        var commitState3 = new UnitOfWorkCommitState();
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var commitVerifying = unitOfWork.CommitVerifying;
            Assert.IsNotNull(commitVerifying);
            Assert.IsTrue(ReferenceEquals(commitVerifying, unitOfWork.CommitVerifying));

            {
                var domainBehaviour =
                    m_entryPoint.CurrentUnitOfWork.CreateDomainBehaviourWithСonfirmation<IMapperDemoObject>(-1)
                        .SetSuccessful(
                            () => commitState1.IsSuccessful = true,
                            () =>
                            {
                                commitState1.IsSuccessful = true;

                                return ValueTask.CompletedTask;
                            })
                        .SetFail(
                            () => commitState1.IsFail = true,
                            () =>
                            {
                                commitState1.IsFail = true;

                                return ValueTask.CompletedTask;
                            });
                unitOfWork.AddBehaviour(domainBehaviour);
            }

            {
                var domainBehaviour =
                    m_entryPoint.CurrentUnitOfWork.CreateDomainBehaviourWithСonfirmation()
                        .SetSuccessful(
                            () => commitState2.IsSuccessful = true,
                            () =>
                            {
                                commitState2.IsSuccessful = true;

                                return ValueTask.CompletedTask;
                            })
                        .SetFail(
                            () => commitState2.IsFail = true,
                            () =>
                            {
                                commitState2.IsFail = true;

                                return ValueTask.CompletedTask;
                            });
                unitOfWork.AddBehaviour(domainBehaviour);
            }

            {
                var domainBehaviour =
                    m_entryPoint.CurrentUnitOfWork.CreateDomainBehaviourWithСonfirmation<IMapperDemoObjectX>(-2)
                        .SetSuccessful(
                            () => commitState3.IsSuccessful = true,
                            () =>
                            {
                                commitState3.IsSuccessful = true;

                                return ValueTask.CompletedTask;
                            })
                        .SetFail(
                            () => commitState3.IsFail = true,
                            () =>
                            {
                                commitState3.IsFail = true;

                                return ValueTask.CompletedTask;
                            });
                unitOfWork.AddBehaviour(domainBehaviour);
            }
        }

        Assert.IsFalse(commitState1.IsSuccessful);
        Assert.IsTrue(commitState1.IsFail);

        Assert.IsFalse(commitState2.IsSuccessful);
        Assert.IsTrue(commitState2.IsFail);

        Assert.IsFalse(commitState3.IsSuccessful);
        Assert.IsTrue(commitState3.IsFail);

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
    public void Test_DefineVerifying_UnitOfWork_Fail_2()
    {
        var commitState1 = new UnitOfWorkCommitState();
        var commitState2 = new UnitOfWorkCommitState();
        var commitState3 = new UnitOfWorkCommitState();
        var commitState4 = new UnitOfWorkCommitState();
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            Assert.IsFalse(unitOfWork.IsDefinedCommitVerifying);

            {
                var internalException =
                    Assert.Throws<InternalException>(
                        () => m_entryPoint.CurrentUnitOfWork.CreateDomainBehaviourWithСonfirmation());
                Assert.AreEqual("Стратегия проверки успешности завершения IUnitOfWork не определена.", internalException!.Message, internalException.Message);

                var domainBehaviour =
                    m_entryPoint.CurrentUnitOfWork.CreateDomainBehaviourWithСonfirmation(false)
                        .SetSuccessful(
                            () => commitState1.IsSuccessful = true,
                            () =>
                            {
                                commitState1.IsSuccessful = true;

                                return ValueTask.CompletedTask;
                            })
                        .SetFail(
                            () => commitState1.IsFail = true,
                            () =>
                            {
                                commitState1.IsFail = true;

                                return ValueTask.CompletedTask;
                            });
                unitOfWork.AddBehaviour(domainBehaviour);
            }

            Assert.IsFalse(unitOfWork.IsDefinedCommitVerifying);

            {
                var domainBehaviour =
                    m_entryPoint.CurrentUnitOfWork.CreateDomainBehaviourWithСonfirmation()
                        .SetSuccessful(
                            () => commitState2.IsSuccessful = true,
                            () =>
                            {
                                commitState2.IsSuccessful = true;

                                return ValueTask.CompletedTask;
                            })
                        .SetFail(
                            () => commitState2.IsFail = true,
                            () =>
                            {
                                commitState2.IsFail = true;

                                return ValueTask.CompletedTask;
                            });
                unitOfWork.AddBehaviour(domainBehaviour);
            }

            Assert.IsFalse(unitOfWork.IsDefinedCommitVerifying);

            var commitVerifying = unitOfWork.CommitVerifying;
            Assert.IsNotNull(commitVerifying);
            Assert.IsTrue(ReferenceEquals(commitVerifying, unitOfWork.CommitVerifying));

            Assert.IsFalse(unitOfWork.IsDefinedCommitVerifying);

            {
                var domainBehaviour =
                    m_entryPoint.CurrentUnitOfWork.CreateDomainBehaviourWithСonfirmation<IMapperDemoObject>(-1)
                        .SetSuccessful(
                            () => commitState3.IsSuccessful = true,
                            () =>
                            {
                                commitState3.IsSuccessful = true;

                                return ValueTask.CompletedTask;
                            })
                        .SetFail(
                            () => commitState3.IsFail = true,
                            () =>
                            {
                                commitState3.IsFail = true;

                                return ValueTask.CompletedTask;
                            });
                unitOfWork.AddBehaviour(domainBehaviour);
            }

            Assert.IsTrue(unitOfWork.IsDefinedCommitVerifying);
            Assert.IsTrue(ReferenceEquals(commitVerifying, unitOfWork.CommitVerifying));

            {
                var domainBehaviour =
                    m_entryPoint.CurrentUnitOfWork.CreateDomainBehaviourWithСonfirmation<IMapperDemoObjectX>(-2)
                        .SetSuccessful(
                            () => commitState4.IsSuccessful = true,
                            () =>
                            {
                                commitState4.IsSuccessful = true;

                                return ValueTask.CompletedTask;
                            })
                        .SetFail(
                            () => commitState4.IsFail = true,
                            () =>
                            {
                                commitState4.IsFail = true;

                                return ValueTask.CompletedTask;
                            });
                unitOfWork.AddBehaviour(domainBehaviour);
            }

            Assert.IsTrue(unitOfWork.IsDefinedCommitVerifying);
            Assert.IsTrue(ReferenceEquals(commitVerifying, unitOfWork.CommitVerifying));
        }

        Assert.IsFalse(commitState1.IsSuccessful);
        Assert.IsTrue(commitState1.IsFail);

        Assert.IsFalse(commitState2.IsSuccessful);
        Assert.IsTrue(commitState2.IsFail);

        Assert.IsFalse(commitState3.IsSuccessful);
        Assert.IsTrue(commitState3.IsFail);

        Assert.IsFalse(commitState4.IsSuccessful);
        Assert.IsTrue(commitState4.IsFail);

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
    public void Test_DefineVerifying_UnitOfWork_Rollback()
    {
        var commitState = new UnitOfWorkCommitState();
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var domainBehaviour =
                m_entryPoint.CurrentUnitOfWork.CreateDomainBehaviourWithСonfirmation(false)
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
                m_entryPoint.CurrentUnitOfWork.CreateDomainBehaviourWithСonfirmation(false)
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
