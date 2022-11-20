# InfinBank.Backend
Тестовые пользователи для выполнение "endpoint"ов

Admin 
	Login: admin@gmail.com
	Password: Qwertyruru20@@
User 
	Login: user@gmail.com
	Password: Qwertyruru20@@

Вычисления площади и периметра фигур
Вводные данные
1. Квадрат
	Для вычисления площади квадрата S = a × a
	Для вычисления периметра квадрата P = 4a
2. Прямоугольник
	Для вычисления площади прямоугольника S = a × b
	Для вычисления периметра прямоугольника P = a + b + c + d,
3. Треугольник
	Для вычисления площади треугольника S=sqrt(p*(p-a)*(p-b)*(p-c))
	Для вычисления периметра треугольника P = a + b + c,
4. Круг
	Для вычисления площади круга S=π×r2
	Для вычисления окружности круга l=2πr
Версия платформы .Net6
Для реализации задачи было использованио несколько паттернов такие как:
	CLEANARCHITECTURE - ОБЩИЙ ШАБЛОН ДЛЯ РАЗРАБОТКИ СЛОЖНЫХ АРХИТЕКТУР 
	 - Доменный слой — наши сущности и классы.
	 - Слой бизнес-логики, где происходит вся обработка доменной логики.
	 - Слой приложения — логика самого приложения.
	 - Внешние слои: слой UI, базы данных или тестов.
	 (Вся связь между слоями реализовано с помощью методов DependencyInjection).... Каждый нижный слой не имеет доступ с верхнему слою и таким образом изолируя себя предотвращется написание ....вно кода 
	CQRS - Command Query Responsibility Segregation ДЛЯ ФОРМИРОВНАИЕ ЗАПИСИ И ЧТЕНИЕ ИЗ БАЗЫ ДАННЫХ
	   Разделяет операции на две категории:
		- команды— изменяют состояние системы;
		- запросы— не изменяют состояние, только получают данные. 
Для взаимодействие с базой данных был выбран ORM EntityFramework (почему не Dapper? Потому что на сегоднящний день EntityFramework имеет все возможности управлять зпросами в базу данных)
Для самой баз данных используется SQLite в файловым варианте
	Преимушества: очень быстро работает, очень подходит для разработки и когда один разработчик тоесть в базу идет монотонные запросы из одного "endpoint"а
	Недостатки: Не поддерживает Multiwriting так как самом деле пишет в файл
Проект состоит из несколько слоев которое описыватеся с помощью архитектуры CLEANARCHITECTURE:
1. InfinBank.Domain - Слой для формирование базы данных
	* Common - Хранить в себе общие свойства для предотвращения повторности кода ID, DateCreated, DateUpdated, CreatedBy, ModifiedBy
	* Entities - свойства фигур заданной в рамках ТЗ (каждый класс унаследуется от класса BaseAuditableEntity.cs для избежание повторности)
	* IdentityUserEntities - свойства для аутентификации и авторизации пользователей (Ниже польный приведу полный Guid)
2. InfinBank.Application - Слой бизнес-логики. Содержит в себе основную часть бизнес логики 

Common - Общие классы для формирование Мапинга, Модели, и тд
			Behaviors - содержит логику логирование. В рамках этой задачи было реализовано собствен(custom)ный метод логирование а также использовано метод который предостовляет сама система ASP
			Exceptions - Обработка ошибок. Реализовано именно для работы с базой данный. Срабатывает когда в базу не совершено какието записи или чтения по разным причинам
			Mappings - В качестве Мапинга был выбран библиотека AutoMapper 12.0.0 из пакетов nuget https://www.nuget.org/packages/automapper/ 
			Models - Храниться собственный метод для пагинации(для вытаскивание записи по разделением на страницы очень удобно когда записи в базе слишком много) но не успел реализовать в этот проект (времени не хватило)
			
		Для валидации вводимых данных использована библиотека - FluentValidation 11.3.0 https://www.nuget.org/packages/fluentvalidation/
CQRS
	Commands - Команды для изменение состояние базы
			Queries - Команды для реализации запросов (полное описание смотрите выше 22 строка)
			В целом для записи всех вычислений, для чтение ранее совершенные записи реализовано в этих двух дерикториях
3. InfinBank.Persistence - Данный слой отвечает исключительно для настройки баз данных
	EntityTypeConfigurations - Содержить все настраиваимые классы для баз данных 
	Interceptors - Реализаци общих свойств (ранее было для этого реализовано специальная дериктория Common в слое InfinBank.Domain)
	Services - Содержит всю вычеслительную логику
		* CalculateServices - Реализация всех формул для вычисления площадей, периметров и длин окружности фигур
		* DateTimeService - Вычисляет системное время для запольнение DateCreated, DateUpdated
4. InfinBank.WebAPI - Cлой UI. Реализация внешнего слоя проекта. API "enpoint", "swagger" реализован в этом слое
	Controllers - Контроллеры ("enpoint"ы) 
	Logs - Лог файлы (Лог пишет и системный модуль и модул который реализован ручками)
	Middleware - Для перенаправление пользователей изходя из их прав
	Services - Получение авторизованного пользователя для заполнение CreatedBy, ModifiedBy
Немного о Аутентификации и авторизации
	В проекте реализовано Аутентификация и авторизация. Реализовано она с помощью дефолтный функций самой ASP используется контекст IdentityDbContext. Но для аутентицикации JWT Token c UserRole ами.
	Тоесть в описании "Swagger"е указано каким пользователям дозволено пользоватся той или иной "endpoint"ов

Недостатки (архитектурные ошибки) при построение данной системы (Это я потом понял но менят было уже поздно)
 - Слишком много вспогательных классов их можно было удалить перед тем как за деплоит на хост
 - Не слишком оптимально построене связи в таблицах
 	Например Прямоуголнику нужно вычеслить периметр, после выпольбнение данной функции методя возраашет периметр и при этом сохраняет записи
 	После... Если выпольнить чтение всех ранее вычеслненых площадей прямоугольника (при том что база еще пустая) она выташить ту запис которую хранить в себе периметр 
 		Решение... можно было реализовать OneToMany RealtionShip между вводимыми данными для вычислений и результатов


