namespace OOP_INHERINANCE;

public class Transfer : Document
{
    public string FromPerson { get; set; }

    public string ToPerson { get; set; }

    public string AssetName { get; set; }

    public decimal AssetValue { get; set; }

    public override string ExtraInfo => $"От {FromPerson} -> {ToPerson}, {AssetName}, Стоимость={AssetValue}";

    public Transfer(string title, DateTime regDate, DateTime execDate, Status status, string fromPerson, string toPerson, string assetName, decimal assetValue)
        : base(title, regDate, execDate, status)
    {
        FromPerson = fromPerson;
        ToPerson = toPerson;
        AssetName = assetName;
        AssetValue = assetValue;
    }

    public override int PriorityLevel()
        => base.PriorityLevel() + (AssetValue > 5000m ? 20 : 5);
}
