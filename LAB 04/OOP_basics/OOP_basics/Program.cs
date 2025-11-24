using System;

namespace OOP_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessProduct("Ноутбук", 1200, 3);
            ProcessProduct("Мышка", 25.5, 10);
            ProcessProduct("Клавиатура", -100, 5);
            ProcessProduct("Монитор", 300, 2);
        }

        static void ProcessProduct(string name, double price, int quantity)
        {
            try
            {
                Console.WriteLine($"Проверка товара: {name}");
                Product p = new Product(name, price, quantity);
                p.PrintInfo();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"ОШИБКА: {ex.Message}");
            }
        }
    }
}
