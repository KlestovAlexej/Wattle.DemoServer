Полнофункциональный демонстрационный сервер на базе библиотеки [Wattle](https://github.com/KlestovAlexej/Wattle.Examples).

---

<details><summary>Примечания.</summary><br/>

- Сервер написан 100% на [C#](https://ru.wikipedia.org/wiki/C_Sharp) под [.NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0).
- Все [автоматические тесты сервера](tests) оформлены как [NUnit](https://nunit.org/)-тесты для запуска в ОС Windows из-под [Visual Studio 2022](https://visualstudio.microsoft.com/ru/vs/) (версии не ниже 17.8.1).
- Все БД [PostgreSQL](https://www.postgresql.org/) (версии не ниже 15) [создаются](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/8044b55f05c8702e2f7d91f2a4143a5406eda034/src/DemoServer.Testing/BaseDbTests.cs#L57) и [уничтожаются](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/8044b55f05c8702e2f7d91f2a4143a5406eda034/src/DemoServer.Testing/BaseDbTests.cs#L72) автоматически при запуске тестов.
	- **Для запуска тестов** в классе [Acme.DemoServer.Testing.BaseDbTests](src/DemoServer.Testing/BaseDbTests.cs) надо определить параметры подключения к PostgreSQL.
- [SQL-скрипт](src/DemoServer.Processing.DataAccess.Postgresql/DemoServer.Processing.sql) БД PostgreSQL создан из [модели](src/DemoServer.Processing.DataAccess.Postgresql/DemoServer.Processing.dmm) спроектированной с использованием [Luna Modeler](https://www.datensen.com/data-modeling/luna-modeler-for-relational-databases.html).
<br/>
Модель БД PostgreSQL :<br/>

![Модель БД PostgreSQL](src/DemoServer.Processing.DataAccess.Postgresql/DemoServer.Processing.Db.png)

</details>

# Содержание
- [Общее](#общее)
- [Доменный объект **DemoDelayTask**](#доменный-объект-demodelaytask---хранимая-в-бд-задача-для-фонового-исполнения) - хранимая в БД задача [для фонового исполнения](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/0f113c3b2a6fddca3894b25ece0f4281a28dc849/src/DemoServer.Processing.Model/DomainObjects/DemoDelayTask/DomainObjectDemoDelayTask.cs#L210).
- [Доменный объект **DemoObject**](#доменный-объект-demoobject) - доступен по [REST интерфейсу](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/55d5eee9d820668b8a98b54f2616801c9fe67691/src/DemoServer.Processing.Api.Clients/ProcessingClient.cs#L76).
- [Доменный объект **DemoObjectX**](#доменный-объект-demoobjectx) - имеет составной [альтернативный ключ](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/55d5eee9d820668b8a98b54f2616801c9fe67691/src/DemoServer.Processing.Model/Interfaces/IDomainObjectRegisterDemoObjectX.cs#L16).

## В демонстрации сервера показаны.

### Общее

- [Реализован](src/DemoServer.Processing.Model/Implements/UnitOfWork.cs) паттерн [Unit of Work](https://martinfowler.com/eaaCatalog/unitOfWork.html)
- [Пример 3-х видов](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/deac469a39d933a82a04b099b904ac5b4999d0c1/src/DemoServer.Processing.Application/Startups/HealthChecks/HealthCheckExtensions.cs#L58) проверки работоспособности сервера на основе шатного механизма [Health checks in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-8.0)
	- Пример как делать проверки [без нагрузки на сервер](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/e2df8ebe3fb198f9fde28b1205f462d224ec5278/src/DemoServer.Processing.Application/Startups/HealthChecks/EntryPointGlobalReadyBackgroundService.cs#L29) при частых проверках.
	- Пример как добавить в [Swagger (OpenAPI)](https://learn.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-8.0) [описание интерфейса](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/df3d33b75edb44eee0995f42a8eddb2f9c9b24a8/src/DemoServer.Processing.Application/Startups/HealthChecks/DocumentFilterHealthCheck.cs#L13) проверки работоспособности.
- [Пример автоматического](tests/DemoServer.Processing.Tests.DataAccess.Postgresql/TestsCreateEntityFrameworkDbContext.cs) создания [контекста](src/DemoServer.Processing.DataAccess.Postgresql/EfModels) и [оптимизированной модели](src/DemoServer.Processing.DataAccess.Postgresql/EfModelsOptimized) контекста [Entity Framework](https://learn.microsoft.com/ru-ru/ef/core/get-started/overview/first-app?tabs=netcore-cli) по существующей БД PostgreSQL с полным переписыванием предыдущих моделей (полезно если сущности БД удалены или переименованы) с учётом специфики [партиционированных таблиц](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/tests/DemoServer.Processing.Tests.DataAccess.Postgresql/TestsCreateEntityFrameworkDbContext.cs#L68).
- [Пример логирования](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/src/DemoServer.Processing.Application/appsettings.json#L12) с использованием [serilog](https://serilog.net/)
	- К примеру, для просмотра логов в онлайне укажите [токен](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/src/DemoServer.Processing.Application/appsettings.json#L36) сайта [logz.io](https://logz.io/) с бесплатным доступом.
- [Интеграция](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/src/DemoServer.Processing.Model/DomainObjects/DemoObjectX/DomainObjectRegisterDemoObjectX.cs#L87) с [OpenTelemetry](https://opentelemetry.io/)
	- К примеру, для просмотра телементрии в онлайне укажите [токен](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/src/DemoServer.Processing.Application/Program.cs#L86) сайта [lightstep.com](https://app.lightstep.com/signin?redirect=%2F) с бесплатным доступом.
- Реализация [REST](https://learn.microsoft.com/ru-ru/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio) интерфейса
	- [Тесты](tests/DemoServer.Processing.Tests.Model/TestsDemoObjectControllerService.cs) службы [контроллера](src/DemoServer.Processing.Api/DemoObjectController.cs) REST интерфейса
	- [Swagger](https://learn.microsoft.com/ru-ru/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-7.0&tabs=visual-studio) описание REST интерфейса
	- Созданы [валидаторы DTO](src/DemoServer.Processing.Api/Validators/WebApplicationBuilderExtensions.cs) получаемых по REST интерфейсу
	- Реализация [высокоуровневого клиент](src/DemoServer.Processing.Api.Clients/ProcessingClient.cs) REST интерфейса на базе [RestSharp](https://restsharp.dev/)
	- [Интеграционные тесты](tests/DemoServer.Processing.Tests.Application/TestsApiServer.cs) REST интерфейса
- Интеграция с Entity Framework в рамках Unit of Work [c тестами](tests/DemoServer.Processing.Tests.Model/TestsUnitOfWork.cs)
- Пример [логирующего прокси](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/src/DemoServer.Processing.Model/Implements/EntryPointExtensions.cs#L44) с поддержкой вызова [асинхронных методов](https://learn.microsoft.com/ru-ru/dotnet/csharp/asynchronous-programming/)
- Пример интеграции с [Telegram](https://telegram.org/) для [оперативного уведомления](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/68f17448d93b4e75607d2783e30c2a024afc2d93/src/DemoServer.Processing.Model/Implements/ExceptionPolicy.cs#L462) об ошибках сервера и отправки [диагностических сообщений](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/68f17448d93b4e75607d2783e30c2a024afc2d93/tests/DemoServer.Processing.Tests.Model/TestsTelegram.cs#L38)

---
### Доменный объект DemoDelayTask - хранимая в БД задача для фонового исполнения

- [На пример](tests/DemoServer.Processing.Tests.Model/TestsDemoDelayTask.cs) доменного объекта [DemoDelayTask](src/DemoServer.Processing.Model/DomainObjects/DemoDelayTask/DomainObjectDemoDelayTask.cs) показана реализаци хранимой в БД задачи для фонового исполнения
	- Показан пример полиморфного [сценария выполнения задачи](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/3229448fcb474d627585c7260578a5524e573620/src/DemoServer.Processing.Model/DomainObjects/DemoDelayTask/DomainObjectDemoDelayTask.cs#L121)
	- Показан пример остановки обработки всех задач из-за к примеру [отравленных задач](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/9eca9e35c92d15e498ca48722944870007b89adf/src/DemoServer.Processing.Model/DomainObjects/DemoDelayTask/DomainObjectDemoDelayTask.cs#L247).
<br/>Это может быть полезно если задачи общаются с внешней системой которая перестала отвечать. 
<br/>Для предотвращения лавины ошибок и пустого расходования ресурсов обработку всех задач [можно приостановить](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/9eca9e35c92d15e498ca48722944870007b89adf/tests/DemoServer.Processing.Tests.Model/TestsDemoDelayTask.cs#L81) до выздоровления внешней системы.
Пример [возобновления обработки всех задач](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/9eca9e35c92d15e498ca48722944870007b89adf/tests/DemoServer.Processing.Tests.Model/TestsDemoDelayTask.cs#L67) показан в примере. 
	- [Показан пример](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/f638e4cf029af88ec7caa4e11706281c7cf7f642/tests/DemoServer.Processing.Tests.Model/TestsDemoDelayTask.cs#L31) циклического [сценария выполнения задачи](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/f638e4cf029af88ec7caa4e11706281c7cf7f642/src/DemoServer.Processing.Model/DomainObjects/DemoDelayTask/DomainObjectDemoDelayTask.cs#L186).
	- Показана умная [десериализация из текста JSON](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/b9208a4597303c544e4794a70ad9655ec540336e/src/DemoServer.Processing.Model/DomainObjects/DemoDelayTask/DomainObjectDemoDelayTask.cs#L127) и [умная сериализация в текст JSON](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/b9208a4597303c544e4794a70ad9655ec540336e/src/DemoServer.Processing.Model/DomainObjects/DemoDelayTask/DemoDelayTaskProcessor.cs#L31) - данный подход позволяет при десереализации текста JSON в объекты повторно и безопасно использовать раннее десериализованные объекты.
	- Все задачи хранятся в БД в [партиционированной таблице](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/cd9ed1261bd7944083f78fd90c148d0c40727db0/src/DemoServer.Processing.Common/WellknownDomainObjectFields.cs#L297)
	- У задачи есть возможностью [немедленного запуска (фоново)](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/fc850b33387d768d2354c595d2663f217ca70bbb/tests/DemoServer.Processing.Tests.Model/TestsDemoDelayTask.cs#L36) или [отложенного запуска на указанную дату-время](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/11e9a1fa5f5b57d3126f1e09d93128fd6a0dbfc7/tests/DemoServer.Processing.Tests.Model/TestsDemoDelayTask.cs#L71) 
		- Задача сохраняется в БД и исполняется только при успешном подтверждении Unit of Work
		- Задача начинает исполнение только после успешного подтверждения Unit of Work в котром она была создана
		- При отмене Unit of Work задача в БД не сохраняется и не исполняется
	- Все [неисполненные задачи](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/697700aca8309cfa4c651006909a9ca8dc0cd005/src/DemoServer.Processing.Model/DomainObjects/DemoDelayTask/DomainObjectDemoDelayTask.cs#L129) при рестарте в фоновом режиме [автоматически загружаются из БД](src/DemoServer.Processing.Model/DomainObjects/DemoDelayTask/DemoDelayTaskProcessor.cs) и ставятся на исполнение
	- Задачи [исполняются асинхронно](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/f70f479ef1868150d1bade9c7f7b416d9a6a568a/src/DemoServer.Processing.Model/DomainObjects/DemoDelayTask/DomainObjectDemoDelayTask.cs#L117)
	- Задачи можно исполнять повторно и [менять дату-время](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/471e57401f1f97e99cc93da532d2f2a4e87977b8/src/DemoServer.Processing.Model/DomainObjects/DemoDelayTask/DomainObjectDemoDelayTask.cs#L212) отложенного (или немедленного) повторного запуска (в другом Unit of Work)
	- Исполнение задачи можно [немедленно отменить](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/1e4696be573d287da08f5f110c07d430ebd73b5b/tests/DemoServer.Processing.Tests.Model/TestsDemoDelayTask.cs#L139)
	- При [аварийном исключении](https://learn.microsoft.com/ru-ru/dotnet/csharp/fundamentals/exceptions/) задача автоматически отправляется на повторную обработку с предварительных отстоем указанный интервал времени
	- Для любой задачи можно [получить обекта](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/11e9a1fa5f5b57d3126f1e09d93128fd6a0dbfc7/tests/DemoServer.Processing.Tests.Model/TestsDemoDelayTask.cs#L79) для асинхронного [ожидания завершения](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/11e9a1fa5f5b57d3126f1e09d93128fd6a0dbfc7/tests/DemoServer.Processing.Tests.Model/TestsDemoDelayTask.cs#L81C7-L82C1) (указанное время или бесконечно) исполнения
		- Есть [настройка](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/f70f479ef1868150d1bade9c7f7b416d9a6a568a/src/DemoServer.Processing.Model/Implements/SystemSettings/SystemSettings.cs#L309) для интервала ожидания по умолчанию если программист явно не указал интервал ожидания
	- Есть произвольные [настройки](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/f70f479ef1868150d1bade9c7f7b416d9a6a568a/src/DemoServer.Processing.Model/Implements/SystemSettings/SystemSettings.cs#L309) для [обработчика задач](src/DemoServer.Processing.Model/DomainObjects/DemoDelayTask/DemoDelayTaskProcessor.cs)
	- При создании задач есть [контроль лимита активных задач](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/b9d831390c432ec7727073f5e1985c45e914a163/tests/DemoServer.Processing.Tests.Model/TestsDemoDelayTask.cs#L147)
		- [Можно игнорировать](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/54f6742858ff56eb8ccbaa43683885621db9b748/tests/DemoServer.Processing.Tests.Model/TestsDemoDelayTask.cs#L301) контроль лимита активных задач
	- Каждая задача исполняется в своём автоматически созданном Unit of Work
		- Стратегию создания Unit of Work можно переопределить

---
### Доменный объект DemoObject

- Создан доменный объект [DemoObject](src/DemoServer.Processing.Model/DomainObjects/DemoObject/DomainObjectDemoObject.cs) доступный по REST интерфейсу
	- [Реализован](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/src/DemoServer.Processing.DataAccess.Postgresql/Mappers.cs#L34) кэширующий [маппер](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/src/DemoServer.Processing.Common/WellknownDomainObjectFields.cs#L180) БД
	- Данные в БД хранится [в партиционированных таблицах](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/src/DemoServer.Processing.Common/WellknownDomainObjectFields.cs#L181)
	- Партиции БД [создаются автоматически](src/DemoServer.Processing.Model/Implements/PartitionsSponsor.cs) для каждого календарного дня
	- Реализована [оптимистическая конкуренция при обновлении](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/src/DemoServer.Processing.Common/WellknownDomainObjectFields.cs#L183) на уровне БД
	- [Пример полей](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/src/DemoServer.Processing.Model/DomainObjects/DemoObject/DomainObjectDemoObject.cs#L87) доменного объекта с типом хранения в БД PostgreSQL [timestamp](https://www.postgresql.org/docs/current/datatype-datetime.html)
	- Реализована [критическая секция](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/src/DemoServer.Processing.Model/Implements/EntryPointFacade.cs#L49) при [обновлении DemoObject](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/src/DemoServer.Processing.Model/DomainObjects/DemoObject/DomainObjectDemoObject.cs#L125)
		- При создании объекта показана [стратегия определения успешности коммита](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/src/DemoServer.Processing.Model/DomainObjects/DemoObject/DomainObjectDemoObject.cs#L185) Unit of Work

---
### Доменный объект DemoObjectX

- Создан доменный объект [DemoObjectX](src/DemoServer.Processing.Model/DomainObjects/DemoObject/DomainObjectDemoObject.cs)
	- Реализован кэширующий маппер БД
	- Пример произвольной выборки доменных объектов с использованием [Entity Framework](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/tests/DemoServer.Processing.Tests.Model/TestsDomainObjectX.cs#L74)
	- Пример использования столбца таблицы БД с [именем в кавычках](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/src/DemoServer.Processing.Common/WellknownDomainObjectFields.cs#L282)
	- [Пример полей](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/src/DemoServer.Processing.Model/DomainObjects/DemoObjectX/DomainObjectDemoObjectX.cs#L109) доменного объекта с типом хранения в БД PostgreSQL [timestamptz](https://www.postgresql.org/docs/current/datatype-datetime.html)
	- Реализована [оптимистическая конкуренция при обновлении](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/src/DemoServer.Processing.Common/WellknownDomainObjectFields.cs#L223) на уровне БД
	- Реализована критическая секция при [обновлении](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/src/DemoServer.Processing.Model/DomainObjects/DemoObjectX/DomainObjectIntergratorDemoObjectX.cs#L26) и [создании](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/src/DemoServer.Processing.Model/DomainObjects/DemoObjectX/DomainObjectIntergratorDemoObjectX.cs#L41) DemoObjectХ
	- При создании объекта показана стратегия определения успешности коммита Unit of Work 
	- Показана реализация [реестра идентити объектов](src/DemoServer.Processing.Model/DomainObjects/DemoObjectX/DemoObjectXIdentitiesService.cs) - механизма полного кэшированияв в памяти (с фоновым прогревом) идентификаторов и альтернативных ключей доменных объектов для минимизации и даже полного исключения обращений к БД
	- Показано [удаление объектов](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/src/DemoServer.Processing.Model/DomainObjects/DemoObjectX/DomainObjectDemoObjectX.cs#L201)
	- Реализован [составной альтернативный ключ](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/src/DemoServer.Processing.Common/WellknownDomainObjectFields.cs#L224C39-L224C39) на уровне БД и на уровне кода
		- Реализовано создание объекта с [проверкой уникальности альтернативного ключа](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/src/DemoServer.Processing.Model/DomainObjects/DemoObjectX/DomainObjectIntergratorDemoObjectX.cs#L54) на уровне кода (с минимальным и даже без обращения к БД)
		- Создан интерфейс [поиска по альтернативному ключу](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/src/DemoServer.Processing.Model/Interfaces/IDomainObjectRegisterDemoObjectX.cs#L16) (с минимальным и даже без обращения к БД)
	- Реализовано понятие [группы объектов объединенных константным признаком](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/src/DemoServer.Processing.Common/WellknownDomainObjectFields.cs#L225)
		- Создан интерфейс [поиска коллекции объектов по значению группы](https://github.com/KlestovAlexej/Wattle.DemoServer/blob/be5865d7e9567f8f85819e19ddec843e2ad45567/src/DemoServer.Processing.Model/Interfaces/IDomainObjectRegisterDemoObjectX.cs#L13) (с минимальным и даже без обращениея к БД)
