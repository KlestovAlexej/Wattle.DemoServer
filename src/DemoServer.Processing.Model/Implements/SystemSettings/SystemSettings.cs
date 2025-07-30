using Acme.DemoServer.Processing.Common;
using Acme.DemoServer.Processing.DataAccess.Interface;
using Acme.Wattle.DomainObjects.AsyncTasks;
using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.DomainObjects.Serializers.Binary;
using Acme.Wattle.DomainObjects.Serializers.Json;
using Acme.Wattle.DomainObjects.UnitOfWorkLocks;
using Acme.Wattle.Json;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Acme.DemoServer.Processing.Model.Implements.SystemSettings;

[SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Global")]
[SuppressMessage("ReSharper", "PreferConcreteValueOverDefault")]
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

        UnitOfWorkLocks =
            new SettingValue<UnitOfWorkLocksSettings>(
                default!,
                "Настройки пулов лок-объектов уровня IUnitOfWork");

        ExceptionPolicy =
            new SettingValue<ExceptionPolicySettings>(
                default!,
                "Настройки уведомления об исключениях системы");

        IdentityCaches =
            new SettingValue<IdentityCachesSettings>(
                default!,
                "Настройки кэширующих провайдеров идентити объектов");

        MappersCacheActualStateDto =
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

        PartitionsSponsor =
            new SettingValue<PartitionsSponsorSettings>(
                default!,
                "Настройки создателя партиций БД");

        DomainObjectRegisters =
            new SettingValue<DomainObjectRegistersSettings>(
                default!,
                "Настройки реестров доменных объектов");

        UpdateKeyExpirationTimeout =
            new SettingValue<TimeSpan>(
                default,
                "Интервал действия ключа контроля изменений");

        DemoDelayTaskProcessor =
            new SettingValue<AsyncTaskServiceSettings>(
                default!,
                "Настройки службы обработки задач с отложенным запуском");

        SmartJsonDeserializer =
            new SettingValue<SmartJsonDeserializerSettings>(
                default!,
                "Настройки умного десериализации JSON");

        SmartBinaryDeserializer =
            new SettingValue<SmartBinaryDeserializerSettings>(
                default!,
                "Настройки умного десериализации массива байт");

        Telegram =
            new SettingValue<TelegramSettings>(
                default!,
                "Настройки Telegram");

        UseLoggingProxy =
            new SettingValue<bool>(
                default,
                "Использовать прокси логирующий все вызовы методов с логированием параметров и результатов вызовов методов");

        TelegramShowApplicationStartStop =
            new SettingValue<bool>(
                default,
                "Отправлять в Telegram уведомления о запуске/остановке приложения");
    }

    /// <summary>
    /// Использовать прокси логирующий все вызовы методов с логированием параметров и результатов вызовов методов.
    /// </summary>
    [Description("Использовать прокси логирующий все вызовы методов с логированием параметров и результатов вызовов методов")]
    public SettingValue<bool> UseLoggingProxy { get; set; }

    /// <summary>
    /// Настройки Telegram.
    /// </summary>
    [Description("Настройки Telegram")]
    public SettingValue<TelegramSettings> Telegram { get; set; }

    /// <summary>
    /// Настройки умного десериализации JSON.
    /// </summary>
    [Description("Настройки умного десериализации JSON")]
    [JsonRequired]
    public SettingValue<SmartJsonDeserializerSettings> SmartJsonDeserializer { get; set; }

    /// <summary>
    /// Настройки умного десериализации массива байт.
    /// </summary>
    [Description("Настройки умного десериализации массива байт")]
    [JsonRequired]
    public SettingValue<SmartBinaryDeserializerSettings> SmartBinaryDeserializer { get; set; }

    /// <summary>
    /// Настройки службы обработки задач с отложенным запуском.
    /// </summary>
    [Description("Настройки службы обработки задач с отложенным запуском")]
    public SettingValue<AsyncTaskServiceSettings> DemoDelayTaskProcessor { get; set; }
    
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
    public SettingValue<DomainObjectRegistersSettings> DomainObjectRegisters { get; set; }

    /// <summary>
    /// Настройки создателя партиций БД.
    /// </summary>
    [Description("Настройки создателя партиций БД")]
    public SettingValue<PartitionsSponsorSettings> PartitionsSponsor { get; set; }

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
    public SettingValue<UnitOfWorkLocksSettings> UnitOfWorkLocks { get; set; }

    /// <summary>
    /// Настройки уведомления об исключениях системы.
    /// </summary>
    [JsonRequired]
    public SettingValue<ExceptionPolicySettings> ExceptionPolicy { get; set; }

    /// <summary>
    /// Настройки кэшей актуальных данных состояний доменнй объектов в БД.
    /// </summary>
    [JsonRequired]
    public SettingValue<MappersCacheActualStateDtoSettings> MappersCacheActualStateDto { get; set; }

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
    public SettingValue<IdentityCachesSettings> IdentityCaches { get; set; }

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

    /// <summary>
    /// Отправлять в Telegram уведомления о запуске/остановке приложения.
    /// </summary>
    [JsonRequired]
    public SettingValue<bool> TelegramShowApplicationStartStop { get; set; }

    public static SystemSettings GetDefault()
    {
        var result =
            new SystemSettings
            {
                UnitOfWorkLocks =
                {
                    Value = UnitOfWorkLocksSettings.GetDefault()
                },

                ExceptionPolicy =
                {
                    Value = ExceptionPolicySettings.GetDefault()
                },

                IdentityCaches =
                {
                    Value = IdentityCachesSettings.GetDefault()
                },

                MappersCacheActualStateDto =
                {
                    Value = MappersCacheActualStateDtoSettings.GetDefault()
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

                PartitionsSponsor =
                {
                    Value = PartitionsSponsorSettings.GetDefault(EntryPoint.GetMappers(), typeof(WellknownDomainObjectFields)),
                },

                MappersFeaturesValidateUpdateResults =
                {
                    Value = true,
                },

                DomainObjectRegisters =
                {
                    Value = DomainObjectRegistersSettings.GetDefault(),
                },

                UpdateKeyExpirationTimeout =
                {
                    Value = TimeSpan.FromMinutes(5),
                },

                DemoDelayTaskProcessor =
                {
                    Value = AsyncTaskServiceSettings.GetDefault(),
                },

                SmartJsonDeserializer =
                {
                    Value = SmartJsonDeserializerSettings.GetDefault(),
                },

                SmartBinaryDeserializer =
                {
                    Value = SmartBinaryDeserializerSettings.GetDefault(),
                },

                Telegram =
                {
                    Value = TelegramSettings.GetDefault(),
                },

                UseLoggingProxy =
                {
                    Value = true,
                },

                TelegramShowApplicationStartStop =
                {
                    Value = true,
                },
            };

        // Для нужд тестов. По умолчанию значение 1_000_000.
        result.DemoDelayTaskProcessor.Value.MaxActive.Value = 3;

        return result;
    }
}
