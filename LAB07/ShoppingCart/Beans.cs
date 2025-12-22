namespace ShoppingCart;

public enum BeansKind { Red, White, Chickpea }

public class Beans : Product, IDiscountable
{
    public BeansKind Kind { get; set; }

    public bool IsCanned { get; set; }

    public Beans(string title, double pricePerKg, double amountKg, DateTime expirationDate, bool hasDefect, BeansKind kind, bool isCanned)
        : base(title, pricePerKg, amountKg, true, expirationDate, hasDefect)
    {
        Kind = kind;
        IsCanned = isCanned;
    }

    public override string ToString()
        => base.ToString() + $", Вид={Kind}, Консервы={IsCanned}";
}
