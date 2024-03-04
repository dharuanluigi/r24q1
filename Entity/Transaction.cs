namespace r24q1.Entity;

public class Transaction
{
    public int Id { get; set; }

    public int Value { get; set; }

    public char Type { get; set; }

    public string Description { get; set; } = null!;

    public DateTime ProcessAt { get; set; }

    public Client Client { get; set; } = null!;
}