using System.Text;
using ShoppingCart;

Console.OutputEncoding = Encoding.UTF8;

Cart c1 = new Cart(5);
Cart c2 = new Cart(5);

c1.AddToCart(new Meat("Говядина", 18.0, 1.2, DateTime.Today.AddDays(2), false, MeatKind.Beef, false));
c1.AddToCart(new Apple("Яблоки Гала", 3.2, 1.5, DateTime.Today.AddDays(5), true, AppleSort.Gala, true));
c1.AddToCart(new Beans("Нут", 5.1, 2.0, DateTime.Today.AddDays(30), false, BeansKind.Chickpea, false));
c1.AddToCart(new Meat("Свинина", 12.5, 0.9, DateTime.Today.AddDays(0), true, MeatKind.Pork, false));
c1.AddToCart(new Apple("Яблоки Голден", 2.8, 2.3, DateTime.Today.AddDays(1), false, AppleSort.Golden, false));

c2.AddToCart(new Apple("Яблоки Гренни", 3.6, 1.8, DateTime.Today.AddDays(7), false, AppleSort.GrannySmith, true));
c2.AddToCart(new Beans("Фасоль красная", 4.0, 3.5, DateTime.Today.AddDays(20), true, BeansKind.Red, false));
c2.AddToCart(new Meat("Куриное филе", 9.3, 1.0, DateTime.Today.AddDays(1), false, MeatKind.Chicken, true));
c2.AddToCart(new Beans("Фасоль белая (консервы)", 6.0, 1.0, DateTime.Today.AddDays(120), false, BeansKind.White, true));
c2.AddToCart(new Apple("Яблоки (уценка)", 2.2, 2.0, DateTime.Today.AddDays(-1), true, AppleSort.Gala, false));

PrintCart("Корзина 1", c1);
Console.WriteLine();
PrintCart("Корзина 2", c2);

Console.WriteLine();
Console.WriteLine($"Сравнение корзин по стоимости со скидкой: {(c1 == c2 ? "РАВНЫ" : "НЕ РАВНЫ")}");

Console.WriteLine();
Console.WriteLine("Тест удаления: удаляем первый товар из корзины 1");
Product toDelete = c1.Products[0];
c1.DeleteFromCart(toDelete);
PrintCart("Корзина 1 (после удаления)", c1);

Console.WriteLine();
Console.WriteLine("Тест переполнения (должно быть исключение):");
try
{
    c1.AddToCart(new Beans("Лишний товар", 1.0, 1.0, DateTime.Today.AddDays(10), false, BeansKind.Red, false));
}
catch (Exception ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
}

static void PrintCart(string title, Cart cart)
{
    Console.WriteLine($"=== {title} ===");
    Console.WriteLine($"Вместимость: {cart.Count}/{cart.MaxAmount}");
    Console.WriteLine(new string('-', 120));
    Console.WriteLine(
        $"{"№",2} | {"Тип",-8} | {"Наименование",-22} | {"кг",6} | {"Цена/кг",8} | {"Сумма",10} | {"Годен до",-10} | {"Дней",4} | {"Дефект",6} | {"Скидка",10} | {"Итог",10}"
    );
    Console.WriteLine(new string('-', 120));

    double total = 0;
    double totalDiscounted = 0;

    for (int i = 0; i < cart.Products.Count; i++)
    {
        Product p = cart.Products[i];
        double discount = (p as IDiscountable)!.GetDiscount();
        double finalCost = p.TotalCost - discount;

        total += p.TotalCost;
        totalDiscounted += finalCost;

        Console.WriteLine(
            $"{i + 1,2} | {p.GetType().Name,-8} | {Trim(p.Title, 22),-22} | {p.AmountKg,6:F2} | {p.PricePerKg,8:F2} | {p.TotalCost,10:F2} | {p.ExpirationDate:dd.MM.yyyy,-10} | {p.DaysToExpire,4} | {(p.HasDefect ? "Да" : "Нет"),6} | {discount,10:F2} | {finalCost,10:F2}"
        );
    }

    Console.WriteLine(new string('-', 120));
    Console.WriteLine($"Сумма без скидок: {total:F2}");
    Console.WriteLine($"Сумма со скидкой: {totalDiscounted:F2}");
    Console.WriteLine($"Средняя стоимость вегетарианских (без скидок): {cart.CalculateAvgVegeterianCost():F2}");
}

static string Trim(string s, int maxLen)
{
    if (string.IsNullOrEmpty(s)) return "";
    if (s.Length <= maxLen) return s;
    return s.Substring(0, maxLen - 1) + "…";
}
