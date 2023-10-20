using NUnit.Framework;
using ShtrihM.DemoServer.Processing.Tests.Model.Environment;
using ShtrihM.Wattle3.Testing;

namespace ShtrihM.DemoServer.Processing.Tests.Model;

[TestFixture]
public class TestsMappers : BaseTestsWithEntryPoint
{
    [Test]
    [Timeout(TestTimeout.Short)]
    [Category(TestCategory.Short)]
    public void Test()
    {
        foreach (var id in DbMappersSchemaXmlBuilder.Cached)
        {
            var mapper = m_entryPoint.Mappers.GetMapper(id);
            var infrastructureMonitor = mapper.InfrastructureMonitor;
            Assert.IsNotNull(infrastructureMonitor, id.ToString());
            Assert.IsNotNull(infrastructureMonitor.MapperId, id.ToString());
        }
    }
}