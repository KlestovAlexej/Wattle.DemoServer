using NUnit.Framework;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Testing;
using ShtrihM.Wattle3.CodeGeneration.Common;
using ShtrihM.Wattle3.CodeGeneration.Generators.Schem;
using ShtrihM.Wattle3.Testing;
using System;
using System.Collections.Generic;
using System.IO;

namespace ShtrihM.DemoServer.Processing.Tests;

[TestFixture]
[Explicit]
public class DbMappersSchemaXmlBuilder
{
    private readonly Dictionary<Guid, SchemaMapperDeleteMode> m_deleteMode;
    private readonly HashSet<Guid> m_optimisticConcurrency;

    public static readonly HashSet<Guid> Cached;

    static DbMappersSchemaXmlBuilder()
    {
        Cached =
            new HashSet<Guid>
            {
                WellknownDomainObjects.DemoObject,
                WellknownDomainObjects.DemoObjectX,
            };
    }

    // ReSharper disable once ConvertConstructorToMemberInitializers
    public DbMappersSchemaXmlBuilder()
    {
        m_deleteMode =
            new Dictionary<Guid, SchemaMapperDeleteMode>
            {
                {WellknownDomainObjects.DemoObject, SchemaMapperDeleteMode.Disabled},
                {WellknownDomainObjects.DemoObjectX, SchemaMapperDeleteMode.Delete},
            };

        m_optimisticConcurrency =
            new HashSet<Guid>
            {
                WellknownDomainObjects.DemoObject,
                WellknownDomainObjects.DemoObjectX,
            };
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Description("Генератор XML модели")]
    public void Test()
    {
        var schemaModel = SchemaModel.FromType(typeof(WellknownDomainObjectFields));

        foreach (var schemaModelMapper in schemaModel.Mappers)
        {
            foreach (var schemaMapper in schemaModelMapper.Mappers)
            {
                Apply(schemaMapper);
            }
        }

        var xml = schemaModel.ToXml();
        var fileName = Path.Combine(ProviderProjectBasePath.ProjectPath, @"src\DemoServer.Processing.Model\DbMappers.Schema.xml");
        Console.WriteLine(fileName);
        File.WriteAllText(fileName, xml);
    }

    private void Apply(SchemaMapper schema)
    {
        if (schema == null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        if (m_deleteMode.TryGetValue(schema.Id, out var expectedDeleteMode))
        {
            if (schema.DeleteMode != expectedDeleteMode)
            {
                Assert.Fail($"Режим удаления объекта '{schema.DeleteMode}' доменного объекта '{schema.Name}' не соответствует ожидаемому значению '{expectedDeleteMode}'.");
            }
        }
        else
        {
            if (schema.DeleteMode != SchemaMapperDeleteMode.Disabled)
            {
                Assert.Fail($"Режим удаления объекта '{schema.DeleteMode}' доменного объекта '{schema.Name}' не соответствует ожидаемому значению '{SchemaMapperDeleteMode.Disabled}'.");
            }
        }

        if (m_optimisticConcurrency.Contains(schema.Id))
        {
            if (schema.RevisionField != null)
            {
                if (false == schema.RevisionField.IsVersion)
                {
                    Assert.Fail($"Для доменного объекта '{schema.Name}' с ожидаемомой оптимистической конкуренцией в поле ревизии '{nameof(schema.RevisionField)}' не указан признак версионирования.");
                }
            }
            else
            {
                Assert.Fail($"Для доменного объекта '{schema.Name}' с ожидаемомой оптимистической конкуренцией не определено поле ревизии '{nameof(schema.RevisionField)}'.");
            }
        }
        else
        {
            if (schema.RevisionField is { IsVersion: true })
            {
                Assert.Fail($"Для доменного объекта '{schema.Name}' определена оптимистическая конкуренция.");
            }
        }

        if (Cached.Contains(schema.Id))
        {
            if (false == schema.IsCached)
            {
                Assert.Fail($"Для доменного объекта '{schema.Name}' не указано кеширование.");
            }
        }
        else
        {
            if (schema.IsCached)
            {
                Assert.Fail($"Для доменного объекта '{schema.Name}' указано кеширование.");
            }
        }
    }
}