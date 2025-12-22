namespace OOP_INHERINANCE;

public class Order : Document
{
    public string Department { get; set; }

    public bool IsSigned { get; set; }

    public override string ExtraInfo => $"Отдел={Department}, Подписано={IsSigned}";

    public Order(string title, DateTime regDate, DateTime execDate, Status status, string department, bool isSigned)
        : base(title, regDate, execDate, status)
    {
        Department = department;
        IsSigned = isSigned;
    }

    public override int PriorityLevel()
        => base.PriorityLevel() + (IsSigned ? 10 : 0);
}
