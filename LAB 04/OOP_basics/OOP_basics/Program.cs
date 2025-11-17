namespace OOP_SAMPLE;
class Program
{
    static void Main(string[] args)
    {
        try
        {
            Product p1 = new Product("Ноутбук", 1200, 3);
            p1.PrintInfo();

            Product p2 = new Product("Мышка", 25.5, 10);
            p2.PrintInfo();

            // Проверка валидации
            Product p3 = new Product("Клавиатура", -100, 5);
            p3.PrintInfo();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        try
        {
            Product p4 = new Product("Монитор", 300, 2);
            p4.PrintInfo();

            // Попытка задания некорректного количества
            p4.Quantity = -5;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
