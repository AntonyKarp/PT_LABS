namespace OOP_INHERINANCE;

public class Letter : Document
{
    public string Sender { get; set; }

    public string Recipient { get; set; }

    public bool IsRegisteredMail { get; set; }

    public override string ExtraInfo => $"От {Sender} -> {Recipient}, Заказное={IsRegisteredMail}";

    public Letter(string title, DateTime regDate, DateTime execDate, Status status, string sender, string recipient, bool isRegisteredMail)
        : base(title, regDate, execDate, status)
    {
        Sender = sender;
        Recipient = recipient;
        IsRegisteredMail = isRegisteredMail;
    }

    public override int PriorityLevel()
        => base.PriorityLevel() + (IsRegisteredMail ? 5 : 0);
}
