using System;

namespace PersonalFinanceManager.Models
{
    public class RecentTransactionStatistic
    {
        public int TransactionId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public string TransactionType { get; set; } = string.Empty;

        public DateTime TransactionDate { get; set; }
    }
}
