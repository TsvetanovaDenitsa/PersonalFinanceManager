using System;

namespace PersonalFinanceManager.Models;

public class Transaction
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CategoryId { get; set; }

    public decimal Amount { get; set; }

    public string? Description { get; set; }

    public string TransactionType { get; set; } = string.Empty;

    public DateTime? TransactionDate { get; set; }

    public DateTime? CreatedAt { get; set; }
}
