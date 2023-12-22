using ShtrihM.DemoServer.Common;
using ShtrihM.Wattle3.Common.Exceptions;
using System;
using System.Collections.Generic;

namespace ShtrihM.DemoServer.Processing.Model.Implements.SystemSettings;

public sealed class SystemSettingsLocal
{
    public static readonly string ProductNameText = "Полнофункциональный демонстрационный сервер на базе библиотеки Wattle3";

    public SystemSettingsLocal(IDictionary<Guid, string> values)
    {
        ProductId = GetValueAsGuid(values, WellknownCommonSystemSettings.ProductId);
        ProductVersion = GetValueAsVersion(values, WellknownCommonSystemSettings.ProductVersion);
        InstallationName = GetValue(values, WellknownCommonSystemSettings.InstallationName);
        ProductName = ProductNameText;
    }

    /// <summary>
    /// Код продукта <seealso cref="WellknownCommonSystemSettings.ProductId"/>.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Версия продукта <seealso cref="WellknownCommonSystemSettings.ProductVersion"/>.
    /// </summary>
    public Version ProductVersion { get; set; }

    /// <summary>
    /// Имя инсталляции <seealso cref="WellknownCommonSystemSettings.InstallationName"/>.
    /// </summary>
    public string InstallationName { get; set; }

    /// <summary>
    /// Имя продукта.
    /// </summary>
    public string ProductName { get; }

    private string GetValue(IDictionary<Guid, string> values, Guid id)
    {
        if (values.TryGetValue(id, out var result))
        {
            return result;
        }

        throw new InternalException($"Не найдена локальная настройка с идентификатором '{id}' ({WellknownCommonSystemSettings.GetDisplayName(id)}).");
    }

    private Version GetValueAsVersion(IDictionary<Guid, string> values, Guid id)
    {
        var text = GetValue(values, id);
        if (Version.TryParse(text, out var result))
        {
            return result;
        }

        throw new InternalException($"не удалось прочитать значение локальной настройки с идентификатором '{id}' ({WellknownCommonSystemSettings.GetDisplayName(id)}).");
    }

    private Guid GetValueAsGuid(IDictionary<Guid, string> values, Guid id)
    {
        var text = GetValue(values, id);
        if (Guid.TryParse(text, out var result))
        {
            return result;
        }

        throw new InternalException($"не удалось прочитать значение локальной настройки с идентификатором '{id}' ({WellknownCommonSystemSettings.GetDisplayName(id)}).");
    }
}