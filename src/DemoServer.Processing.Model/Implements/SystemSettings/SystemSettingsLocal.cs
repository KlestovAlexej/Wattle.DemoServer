using Acme.DemoServer.Common;
using Acme.Wattle.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Acme.DemoServer.Processing.Model.Implements.SystemSettings;

[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public sealed class SystemSettingsLocal
{
    public static readonly string ProductNameText = "������������������� ���������������� ������ �� ���� ���������� Wattle";

    public SystemSettingsLocal(IDictionary<Guid, string> values)
    {
        ProductId = GetValueAsGuid(values, WellknownCommonSystemSettings.ProductId);
        ProductVersion = GetValueAsVersion(values, WellknownCommonSystemSettings.ProductVersion);
        InstallationName = GetValue(values, WellknownCommonSystemSettings.InstallationName);
        ProductName = ProductNameText;
    }

    /// <summary>
    /// ��� �������� <seealso cref="WellknownCommonSystemSettings.ProductId"/>.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// ������ �������� <seealso cref="WellknownCommonSystemSettings.ProductVersion"/>.
    /// </summary>
    public Version ProductVersion { get; set; }

    /// <summary>
    /// ��� ����������� <seealso cref="WellknownCommonSystemSettings.InstallationName"/>.
    /// </summary>
    public string InstallationName { get; set; }

    /// <summary>
    /// ��� ��������.
    /// </summary>
    public string ProductName { get; }

    private string GetValue(IDictionary<Guid, string> values, Guid id)
    {
        if (values.TryGetValue(id, out var result))
        {
            return result;
        }

        throw new InternalException($"�� ������� ��������� ��������� � ��������������� '{id}' ({WellknownCommonSystemSettings.GetDisplayName(id)}).");
    }

    private Version GetValueAsVersion(IDictionary<Guid, string> values, Guid id)
    {
        var text = GetValue(values, id);
        if (Version.TryParse(text, out var result))
        {
            return result;
        }

        throw new InternalException($"�� ������� ��������� �������� ��������� ��������� � ��������������� '{id}' ({WellknownCommonSystemSettings.GetDisplayName(id)}).");
    }

    private Guid GetValueAsGuid(IDictionary<Guid, string> values, Guid id)
    {
        var text = GetValue(values, id);
        if (Guid.TryParse(text, out var result))
        {
            return result;
        }

        throw new InternalException($"�� ������� ��������� �������� ��������� ��������� � ��������������� '{id}' ({WellknownCommonSystemSettings.GetDisplayName(id)}).");
    }
}