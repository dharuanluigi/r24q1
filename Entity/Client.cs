using System.Collections.Immutable;
using Org.BouncyCastle.Security;

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
        var oldValue = Balance;
        Balance -= amount;
        var unsingBalance = Balance * (-1);
        if (unsingBalance > Limit)
        {
            Balance = oldValue;
            throw new InvalidParameterException("O valor de saldo não pode ser maior que o limite");
        }
    }
}