using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal_Finance_Manager_V1.Models;
using Personal_Finance_Manager_V1.Controllers;

namespace Personal_Finance_Manager_V1.Controllers
{
    public class DataProcessingHelper
    {
        public static List<Transaction> GetIncomeExpenseReport(DateTime start, DateTime end, string type)
        {
          return  PreData.ProcessedTransactionList
                .Where(t => t.Date >= start && t.Date <= end && t.TransactionType.Name == type)
                .GroupBy(t => t.TransactionCategory)
                .Select(cl => new Transaction
                {
                    TransactionType = cl.First().TransactionType,
                    TransactionCategory = cl.First().TransactionCategory,
                    Amount = cl.Sum(a => a.Amount)
                }).OrderByDescending(tl => tl.Amount).ToList();
        } 

        public static void Delete(int TransactionId)
        {
            PreData.TransactionList.RemoveAll(t => t.Id == TransactionId);
            PreData.RefreshData();
        }

        public static void Insert(Transaction transaction)
        {
            PreData.TransactionList.Add(transaction);
            PreData.RefreshData();
        }

        public static void Update(Transaction transaction)
        {
            Delete(transaction.Id);
            Insert(transaction);
            PreData.RefreshData();
        }

        public static Transaction GetTransaction(int TransactionId)
        {
            return PreData.TransactionList.Find(t => t.Id == TransactionId);
        }

        public static double GetTotalIncomeExpense(DateTime start, DateTime end, string type)
        {
            return PreData.ProcessedTransactionList
                .Where(t => t.Date >= start && t.Date <= end && t.TransactionType.Name == type)
                .Sum(l => l.Amount);
        }


        public static List<Transaction> GetTransactionsByYearAndMonth(List<Transaction> transactions, DateTime Date)
        {
            int year = Date.Year;
            int month = Date.Month;
            return transactions.Where(t => t.Date.Year == year && t.Date.Month == month).ToList();
        }

        public static List<Transaction> GetTransactionsByWeek(DateTime start) 
        {
           return PreData.ProcessedTransactionList.Where(t => t.Date >= start && t.Date < start.AddDays(7)).ToList();
        }


        public static List<Transaction> GetTransactionsByDate(List<Transaction> transactions, DateTime Date)
        {
            return transactions.Where(t => t.Date.Date == Date).ToList();
        }

        public static int GetNextId() 
        { 
            return PreData.TransactionList.Max(t => t.Id) + 1;
        }

    }
}
