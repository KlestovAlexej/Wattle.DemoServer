using ShtrihM.DemoServer.Processing.Generated.PostgreSql.Implements;
using ShtrihM.Wattle3.Mappers.Interfaces;

// ReSharper disable once CheckNamespace
namespace ShtrihM.DemoServer.Processing.Generated.Tests;

public partial class AutoTestsMapperChangeTracker
{
    private IPartitionsManager m_partitions;

    partial void DoSetUp()
    {
        m_partitions = ((MapperChangeTracker)m_mapper).Partitions;

        using var session = m_mappers.OpenSession();
        m_partitions.CreatedDefaultPartition(session);
        session.Commit();
    }
}