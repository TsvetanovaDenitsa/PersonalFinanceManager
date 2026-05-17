using System;

namespace PersonalFinanceManager.Models
{
    public class CategoryExpenseStatistic
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }

        public int TransactionCount { get; set; }
    }
}
