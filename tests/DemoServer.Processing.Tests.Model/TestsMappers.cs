using NUnit.Framework;
using Acme.DemoServer.Processing.Generated.PostgreSql.Implements;
using Acme.DemoServer.Processing.Tests.Model.Environment;
using Acme.Wattle.Testing;

namespace Acme.DemoServer.Processing.Tests.Model;

[TestFixture]
public class TestsMappers : BaseTestsWithEntryPoint
{
    /// <summary>
    /// Проверка что для всех кеширующих мапперов определены кэши <seealso cref="Mappers.OnExitConstructor"/>
    /// </summary>
    [Test]
    [Timeout(TestTimeout.Short)]
    [Category(TestCategory.Short)]
    [Description("Проверка что для всех кеширующих мапперов определены кэши")]
    public void Test()
    {
        foreach (var id in DbMappersSchemaXmlBuilder.Cached)
        {
            var mapper = m_entryPoint.Mappers.GetMapper(id);
            var infrastructureMonitor = mapper.InfrastructureMonitor;
            Assert.IsNotNull(infrastructureMonitor, id.ToString());
            Assert.IsNotNull(infrastructureMonitor!.MapperId, id.ToString());
        }
    }
}