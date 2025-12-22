namespace ShoppingCart;

public class Cart
{
    public int MaxAmount { get; }

    private readonly List<Product> products;

    public Cart(int maxAmount)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(maxAmount, nameof(maxAmount));
        MaxAmount = maxAmount;
        products = new List<Product>();
    }

    public int Count => products.Count;

    public IReadOnlyList<Product> Products => products.AsReadOnly();

    public void AddToCart(Product p)
    {
        ArgumentNullException.ThrowIfNull(p, nameof(p));

        if (products.Count >= MaxAmount)
            throw new InvalidOperationException("Корзина заполнена.");

        products.Add(p);
    }

    public void DeleteFromCart(Product p)
    {
        ArgumentNullException.ThrowIfNull(p, nameof(p));
        products.Remove(p);
    }

    public double CalculateTotalCost()
    {
        double sum = 0;
        for (int i = 0; i < products.Count; i++)
            sum += products[i].TotalCost;
        return sum;
    }

    public double CalculateDiscountedCost()
    {
        double sum = 0;

        for (int i = 0; i < products.Count; i++)
        {
            Product p = products[i];

            double discount = 0;
            if (p is IDiscountable discountable)
                discount = discountable.GetDiscount();

            if (discount < 0) discount = 0;
            if (discount > p.TotalCost) discount = p.TotalCost;

            sum += p.TotalCost - discount;
        }

        return sum;
    }

    public double CalculateAvgVegeterianCost()
    {
        double sum = 0;
        int count = 0;

        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].IsVegeterian)
            {
                sum += products[i].TotalCost;
                count++;
            }
        }

        return count == 0 ? 0 : sum / count;
    }

    public static bool operator ==(Cart? c1, Cart? c2)
    {
        if (ReferenceEquals(c1, c2)) return true;
        if (c1 is null || c2 is null) return false;

        return Math.Abs(c1.CalculateDiscountedCost() - c2.CalculateDiscountedCost()) < 1e-6;
    }

    public static bool operator !=(Cart? c1, Cart? c2) => !(c1 == c2);

    public override bool Equals(object? obj)
        => obj is Cart other && this == other;

    public override int GetHashCode()
        => Math.Round(CalculateDiscountedCost(), 2).GetHashCode();

    public override string ToString()
        => $"Корзина: {Count}/{MaxAmount}, Без скидок={CalculateTotalCost():F2}, Со скидкой={CalculateDiscountedCost():F2}";
}
