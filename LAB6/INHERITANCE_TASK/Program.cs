using System.Text;
using OOP_INHERINANCE;

Console.OutputEncoding = Encoding.UTF8;

Document[] documents =
{
    new Order("Распоряжение №1", DateTime.Now.AddDays(-2), DateTime.Now.AddDays(3), Status.REGISTERED, "Отдел кадров", true),
    new Order("Распоряжение №2", DateTime.Now.AddDays(-1), DateTime.Now.AddDays(10), Status.INPROGRESS, "ИТ", false),

    new Letter("Письмо А", DateTime.Now.AddDays(-5), DateTime.Now.AddDays(1), Status.REGISTERED, "Компания A", "Компания B", true),
    new Letter("Письмо B", DateTime.Now.AddDays(-3), DateTime.Now.AddDays(20), Status.DRAFT, "Клиент", "Поддержка", false),

    new Payment("Оплата интернета", DateTime.Now.AddDays(-10), DateTime.Now.AddDays(2), Status.INPROGRESS, 45m, "Интернет-провайдер", false),
    new Payment("Оплата аренды", DateTime.Now.AddDays(-12), DateTime.Now.AddDays(0), Status.REGISTERED, 500m, "Арендодатель", false),

    new Transfer("Передача ноутбука", DateTime.Now.AddDays(-2), DateTime.Now.AddDays(7), Status.REGISTERED, "Иванов", "Петров", "Ноутбук", 1200m),
    new Transfer("Передача оборудования", DateTime.Now.AddDays(-20), DateTime.Now.AddDays(4), Status.INPROGRESS, "Отдел А", "Отдел Б", "Оборудование", 8000m),

    new Letter("Письмо C", DateTime.Now.AddDays(-1), DateTime.Now.AddDays(5), Status.REGISTERED, "Директор", "Всем", true),
    new Payment("Оплата консультации", DateTime.Now.AddDays(-6), DateTime.Now.AddDays(14), Status.INPROGRESS, 1500m, "Консультант", false),
};

Document highestPriority = documents[0];
foreach (Document d in documents)
    if (d.Priority > highestPriority.Priority)
        highestPriority = d;

Document minExecution = documents[0];
foreach (Document d in documents)
    if (d.DaysToExecution < minExecution.DaysToExecution)
        minExecution = d;

Console.WriteLine("Все документы:");
Console.WriteLine(new string('-', 170));
Console.WriteLine($"{"№",2} | {"Тип",-9} | {"Наименование",-30} | {"Статус",-11} | {"Регистрация",-10} | {"Исполнение",-10} | {"Срок(дн)",8} | {"Приоритет",9} | {"Дополнительно",-60}");
Console.WriteLine(new string('-', 170));

for (int i = 0; i < documents.Length; i++)
{
    Document d = documents[i];

    Console.WriteLine(
        $"{i + 1,2} | {d.GetType().Name,-9} | {d.Title,-30} | {d.Status,-11} | {d.RegistrationDate:dd.MM.yyyy,-10} | {d.ExecutionDate:dd.MM.yyyy,-10} | {d.DaysToExecution,8} | {d.Priority,9} | {d.ExtraInfo,-60}"
    );
}

Console.WriteLine(new string('-', 170));
Console.WriteLine();

Console.WriteLine("Документ с наивысшим приоритетом:");
Console.WriteLine(highestPriority);
Console.WriteLine();

Console.WriteLine("Документ с наименьшим сроком до исполнения:");
Console.WriteLine(minExecution);
