namespace ShoppingCart;

public abstract class Product
{
    private string name;
    private double pricePerKg;
    private double amountKg;
    private DateTime expirationDate;

    public string Name
    {
        get => name;
        set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(Name));
            name = value.Trim();
        }
    }

    public double PricePerKg
    {
        get => pricePerKg;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value, nameof(PricePerKg));
            pricePerKg = value;
        }
    }

    public double AmountKg
    {
        get => amountKg;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value, nameof(AmountKg));
            amountKg = value;
        }
    }

    public bool IsVegeterian { get; protected set; }

    public bool HasDefect { get; set; }

    public DateTime ExpirationDate
    {
        get => expirationDate;
        set => expirationDate = value.Date;
    }

    public int DaysToExpire => (ExpirationDate.Date - DateTime.Today).Days;

    public double TotalCost => PricePerKg * AmountKg;

    protected Product(string name, double pricePerKg, double amountKg, bool isVegeterian, DateTime expirationDate, bool hasDefect)
    {
        Name = name;
        PricePerKg = pricePerKg;
        AmountKg = amountKg;
        IsVegeterian = isVegeterian;
        ExpirationDate = expirationDate;
        HasDefect = hasDefect;
    }

    public override string ToString()
        => $"{GetType().Name}: {Name}, {AmountKg:F2} кг x {PricePerKg:F2} = {TotalCost:F2}, " +
           $"Вегетарианский={IsVegeterian}, Дефект={HasDefect}, Годен до {ExpirationDate:dd.MM.yyyy} (дней: {DaysToExpire})";
}
