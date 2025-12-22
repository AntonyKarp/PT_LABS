namespace OOP_INHERINANCE;

public class Payment : Document
{
    public decimal Amount { get; set; }

    public string ServiceName { get; set; }

    public bool IsPaid { get; set; }

    public override string ExtraInfo => $"Сумма={Amount}, Услуга={ServiceName}, Оплачено={IsPaid}";

    public Payment(string title, DateTime regDate, DateTime execDate, Status status, decimal amount, string serviceName, bool isPaid)
        : base(title, regDate, execDate, status)
    {
        Amount = amount;
        ServiceName = serviceName;
        IsPaid = isPaid;
    }

    public override int PriorityLevel()
    {
        int amountBonus = 0;

        if (Amount > 1000m) amountBonus = 20;
        else if (Amount > 300m) amountBonus = 10;
        else amountBonus = 5;

        int paidPenalty = IsPaid ? -50 : 0;

        return base.PriorityLevel() + amountBonus + paidPenalty;
    }
}
