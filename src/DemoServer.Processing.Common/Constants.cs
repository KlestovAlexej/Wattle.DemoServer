using Acme.Wattle.Primitives;
using System;

namespace Acme.DemoServer.Processing.Common;

/// <summary>
/// Общие константы.
/// </summary>
public static class Constants
{

    /// <summary>
    /// Код продукта.
    /// </summary>
    public static readonly Guid ProductId = new("9F8FD1D7-8D62-4B73-8A43-9E42518A4A57");

    /// <summary>
    /// Уровень кодирования идентификатор групп идентити мапперов.
    /// </summary>
    public const ComplexIdentity.Level MappersComplexIdentityLevel = ComplexIdentity.Level.L2;

    /// <summary>
    /// Объект - Системный лог.
    /// Максимальный размер поля Message.
    /// </summary>
    public const int SystemLogFieldMaxSizeMessage = 1024;
}