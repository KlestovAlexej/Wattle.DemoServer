using NUnit.Framework;
using Acme.DemoServer.Processing.Common;
using Acme.DemoServer.Processing.Model.Interfaces;
using Acme.DemoServer.Processing.Tests.Model.Environment;
using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.Testing;
using System.Linq;
using System.Threading.Tasks;
using Acme.DemoServer.Processing.Model.DomainObjects.SystemLog;

namespace Acme.DemoServer.Processing.Tests.Model;

[TestFixture]
public class TestsDomainObjectSystemLog : BaseTestsDomainObjects
{
    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public async Task Test()
    {
        var template =
            new DomainObjectSystemLog.Template(
                ProviderRandomValues.GetInt32(),
                ProviderRandomValues.GetInt32(),
                ProviderRandomValues.GetString(),
                ProviderRandomValues.GetString());
        var nowDateTime = m_entryPoint.TimeService.Now;

        await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
            async (uow, cancellationToken) =>
            {
                var register = uow.Registers.GetRegister(WellknownDomainObjects.SystemLog);
                await register.NewAsync(template, cancellationToken);

                await uow.CommitAsync(cancellationToken);
            });

        // ReSharper disable once MethodHasAsyncOverload
        // ReSharper disable once UseAwaitUsing
        // ReSharper disable once ConvertToUsingDeclaration
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister(WellknownDomainObjects.SystemLog);
            var instances = register.GetObjectEnumerator<IDomainObjectSystemLog>().ToList();
            Assert.AreEqual(1, instances.Count);
            var instance = instances[0];
            Assert.LessOrEqual(nowDateTime.AddMinutes(-5), instance.CreateDate);
            Assert.GreaterOrEqual(nowDateTime.AddMinutes(5), instance.CreateDate);
            Assert.AreEqual(template.Message, instance.Message);
            Assert.AreEqual(template.Data, instance.Data);
            Assert.AreEqual(template.Type, instance.Type);
            Assert.AreEqual(template.Code, instance.Code);
        }
    }
}