using NUnit.Framework;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.DemoServer.Processing.Generated.PostgreSql.Implements;
using ShtrihM.Wattle3.Mappers.Interfaces;

// ReSharper disable once CheckNamespace
namespace ShtrihM.DemoServer.Processing.Generated.Tests;

public partial class AutoTestsMapperSystemLog
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private IPartitionsManager m_partitions;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    partial void DoSetUp()
    {
        m_partitions = ((MapperSystemLog)m_mapper).Partitions;

        using var session = m_mappers.OpenSession();
        m_partitions.CreatedDefaultPartition(session);
        session.Commit();
    }

    [Test]
    [Category("Unit")]
    [Timeout(300000)]
    [Description("Создание и Получение")]
    public void Test_New_Get2()
    {
        DoTest_New_Get();

        var template = GetRandomNew(m_context);
        SystemLogDtoActual dataNew;
        // ReSharper disable once ConvertToUsingDeclaration
        using (var session = m_mappers.OpenSession())
        {
            dataNew = m_mapper.New(session, template);
            AssertAreEqual(template, dataNew, m_context);

            session.Commit();
        }

        // ReSharper disable once ConvertToUsingDeclaration
        using (var mappersSession = m_mappers.OpenSession())
        {
            var data = m_mapper.Get(mappersSession, template.Id);
            AssertAreEqual(template, data, m_context);
            AssertAreEqual(dataNew, data, m_context);
        }
    }
}