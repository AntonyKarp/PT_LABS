namespace ShoppingCart;

public enum BeansType { Red, White, Chickpea }

public class Beans : Product, IDiscountable
{
    public BeansType Type { get; set; }

    public bool IsCanned { get; set; }

    public double ProteinPer100g { get; set; }

    public Beans(string name, double pricePerKg, double amountKg, DateTime expirationDate, bool hasDefect,
                 BeansType type, bool isCanned, double proteinPer100g)
        : base(name, pricePerKg, amountKg, true, expirationDate, hasDefect)
    {
        Type = type;
        IsCanned = isCanned;
        ProteinPer100g = proteinPer100g;
    }

    public override string ToString()
        => base.ToString() + $", Тип={Type}, Консервы={IsCanned}, Белок/100г={ProteinPer100g:F1}";
}
