using System.Linq;
using NUnit.Framework;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.DemoServer.Processing.Tests.Model.Environment;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Testing;

namespace ShtrihM.DemoServer.Processing.Tests.Model;

[TestFixture]
public class TestsPartitionsSponsor : BaseTestsDomainObjects
{
    protected override void DoPreCreateDb()
    {
        base.DoPreCreateDb();

        m_useTablespaces = true;
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public void Test()
    {
        var mapperTablePartition = m_entryPoint.Mappers.GetMapper<IMapperTablePartition>();
        using var mappersSession = m_entryPoint.Mappers.OpenSession();
        var list = mapperTablePartition.GetEnumeratorRaw(mappersSession).ToList();
        Assert.AreEqual(8, list.Count);
    }
}