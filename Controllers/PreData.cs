using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal_Finance_Manager_V1.Models;
using Personal_Finance_Manager_V1.Services;

namespace Personal_Finance_Manager_V1.Controllers
{

    public class PreData
    {
        public static List<TransactionType> TransactionTypeList = new List<TransactionType>();
        public static List<TransactionCategory> IncomeCateoryList = new List<TransactionCategory>();
        public static List<TransactionCategory> ExpenseCateoryList = new List<TransactionCategory>();
        public static List<Transaction> TransactionList = new List<Transaction>();
        public static List<Transaction> ProcessedTransactionList = new List<Transaction>(); // 

        public PreData() 
        {
            TransactionTypeList.Add(new TransactionType("Income"));
            TransactionTypeList.Add(new TransactionType("Expense"));

            string[] IncomeItems = { "Salary", "Allowance", "Bonus", "Petty Cash", "Other" };
            foreach (string item in IncomeItems)
            {
                IncomeCateoryList.Add(new TransactionCategory(item));
            }

            string[] ExpenseItems = { "Food", "Utilities", "Transport", "Apparel", "Education", "Household", "Entertainment", "Rental" };
            foreach (string item in ExpenseItems)
            {
                ExpenseCateoryList.Add(new TransactionCategory(item));
            }

            //int[] Ids = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
            //string[] TType = { "Income", "Expense", "Expense", "Expense", "Income", "Expense", "Expense", "Expense", "Expense", "Expense", "Income" };
            //string[] TCategory = { "Salary", "Rental", "Utilities", "Food", "Bonus", "Entertainment", "Household", "Transport", "Utilities", "Utilities", "Allowance" };
            //string[] Date = { "2021-12-13", "2021-12-13", "2021-12-14", "2021-12-20", "2021-12-21", "2021-12-23", "2022-01-12", "2022-01-15", "2022-01-22", "2022-01-22", "2022-03-15" };
            //bool[] IsRecurring = { true, true, false, false, false, true, false, false, false, false, false };
            //string[] RecuringStartDate = { "2021-01-13", "2021-01-13", "", "", "", "2021-01-03", "", "", "", "", "" };
            //string[] RecuringEndDate = { "", "", "", "", "", "2022-01-02", "", "", "", "", "" };
            //double[] Amount = { 100000, 45000, 670, 12640, 5000, 1800, 45000, 1700, 16700, 890, 5000 };
            //string[] Notes = { "EUC Salary", "House Rent", "Dialog Bill - Dec", "Shopped at Keells", "Christmas Bonus", "Netflix", "Singer-Hotwater Shower", "Uber Gampaha to Colombo", "SLT Nov & Dec Bills", "Dialog Bill - Jan", "Transport allowance" };


            //for (int i = 0; i < TType.Count(); i++) 
            //{
            //    Transaction transaction = new Transaction();
            //    transaction.Id = Ids[i];
            //    transaction.TransactionType = new TransactionType(TType[i]);
            //    transaction.Date = DateTime.Parse(Date[i]);
            //    transaction.TransactionCategory = new TransactionCategory(TCategory[i]);
            //    transaction.IsRecurring = IsRecurring[i];
            //    transaction.DoRecurringStarted = RecuringStartDate[i].Equals("")? new DateTime() : DateTime.Parse(RecuringStartDate[i]);
            //    transaction.DoRecurringEnded = RecuringEndDate[i].Equals("")? new DateTime() : DateTime.Parse(RecuringEndDate[i]);
            //    transaction.Amount = Amount[i];
            //    transaction.Description = Notes[i];

            //    TransactionList.Add(transaction);
            //}
            x();
            RefreshData();
        }

        public async void x()
        {
            List<Transaction> IncomeTransactions = (List<Transaction>)await TransactionService.getAllIncome();
            List<Transaction> ExpenseTransactions = (List<Transaction>)await TransactionService.getAllExpense();
            TransactionList.AddRange(IncomeTransactions);
            TransactionList.AddRange(ExpenseTransactions);
        }
      
        public static void RefreshData()
        {
            ProcessedTransactionList.Clear();
            ProcessedTransactionList.AddRange(TransactionList);
            foreach (var transaction in TransactionList)
            {
                if (transaction.IsRecurring == true)
                {
                    if (transaction.DoRecurringEnded.Equals(new DateTime()))
                    {
                        DateTime Today = DateTime.Now;
                        for (var date = transaction.DoRecurringStarted.Value.AddMonths(1); date < Today; date = date.AddMonths(1))
                        {
                            Transaction RecurringTS = new Transaction();
                            RecurringTS.Id = transaction.Id;
                            RecurringTS.TransactionType = transaction.TransactionType;
                            RecurringTS.Date = date;
                            RecurringTS.TransactionCategory = transaction.TransactionCategory;
                            RecurringTS.IsRecurring = transaction.IsRecurring;
                            RecurringTS.DoRecurringStarted = transaction.DoRecurringStarted;
                            RecurringTS.DoRecurringEnded = transaction.DoRecurringEnded;
                            RecurringTS.Amount = transaction.Amount;
                            RecurringTS.Description = transaction.Description;
                            ProcessedTransactionList.Add(RecurringTS);
                        }
                    }
                    else
                    {
                        //Console.WriteLine("Recurring Stopped");
                        for (var date = transaction.DoRecurringStarted.Value.AddMonths(1); date < transaction.DoRecurringEnded; date = date.AddMonths(1))
                        {
                            Transaction RecurringTS = new Transaction();
                            RecurringTS.Id = transaction.Id;
                            RecurringTS.TransactionType = transaction.TransactionType;
                            RecurringTS.Date = date;
                            RecurringTS.TransactionCategory = transaction.TransactionCategory;
                            RecurringTS.IsRecurring = transaction.IsRecurring;
                            RecurringTS.DoRecurringStarted = transaction.DoRecurringStarted;
                            RecurringTS.DoRecurringEnded = transaction.DoRecurringEnded;
                            RecurringTS.Amount = transaction.Amount;
                            RecurringTS.Description = transaction.Description;
                            ProcessedTransactionList.Add(RecurringTS);
                        }
                    }
                }
            }
            ProcessedTransactionList.Sort((x, y) => DateTime.Compare(y.Date, x.Date));            
        }        
    }
}
