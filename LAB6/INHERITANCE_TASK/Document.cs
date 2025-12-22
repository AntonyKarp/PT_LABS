namespace OOP_INHERINANCE;

public enum Status { DRAFT, REGISTERED, INPROGRESS, COMPLETED, CANCELLED }

public class Document
{
    public string Title { get; set; }

    public DateTime RegistrationDate { get; set; }

    public DateTime ExecutionDate { get; set; }

    public Status Status { get; set; }

    public int DaysToExecution => (ExecutionDate.Date - DateTime.Now.Date).Days;

    public int Priority => PriorityLevel();

    public virtual string ExtraInfo => "";

    public Document(string title, DateTime regDate, DateTime execDate, Status status)
    {
        Title = title;
        RegistrationDate = regDate;
        ExecutionDate = execDate;
        Status = status;
    }

    public virtual int PriorityLevel()
    {
        int days = DaysToExecution;

        if (days <= 0) return 100;
        if (days <= 3) return 80;
        if (days <= 7) return 60;
        if (days <= 14) return 40;

        return 20;
    }

    public override string ToString()
        => $"{GetType().Name}: {Title} (Срок={DaysToExecution} дн., Приоритет={Priority})";
}
