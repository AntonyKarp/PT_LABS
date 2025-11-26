using System;

namespace OOP_Basics
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
            
                Product p1 = new Product("Ноутбук", 1200, 3);
                p1.PrintInfo();

                p1.name = "rfhjkrh";
                p1.PrintInfo();

                Product p2 = new Product("Мышка", 25.5, 10);
                p1.PrintInfo();

                Product p3 = new Product("Клавиатура", -100, 5);
                p1.PrintInfo();

                Product p4 = new Product("Монитор", 300, 2);
                p1.PrintInfo();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"ОШИБКА: {ex.Message}");
            }

        }
    }
}
