# Vesta.Fullstack
## Запуск
1) Небходимо установить Node.js и .NET SDK, если не установлено.
2) Перейти в папку Vesta.Fullstack.Server
3) Открыть файл appsettings.json и заполнить пропуски для подключения к бд "Host=;Port=;Database=;Username=;Password="
4) Далее нужно импортировать миграцию, перейдите в Vesta.Fullstack, откройте терминал и введите комманду dotnet ef database update --project Vesta.Fullstack.Infrastructure --startup-project Vesta.Fullstack.Server.
5) Открыть консоль и ввести комманду dotnet run
6) Перейти по адресу https://localhost:50515/
## Готово
![Снимок экрана 2025-06-23 150854](https://github.com/user-attachments/assets/92c171ce-ae1f-42a5-a4dc-4bf0de5504bc)
