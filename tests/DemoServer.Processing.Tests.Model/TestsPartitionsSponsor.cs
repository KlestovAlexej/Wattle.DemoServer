using System;
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
        Assert.AreEqual(0, m_entryPoint.PartitionsDay.GetDayIndex(new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)));

        var mapperTablePartition = m_entryPoint.Mappers.GetMapper<IMapperTablePartition>();
        using var mappersSession = m_entryPoint.Mappers.OpenSession();
        var list = mapperTablePartition.GetEnumeratorRaw(mappersSession).ToList();
        Assert.AreEqual(8, list.Count);

        var existsPartitions = mapperTablePartition.Partitions.GetExistsPartitions(mappersSession);
        Assert.LessOrEqual(2, existsPartitions.Count);
        var nowDayIndex = m_entryPoint.PartitionsDay.NowDayIndex;
        Assert.IsTrue(existsPartitions.Any(p => p.MinGroupId == nowDayIndex));
        Assert.IsTrue(existsPartitions.Any(p => p.MinGroupId == nowDayIndex + 1));
    }
}