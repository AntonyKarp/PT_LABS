namespace ShoppingCart;

public abstract class Product
{
    private string title;
    private double pricePerKg;
    private double amountKg;
    private DateTime expirationDate;

    public string Title
    {
        get => title;
        set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(Title));
            title = value.Trim();
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

    protected Product(string title, double pricePerKg, double amountKg, bool isVegeterian, DateTime expirationDate, bool hasDefect)
    {
        Title = title;
        PricePerKg = pricePerKg;
        AmountKg = amountKg;
        IsVegeterian = isVegeterian;
        ExpirationDate = expirationDate;
        HasDefect = hasDefect;
    }

    public override string ToString()
        => $"{GetType().Name}: {Title}, {AmountKg:F2} кг x {PricePerKg:F2} = {TotalCost:F2}, " +
           $"Вегетарианский={IsVegeterian}, Дефект={HasDefect}, Срок={ExpirationDate:dd.MM.yyyy} (дней: {DaysToExpire})";
}
