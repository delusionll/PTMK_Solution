# ***Readme***
### C# + Entity Framework Core (Code first)
### Прежде всего, приложение написано "в процедурном стиле" и топорно, однако это может позволить отследить ход мыслей :).
### Поставщик базы данных выбран InMemory, чтобы не создавать подключение к SQL Server
### Приложение выполняет все функции из поставленной задачи (для выполнения следует вводить в консоль 1, 2 и т.д. в соответствии с описанием)
### Касательно п.6:
      Чтобы уменьшить время исполнения, я выполнил:
      1. Lazy loading - не уменьшает, нет связанных таблиц
      2. AsNoTracking (Только для чтения) - незначительно увеличивается скорость
      3. Добавил индексы в БД по столбцам Gender и FIO
      4. Самый эффективный способ - кэширование.
      Время выполнения задач выводится в консоли


## Задание:
Написать консольное приложение или php скрипт, который будет запускаться из консоли.
По каждому пункту оно должно принимать параметр командной строки и выполнять соответствующий пункт.
По ходу задания будут примеры. Для ФИО использовать английский язык. Решать проблему с отображением русского языка в консоли, если возникает, не нужно.
Приложение/скрипт должно подключаться к базе данных.

В качестве СУБД можно использовать любую SQL СУБД или MongoDB.
В качестве среды разработки можете использовать любой известный вам язык программирования.

В приложении должно быть:
1. Создание таблицы с полями представляющими ФИО, дату рождения, пол.

Пример запуска приложения:
myApp 1
Для php:
php myApp.php 1
Для java:
java myApp.class 1
или
java myApp.jar 1

2. Создание записи. Использовать следующий формат:
myApp 2 ФИО ДатаРождения Пол

3. Вывод всех строк с уникальным значением ФИО+дата, отсортированным по ФИО , вывести ФИО, Дату рождения, пол, кол-во полных лет.
Пример запуска приложения:
myApp 3

4. Заполнение автоматически 1000000 строк. Распределение пола в них должно быть относительно равномерным, начальной буквы ФИО также. Заполнение автоматически 100 строк в которых пол мужской и ФИО начинается с "F".
Пример запуска приложения:
myApp 4

5. Результат выборки из таблицы по критерию: пол мужской, ФИО начинается с "F". Сделать замер времени выполнения.
Пример запуска приложения:
myApp 5
Вывод приложения должен содержать время.

6. Произвести определенные манипуляции над базой данных для ускорения запроса из пункта 5. Убедиться, что время исполнения уменьшилось. Объяснить смысл произведенных действий. Предоставить результаты замера до и после.

Просьба для любых текстовых файлов использовать кодировку utf8.
