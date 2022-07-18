using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Personal_Finance_Manager_V1.Models;

namespace Personal_Finance_Manager_V1.Util.Dto
{
    public class ExpenseReportDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TransactionCategory TransactionCategory { get; set; }
        public double Amount { get; set; }
        public double Percentage { get; set; }
    }
}
