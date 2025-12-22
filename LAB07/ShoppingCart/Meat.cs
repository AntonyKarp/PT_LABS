namespace ShoppingCart;

public enum MeatKind { Beef, Pork, Chicken }

public class Meat : Product, IDiscountable
{
    public MeatKind Kind { get; set; }

    public bool IsFrozen { get; set; }

    public Meat(string title, double pricePerKg, double amountKg, DateTime expirationDate, bool hasDefect, MeatKind kind, bool isFrozen)
        : base(title, pricePerKg, amountKg, false, expirationDate, hasDefect)
    {
        Kind = kind;
        IsFrozen = isFrozen;
    }

    public override string ToString()
        => base.ToString() + $", Вид={Kind}, Заморозка={IsFrozen}";
}
