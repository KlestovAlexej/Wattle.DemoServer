Демонстрационный сервер на базе библиотеки [Wattle3](https://github.com/KlestovAlexej/Wattle3.Examples).

В примере показаны :

- Реализован паттерн [Unit of Work](https://martinfowler.com/eaaCatalog/unitOfWork.html)
- Интеграция с [OpenTelemetry](https://opentelemetry.io/)
- Реализация REST интерфейса
	- Тесты службы контроллера REST интерфейса
	- Swagger описание REST интерфейса
	- Созданы валидаторы DTO получаемых по REST интерфейсу
	- Реализация высокоуровневого клиент REST интерфейса на базе RestSharp
	- Интеграционные тесты REST интерфейса
- Интеграция с [Entity Framework](https://learn.microsoft.com/ru-ru/ef/) в рамках Unit of Work c тестами

- Создан доменный объект [DemoObject](src/DemoServer.Processing.Model/DomainObjects/DemoObject/DomainObjectDemoObject.cs) доступный по REST интерфейсу
	- Реализован кэширующий маппер БД
	- Данные в БД хранится в партиционированных таблицах
	- Партиции БД создаются автоматически для каждого календарного дня
	- Реализована оптимистическая конкуренция при обновлении на уровне БД
	- Реализована критическая секция при обновлении DemoObject
	- При создании объекта показана стратегия определения успешности коммита Unit of Work 

- Создан доменный объект [DemoObjectX](src/DemoServer.Processing.Model/DomainObjects/DemoObject/DomainObjectDemoObjectX.cs)
	- Реализован кэширующий маппер БД
	- Пример использования столбца таблицы БД с именем в кавычках
	- Реализована оптимистическая конкуренция при обновлении на уровне БД
	- Реализована критическая секция при обновлении и создании DemoObject
	- При создании объекта показана стратегия определения успешности коммита Unit of Work 
	- Показана реализация реестра идентити объектов
	- Показано удаление объектов
	- Реализован составной альтернативный ключ на уровне БД и на уровне кода
		- Реализовано создание объекта с проверкой уникальности альтернативного ключа на уровне кода (с минимальным и даже без обращения к БД)
		- Создан интерфейс поиска по альтернативному ключу (с минимальным и даже без обращения к БД)
	- Реализовано понятие группы объектов объединенных константным признаком
		- Создан интерфейс поиска коллекции объектов по значению группы (с минимальным и даже без обращениея к БД)

- Примечание №1 :
Проект [DemoServer.Processing.Application.csproj](src/DemoServer.Processing.Application/DemoServer.Processing.Application.csproj) при сборке использует [PowerShell](https://learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell?view=powershell-7.3).
Из командной строки должен быть доступен запуск [PWSH.exe](https://learn.microsoft.com/ru-ru/powershell/module/microsoft.powershell.core/about/about_pwsh?view=powershell-7.3)

- Примечание №2 :
Для запуска тестов в классе (ShtrihM.DemoServer.Testing.BaseDbTests)[src/DemoServer.Testing/BaseDbTests.cs] надо определить параметры подключения к PostgreSQL.
