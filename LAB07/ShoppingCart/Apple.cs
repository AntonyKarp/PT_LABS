namespace ShoppingCart;

public enum AppleSort { Gala, Golden, GrannySmith }

public class Apple : Product, IDiscountable
{
    public AppleSort Sort { get; set; }

    public bool IsOrganic { get; set; }

    public Apple(string title, double pricePerKg, double amountKg, DateTime expirationDate, bool hasDefect, AppleSort sort, bool isOrganic)
        : base(title, pricePerKg, amountKg, true, expirationDate, hasDefect)
    {
        Sort = sort;
        IsOrganic = isOrganic;
    }

    public override string ToString()
        => base.ToString() + $", Сорт={Sort}, Органика={IsOrganic}";
}
