using System;

namespace Acme.DemoServer.Processing.Common;

/// <summary>
/// Использовать общие настройки параметров создания партиций таблиц БД.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class UseDefaultCreatePartitionOptionsAttribute : Attribute
{
}