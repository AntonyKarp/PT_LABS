namespace ShoppingCart;

public enum AppleSort { Gala, Golden, GrannySmith }
public enum AppleColor { Red, Green, Yellow }

public class Apple : Product, IDiscountable
{
    public AppleSort Sort { get; set; }

    public AppleColor Color { get; set; }

    public bool IsOrganic { get; set; }

    public Apple(string name, double pricePerKg, double amountKg, DateTime expirationDate, bool hasDefect,
                 AppleSort sort, AppleColor color, bool isOrganic)
        : base(name, pricePerKg, amountKg, true, expirationDate, hasDefect)
    {
        Sort = sort;
        Color = color;
        IsOrganic = isOrganic;
    }

    public override string ToString()
        => base.ToString() + $", Сорт={Sort}, Цвет={Color}, Органика={IsOrganic}";
}
