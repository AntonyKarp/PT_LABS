namespace ShoppingCart;

public interface IDiscountable
{
    double TotalCost { get; }
    int DaysToExpire { get; }
    bool HasDefect { get; }

    double GetDiscount()
    {
        double rate = 0;

        if (DaysToExpire <= 0) rate += 0.50;
        else if (DaysToExpire <= 1) rate += 0.30;
        else if (DaysToExpire <= 3) rate += 0.15;
        else if (DaysToExpire <= 7) rate += 0.05;

        if (HasDefect)
            rate += 0.10;

        if (rate > 0.80) rate = 0.80;
        if (rate < 0) rate = 0;

        return TotalCost * rate;
    }
}
