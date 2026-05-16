using System;

namespace PersonalFinanceManager.Models;

public class Budget
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CategoryId { get; set; }

    public decimal BudgetAmount { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime? CreatedAt { get; set; }
}
