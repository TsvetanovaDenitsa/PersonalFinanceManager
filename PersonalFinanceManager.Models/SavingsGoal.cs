using System;

namespace PersonalFinanceManager.Models;

public class SavingsGoal
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string GoalName { get; set; } = string.Empty;

    public decimal TargetAmount { get; set; }

    public decimal? CurrentAmount { get; set; }

    public DateTime? Deadline { get; set; }

    public DateTime? CreatedAt { get; set; }
}
