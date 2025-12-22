namespace ShoppingCart;

public enum MeatType { Beef, Pork, Chicken }

public class Meat : Product, IDiscountable
{
    public MeatType Type { get; set; }

    public string Cut { get; set; }

    public double FatPercent { get; set; }

    public Meat(string name, double pricePerKg, double amountKg, DateTime expirationDate, bool hasDefect,
                MeatType type, string cut, double fatPercent)
        : base(name, pricePerKg, amountKg, false, expirationDate, hasDefect)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(cut, nameof(cut));
        Type = type;
        Cut = cut.Trim();
        FatPercent = fatPercent;
    }

    public override string ToString()
        => base.ToString() + $", Тип={Type}, ЧастЬ={Cut}, Жирность={FatPercent:F1}%";
}
