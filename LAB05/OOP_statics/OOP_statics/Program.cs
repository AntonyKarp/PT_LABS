using OOP_Static;

Fraction fraction1 = new Fraction(5, 112);  
Fraction fraction2 = new Fraction(3, 678);  

Console.WriteLine($"Дробь 1: {fraction1}");
Console.WriteLine($"Дробь 2: {fraction2}");

Console.WriteLine($"Сравнение: {fraction1.Equals(fraction2)}");

Fraction sum = fraction1 + 5;
Console.WriteLine($"{fraction1} + {fraction2} = {sum}");

Fraction difference = fraction1 - fraction2;
Console.WriteLine($"{fraction1} - {fraction2} = {difference}");

Fraction product = fraction1 * fraction2;
Console.WriteLine($"{fraction1} * {fraction2} = {product}");

Fraction quotient = fraction1 / fraction2;
Console.WriteLine($"{fraction1} / {fraction2} = {quotient}");
