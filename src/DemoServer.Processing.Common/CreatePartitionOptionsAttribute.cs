using System;
using Acme.Wattle.Mappers.Interfaces;

namespace Acme.DemoServer.Processing.Common;

/// <summary>
/// Параметры создания партиций таблицы БД.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class CreatePartitionOptionsAttribute : Attribute
{
    private byte? m_fillFactor;

    /// <summary>
    /// Фактор заполнения для таблицы, задаваемый в процентах, от 10 до 100. Значение по умолчанию — 100 (плотное заполнение).
    /// <see href="https://postgrespro.ru/docs/postgresql/current/sql-createtable"/>
    /// </summary>
    public byte FillFactor
    {
        get => throw new NotSupportedException(nameof(FillFactor));
        set => m_fillFactor = value;
    }

    public CreatePartitionOptions GetOptions()
    {
        var result =
            new CreatePartitionOptions
            {
                FillFactor = m_fillFactor,
            };

        return result;
    }
}