using System.Text;
using ShoppingCart;

Console.OutputEncoding = Encoding.UTF8;

Cart cart1 = new Cart(5);
Cart cart2 = new Cart(5);

cart1.AddToCart(new Meat("Говядина", 18.0, 1.2, DateTime.Today.AddDays(2), false, MeatType.Beef, "Лопатка", 12));
cart1.AddToCart(new Beans("Нут", 5.1, 2.0, DateTime.Today.AddDays(30), false, BeansType.Chickpea, false, 19));
cart1.AddToCart(new Apple("Яблоки Гала", 3.2, 1.5, DateTime.Today.AddDays(5), true, AppleSort.Gala, AppleColor.Red, true));
cart1.AddToCart(new Meat("Свинина", 12.5, 0.9, DateTime.Today.AddDays(0), true, MeatType.Pork, "Шея", 25));
cart1.AddToCart(new Apple("Яблоки Голден", 2.8, 2.3, DateTime.Today.AddDays(1), false, AppleSort.Golden, AppleColor.Yellow, false));

cart2.AddToCart(new Apple("Яблоки Гренни", 3.6, 1.8, DateTime.Today.AddDays(7), false, AppleSort.GrannySmith, AppleColor.Green, true));
cart2.AddToCart(new Beans("Фасоль красная", 4.0, 3.5, DateTime.Today.AddDays(20), true, BeansType.Red, false, 16));
cart2.AddToCart(new Meat("Куриное филе", 9.3, 1.0, DateTime.Today.AddDays(1), false, MeatType.Chicken, "Филе", 5));
cart2.AddToCart(new Beans("Фасоль белая (консервы)", 6.0, 1.0, DateTime.Today.AddDays(120), false, BeansType.White, true, 8));
cart2.AddToCart(new Apple("Яблоки (уценка)", 2.2, 2.0, DateTime.Today.AddDays(-1), true, AppleSort.Gala, AppleColor.Red, false));

PrintCart("Корзина 1", cart1);
Console.WriteLine();
PrintCart("Корзина 2", cart2);

Console.WriteLine();
Console.WriteLine($"Сравнение корзин по стоимости со скидкой: {(cart1 == cart2 ? "РАВНЫ" : "НЕ РАВНЫ")}");

Console.WriteLine();
Console.WriteLine("Тест удаления: удаляем первый товар из корзины 1");
Product toDelete = cart1.Products[0];
cart1.DeleteFromCart(toDelete);
PrintCart("Корзина 1 (после удаления)", cart1);

Console.WriteLine();
Console.WriteLine("Тест переполнения (должно быть исключение):");
try
{
    cart1.AddToCart(new Beans("Лишний товар", 1.0, 1.0, DateTime.Today.AddDays(10), false, BeansType.Red, false, 10));
}
catch (Exception ex)
{
    Console.WriteLine($"Ожидаемая ошибка: {ex.Message}");
}

static void PrintCart(string title, Cart cart)
{
    Console.WriteLine($"=== {title} ===");
    foreach (Product p in cart.Products)
    {
        double discount = (p as IDiscountable)?.GetDiscount() ?? 0;
        Console.WriteLine(p);
        Console.WriteLine($"  Скидка: {discount:F2}, Цена со скидкой: {(p.TotalCost - discount):F2}");
    }

    Console.WriteLine($"Итого без скидок: {cart.CalculateTotalCost():F2}");
    Console.WriteLine($"Итого со скидкой: {cart.CalculateDiscountedCost():F2}");
    Console.WriteLine($"Средняя стоимость вегетарианских (без скидок): {cart.CalculateAvgVegeterianCost():F2}");
}
