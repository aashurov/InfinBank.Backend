# InfinBank.Backend
Тестовые пользователи и адрес сервера для выполнение "endpoint"ов

- Url: http://ashurov.ml
- Admin 
	* Login: admin@gmail.com
	* Password: Qwertyruru20@@
- User 
	* Login: user@gmail.com
	* Password: Qwertyruru20@@

Вычисления площади и периметра фигур
Вводные данные
1. Квадрат
	* Вычисления площади квадрата S = a × a
	* Вычисления периметра квадрата P = 4a
2. Прямоугольник
	* Вычисления площади прямоугольника S = a × b
	* Вычисления периметра прямоугольника P = a + b + c + d,
3. Треугольник
	* Вычисления площади треугольника S=sqrt(p*(p-a)*(p-b)*(p-c))
	* Вычисления периметра треугольника P = a + b + c,
4. Круг
	* Вычисления площади круга S=π×r2
	* Вычисления окружности круга l=2πr

Версия платформы .Net6

Для реализации задачи было использованио несколько паттернов такие как:

- CLEANARCHITECTURE - ОБЩИЙ ШАБЛОН ДЛЯ РАЗРАБОТКИ СЛОЖНЫХ АРХИТЕКТУР 
	* Доменный слой — наши сущности и классы.
	* Слой бизнес-логики, где происходит вся обработка доменной логики.
	* Слой приложения — логика самого приложения.
	* Внешние слои: слой UI, базы данных или тестов.

(Вся связь между слоями реализовано с помощью методов DependencyInjection).... Каждый нижный слой не имеет доступ с верхнему слою и таким образом изолируя себя предотвращется написание ....вно кода 

- CQRS - Command Query Responsibility Segregation ДЛЯ ФОРМИРОВАНИЕ ЗАПИСИ И ЧТЕНИЕ ИЗ БАЗЫ ДАННЫХ
- Разделяет операции на две категории:
	* команды— изменяют состояние системы;
	* запросы— не изменяют состояние, только получают данные. 
	
CQRS - паттерн используется в месте с библиотекой MediatR 11.1.0 https://www.nuget.org/packages/MediatR для переноса данных с UI слоя в слой бизнес-логики 

Для взаимодействие с базой данных был выбран ORM EntityFramework (почему не Dapper? Потому что на сегоднящний день EntityFramework имеет все возможности управлять зпросами в базу данных)

Для самой баз данных используется SQLite в файловым варианте
- Преимушества: очень быстро работает, очень подходит для разработки и когда один разработчик тоесть в базу идет монотонные запросы из одного "endpoint"а
- Недостатки: Не поддерживает Multiwriting так как самом деле пишет в файл

Проект состоит из несколько слоев которое описыватеся с помощью архитектуры CLEANARCHITECTURE:
1. InfinBank.Domain - Слой для формирование базы данных
	* **Common** - Хранить в себе общие свойства для предотвращения повторности кода ID, DateCreated, DateUpdated, CreatedBy, ModifiedBy
	* **Entities** - свойства фигур заданной в рамках ТЗ (каждый класс унаследуется от класса BaseAuditableEntity.cs для избежание повторности)
	* **IdentityUserEntities** - свойства для аутентификации и авторизации пользователей (Ниже польный приведу полный Guid)
2. InfinBank.Application - Слой бизнес-логики. Содержит в себе основную часть бизнес логики 
	* **Common** - Общие классы для формирование Мапинга, Модели, и тд
	* **Behaviors** - содержит логику логирование. В рамках этой задачи было реализовано собствен(custom)ный метод логирование а также использовано метод который предостовляет сама система ASP
	* **Exceptions** - Обработка ошибок. Реализовано именно для работы с базой данный. Срабатывает когда в базу не совершено какието записи или чтения по разным причинам
	* **Mappings** - В качестве Мапинга был выбран библиотека AutoMapper 12.0.0 из пакетов nuget https://www.nuget.org/packages/automapper/ 
	* **Models** - Храниться собственный метод для пагинации(для вытаскивание записи по разделением на страницы очень удобно когда записи в базе слишком много) но не успел реализовать в этот проект (времени не хватило)
		
Для валидации вводимых данных использована библиотека - FluentValidation 11.3.0 https://www.nuget.org/packages/fluentvalidation/
- **CQRS**
	* **Commands** - Команды для изменение состояние базы
	* **Queries** - Команды для реализации запросов (полное описание смотрите выше 22 строка). В целом для записи всех вычислений, для чтение ранее совершенные записи реализовано в этих двух дерикториях

3. InfinBank.Persistence - Данный слой отвечает исключительно для настройки баз данных
	* **EntityTypeConfigurations** - Содержить все настраиваимые классы для баз данных 
	* **Interceptors** - Реализаци общих свойств (ранее было для этого реализовано специальная дериктория Common в слое InfinBank.Domain)
	* **Services** - Содержит всю вычеслительную логику
		* **CalculateServices** - Реализация всех формул для вычисления площадей, периметров и длин окружности фигур
		* **DateTimeService** - Вычисляет системное время для запольнение DateCreated, DateUpdated
4. InfinBank.WebAPI - Cлой UI. Реализация внешнего слоя проекта. API "enpoint", "swagger" реализован в этом слое
	* **Controllers** - Контроллеры ("enpoint"ы) 
	* **Logs** - Лог файлы (Лог пишет и системный модуль и модул который реализован ручками)
	* **Middleware** - Для перенаправление пользователей изходя из их прав
	* **Services** - Получение авторизованного пользователя для заполнение CreatedBy, ModifiedBy
Немного о Аутентификации и авторизации
- **АУТЕНТИФИКАЦИЯ** и **АВТОРИЗАЦИЯ**. Реализовано с помощью стандартных функций ASP, для формирование таблиц для хранение пользователей используется контекст **IdentityDbContext**. Для аутентификации и авторизации  **JWT Token** c **UserRole**ами. Проверить подлинность "token"ов можно по следующей ссылке https://jwt.io/
	* В описании "Swagger"е указано каким "enpoint"ам требуется та или иная роль. При запуска системы, автоматически создается два пользователя и прикрепляется им роли адмнистратор и пользователь соответственно.

**НЕДОСТАТКИ** (архитектурные ошибки) при построение данной системы (Это я потом понял но менят было уже поздно)
 - Слишком много вспомогательных классов их можно было удалить перед тем как за деплоит на хост
 - Не оптимально построене связи в таблицах
 - Например Прямоуголнику нужно вычислить периметр, после выпольнение вызова данного "enpoint" функции методя возвращает периметр и сохраняет записи в базу.
 	* После... Если выпольнить чтение всех ранее вычеслненых площадей(не периметров) прямоугольника, "enpoint" будет возврашать записи с периметрами поскольку в базе уже хранится записи
 	* Решение... 
		* можно было реализовать OneToMany RealtionShip между вводимыми данными для вычислений и результатов
		* другой вариант поставить проверку при вызова периметра или площадя фигуры

**КАК БЫ Я РАЗВИВАЛ И ОПТИМИЗИРОВАЛ ПРОЕКТ ДАЛЬНЕЙЩЕМ**
- Добавление Управление пользователями, назначение Claims на пользователей
- Реализация Авторизации пользователей с помощью "UserClaims", это даёт более гибкие возможности распределять права доступа в системе (на данный момент система авторизирует пользователей с помщью их ролей, считается что возможности меньще чем другие методы)
- Индексация всех таблиц для дальнейшего быстроты системы. очень полезно когда база нарастает
- Реализация Elasticsearch .NET Client [8.0] для ускорение отработки "enpoint"ов
- Завертываение в Docker для дальнейшего безболезненного деплоя на той или иной хост (.Net приложения хорошо приживаются в средах как Aws, Azure, Oracle)
