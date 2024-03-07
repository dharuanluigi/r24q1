using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace r24q1.Entity;

public class Transaction
{
    public int Id { get; set; }

    public int Value { get; set; }

    [Column(TypeName = "enum('d','c')")]
    public char Type { get; set; }

    [MaxLength(10)]
    public string Description { get; set; } = null!;

    public DateTime ProcessAt { get; set; }

    public int ClientId { get; set; }

    public Client Client { get; set; } = null!;

    public Transaction()
    {
    }

    public Transaction(int id, int value, char type, string description, DateTime processAt, int clientId, Client client)
    {
        Id = id;
        Value = value;
        Type = type;
        Description = description;
        ProcessAt = processAt;
        ClientId = clientId;
        Client = client;
    }
}