using System;

namespace Personal_Finance_Manager_V1.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime Date { get; set; }
        public TransactionCategory TransactionCategory { get; set; }
        public bool IsRecurring { get; set; }
        public DateTime? DoRecurringStarted { get; set; }
        public DateTime? DoRecurringEnded { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; } = String.Empty;

        public string ToYesNoString
        {
            get { return (IsRecurring) ? "Recurring: Yes" : "Recurring: No"; }
        }

        public string GetIncomeString
        {
            get
            {
                return (TransactionType.Name.Equals("Income")) ? Amount.ToString("N2") : "";
            }
        }

        public string GetExpenseString
        {
            get
            {
                return (TransactionType.Name.Equals("Expense")) ? Amount.ToString("N2") : "";
            }
        }



        public Transaction()
        {
        }

        public Transaction(TransactionType transactionType, DateTime date, TransactionCategory transactionCategory, bool isRecurring, DateTime doRecurringStarted, DateTime doRecurringEnded, double amount, string description)
        {
            TransactionType = transactionType;
            Date = date;
            TransactionCategory = transactionCategory;
            IsRecurring = isRecurring;
            DoRecurringStarted = doRecurringStarted;
            DoRecurringEnded = doRecurringEnded;
            Amount = amount;
            Description = description;
        }

        
    }
}
