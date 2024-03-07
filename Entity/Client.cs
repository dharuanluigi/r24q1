using System.Collections.Immutable;

namespace r24q1.Entity;

public class Client
{
    public int Id { get; set; }

    public int Limit { get; set; }

    public int Balance { get; set; }

    public ICollection<Transaction>? Transactions { get; set; }

    public Client()
    {
    }
    
    public Client(int id, int limit, int balance, ImmutableList<Transaction> transactions)
    {
        Id = id;
        Limit = limit;
        Balance = balance;
        Transactions = transactions;
    }

    public void Withdraw(int amount)
    {
        Balance -= amount;
    }
}