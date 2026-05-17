using System;

namespace PersonalFinanceManager.Models
{
    public class MonthlyStatistic
    {
        public int Month { get; set; }

        public int Year { get; set; }

        public decimal TotalIncome { get; set; }

        public decimal TotalExpenses { get; set; }

        public decimal Balance { get; set; }
    }
}
