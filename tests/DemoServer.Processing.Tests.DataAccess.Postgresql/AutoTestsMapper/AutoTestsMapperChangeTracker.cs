using ShtrihM.DemoServer.Processing.Generated.PostgreSql.Implements;
using ShtrihM.Wattle3.Mappers.Interfaces;

// ReSharper disable once CheckNamespace
namespace ShtrihM.DemoServer.Processing.Generated.Tests;

public partial class AutoTestsMapperChangeTracker
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private IPartitionsManager m_partitions;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    partial void DoSetUp()
    {
        m_partitions = ((MapperChangeTracker)m_mapper).Partitions;

        using var session = m_mappers.OpenSession();
        m_partitions.CreatedDefaultPartition(session);
        session.Commit();
    }
}