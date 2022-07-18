using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal_Finance_Manager_V1.Models;

namespace Personal_Finance_Manager_V1.Util.Dto
{
    public class WeeklyViewDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Transaction> TransactionList { get; set; }
        public double TotalIncome
        {
            get
            {
                return TransactionList.Where(t => t.TransactionType.Name == "Income").Sum(t => t.Amount);
            }
        }
        public double TotalExpense
        {
            get 
            {
                return TransactionList.Where(t => t.TransactionType.Name == "Expense").Sum(t => t.Amount);
            }
        }

      
    }
}
