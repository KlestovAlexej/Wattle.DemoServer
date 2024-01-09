using Newtonsoft.Json;
using ShtrihM.DemoServer.Processing.DataAccess.Interface;
using ShtrihM.Wattle3.Json;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorkLocks;

namespace ShtrihM.DemoServer.Processing.Model.Implements.SystemSettings;

[SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Global")]
public sealed class SystemSettings
{
    public static readonly string SectionName = "SystemSettings";

    // ReSharper disable once ConvertConstructorToMemberInitializers
    public SystemSettings()
    {
        MappersFeaturesValidateUpdateResults =
            new SettingValue<bool>(
                default,
                "Проверять каждое обновление БД на корректность брутальным способом");

        InstanceId =
            new SettingValue<Guid>(
                default,
                "Идентификатор экземпляра сервера");

        InstanceName =
            new SettingValue<string>(
                default!,
                "Текстовый идентификатор экземпляра сервера");

        UnitOfWorkLocksSettings =
            new SettingValue<UnitOfWorkLocksSettings>(
                default!,
                "Настройки пулов лок-объектов уровня IUnitOfWork");

        ExceptionPolicySettings =
            new SettingValue<ExceptionPolicySettings>(
                default!,
                "Настройки уведомления об исключениях системы");

        IdentityCachesSettings =
            new SettingValue<IdentityCachesSettings>(
                default!,
                "Настройки кэширующих провайдеров идентити объектов");

        MappersCacheActualStateDtoSettings =
            new SettingValue<MappersCacheActualStateDtoSettings>(
                default!,
                "Настройки кэшей актуальных данных состояний доменнй объектов в БД");

        QueueThreadsSizeEmergencyDomainBehaviour =
            new SettingValue<int>(
                default,
                "Очередь обработки аварийных ситуаций доменного поведения - количество потоков обработки");

        QueueEmergencyTimeoutEmergencyDomainBehaviour =
            new SettingValue<TimeSpan>(
                default,
                "Очередь обработки аварийных ситуаций доменного поведения - интервал аварийного ожидания повторной обработки");

        SqlCommandTimeout =
            new SettingValue<int>(
                default,
                "Интервал ожидания исполнения SQL-команд");

        DebugMode =
            new SettingValue<bool>(
                default,
                "Отладочный режим");

        TimeStatisticsStep =
            new SettingValue<TimeSpan>(
                default,
                "Интервал аккумуляции статистики");

        ConnectionString =
            new SettingValue<string>(
                default!,
                "Строка подключения к БД");

        PartitionsSponsorSettings =
            new SettingValue<PartitionsSponsorSettings>(
                default!,
                "Настройки создателя партиций БД");

        DomainObjectRegistersSettings =
            new SettingValue<DomainObjectRegistersSettings>(
                default!,
                "Настройки реестров доменных объектов");

        UpdateKeyExpirationTimeout =
            new(
                default,
                "Интервал действия ключа контроля изменений");
    }

    /// <summary>
    /// Интервал действия ключа контроля изменений.
    /// </summary>
    [Description("Интервал действия ключа контроля изменений")]
    public SettingValue<TimeSpan> UpdateKeyExpirationTimeout { get; set; }

    /// <summary>
    /// Настройки реестров доменных объектов.
    /// </summary>
    [Description("Настройки реестров доменных объектов")]
    [JsonRequired]
    public SettingValue<DomainObjectRegistersSettings> DomainObjectRegistersSettings { get; set; }

    /// <summary>
    /// Настройки создателя партиций БД.
    /// </summary>
    [Description("Настройки создателя партиций БД")]
    public SettingValue<PartitionsSponsorSettings> PartitionsSponsorSettings { get; set; }

    /// <summary>
    /// Идентификатор экземпляра сервера.
    /// </summary>
    [JsonRequired]
    public SettingValue<Guid> InstanceId { get; set; }

    /// <summary>
    /// Текстовый идентификатор экземпляра сервера.
    /// </summary>
    [JsonRequired]
    public SettingValue<string> InstanceName { get; set; }

    /// <summary>
    /// Настройки пулов лок-объектов уровня <see cref="IUnitOfWork"/>.
    /// </summary>
    [JsonRequired]
    public SettingValue<UnitOfWorkLocksSettings> UnitOfWorkLocksSettings { get; set; }

    /// <summary>
    /// Настройки уведомления об исключениях системы.
    /// </summary>
    [JsonRequired]
    public SettingValue<ExceptionPolicySettings> ExceptionPolicySettings { get; set; }

    /// <summary>
    /// Настройки кэшей актуальных данных состояний доменнй объектов в БД.
    /// </summary>
    [JsonRequired]
    public SettingValue<MappersCacheActualStateDtoSettings> MappersCacheActualStateDtoSettings { get; set; }

    /// <summary>
    /// Очередь обработки аварийных ситуаций доменного поведения - количество потоков обработки.
    /// </summary>
    [JsonRequired]
    public SettingValue<int> QueueThreadsSizeEmergencyDomainBehaviour { get; set; }

    /// <summary>
    /// Очередь обработки аварийных ситуаций доменного поведения - интервал аварийного ожидания повторной обработки.
    /// </summary>
    [JsonRequired]
    public SettingValue<TimeSpan> QueueEmergencyTimeoutEmergencyDomainBehaviour { get; set; }

    /// <summary>
    /// Настройки кэширующих провайдеров идентити объектов.
    /// </summary>
    [JsonRequired]
    public SettingValue<IdentityCachesSettings> IdentityCachesSettings { get; set; }

    /// <summary>
    /// Строка подключения к БД.
    /// </summary>
    [JsonRequired]
    public SettingValue<string> ConnectionString { get; set; }

    /// <summary>
    /// Интервал ожидания исполнения SQL-команд.
    /// </summary>
    [JsonRequired]
    public SettingValue<int> SqlCommandTimeout { get; set; }

    /// <summary>
    /// Проверять каждое обновление БД на корректность брутальным способом.
    /// </summary>
    [JsonRequired]
    public SettingValue<bool> MappersFeaturesValidateUpdateResults { get; set; }

    /// <summary>
    /// Отладочный режим.
    /// </summary>
    [JsonRequired]
    public SettingValue<bool> DebugMode { get; set; }

    /// <summary>
    /// Интервал аккумуляции статистики.
    /// </summary>
    [JsonRequired]
    public SettingValue<TimeSpan> TimeStatisticsStep { get; set; }

    public static SystemSettings GetDefault()
    {
        var result =
            new SystemSettings
            {
                UnitOfWorkLocksSettings =
                {
                    Value = Wattle3.DomainObjects.UnitOfWorkLocks.UnitOfWorkLocksSettings.GetDefault()
                },

                ExceptionPolicySettings =
                {
                    Value = Implements.SystemSettings.ExceptionPolicySettings.GetDefault()
                },

                IdentityCachesSettings =
                {
                    Value = Implements.SystemSettings.IdentityCachesSettings.GetDefault()
                },

                MappersCacheActualStateDtoSettings =
                {
                    Value = DataAccess.Interface.MappersCacheActualStateDtoSettings.GetDefault()
                },

                QueueThreadsSizeEmergencyDomainBehaviour =
                {
                    Value = 2
                },

                QueueEmergencyTimeoutEmergencyDomainBehaviour =
                {
                    Value = TimeSpan.FromMilliseconds(500)
                },

                SqlCommandTimeout =
                {
                    Value = 0
                },

                DebugMode =
                {
                    Value = false
                },

                TimeStatisticsStep =
                {
                    Value = TimeSpan.FromMinutes(30)
                },

                ConnectionString =
                {
                    Value = string.Empty
                },

                InstanceId =
                {
#if BUILD_PROD
                    Value = new Guid("10000000-0000-0000-0000-000000000000"),
#elif BUILD_TEST
                    Value = new Guid("77777777-7777-7777-7777-777777777777"),
#else
                    Value = new Guid("55555555-5555-5555-5555-555555555555"),
#endif
                },

                InstanceName =
                {
#if BUILD_PROD
                    Value = "Боевая установка",
#elif BUILD_TEST
                    Value = "Тестовая установка",
#else
                    Value = "Локальная тестовая установка",
#endif
                },

                PartitionsSponsorSettings =
                {
                    Value = Implements.SystemSettings.PartitionsSponsorSettings.GetDefault(),
                },

                MappersFeaturesValidateUpdateResults =
                {
                    Value = true,
                },

                DomainObjectRegistersSettings =
                {
                    Value = Implements.SystemSettings.DomainObjectRegistersSettings.GetDefault(),
                },

                UpdateKeyExpirationTimeout =
                {
                    Value = TimeSpan.FromMinutes(5),
                },
            };

        return result;
    }
}