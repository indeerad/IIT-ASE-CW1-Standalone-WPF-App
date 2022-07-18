using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Personal_Finance_Manager_V1.Controllers;
using Personal_Finance_Manager_V1.Models;
using Personal_Finance_Manager_V1.Util.Dto;

namespace Personal_Finance_Manager_V1
{
    /// <summary>
    /// Interaction logic for IncomeReportPage.xaml
    /// </summary>
    public partial class IncomeReportPage : Page
    {
        private DateTime activeMonth = DateTime.Now;

        public IncomeReportPage()
        {
            InitializeComponent();
            Initialize();
            FinantialPrediction();
        }

        public void Initialize()
        {
            string[] NamesOfMonths = DateTimeFormatInfo.CurrentInfo.MonthNames;
            CmbMonth.ItemsSource = NamesOfMonths.Reverse().Skip(1).Reverse();
            CmbMonth.SelectedIndex = DateTime.Now.Month - 1;

            string[] years = { "2019", "2020", "2021", "2022" };
            CmbYear.ItemsSource = years;
            CmbYear.SelectedValue = DateTime.Now.Year.ToString();
        }

        public void SetActiveMonth(object sender, SelectionChangedEventArgs e)
        {
            if (CmbYear.SelectedValue != null && CmbMonth.SelectedIndex != -1)
            {
                activeMonth = DateTime.Parse(CmbYear.SelectedValue + "-" + (CmbMonth.SelectedIndex + 1) + "-" + "01");
                //  LoadData();
                
                DateTime startDate = new DateTime(activeMonth.Year, activeMonth.Month, 1);
                DateTime endDate = startDate.AddMonths(1).AddDays(-1);

                // Income
                List<Transaction> IncomeData = DataProcessingHelper.GetIncomeExpenseReport(startDate, endDate, "Income");
                double totalIncome = DataProcessingHelper.GetTotalIncomeExpense(startDate, endDate, "Income");

                List<IncomeReportDto> IncomeReportDto = new List<IncomeReportDto>();
                IncomeData.ForEach(idata => 
                {
                    IncomeReportDto datum = new IncomeReportDto();
                    datum.TransactionCategory = idata.TransactionCategory;
                    datum.Amount = idata.Amount;
                    datum.Percentage = (idata.Amount/ totalIncome);
                    IncomeReportDto.Add(datum);
                });
                IncomeReportView.ItemsSource = IncomeReportDto;
                LblTotalIncome.Text = "Total Income : " + totalIncome.ToString("N2");

                // Expense
                List<Transaction> ExpenseData = DataProcessingHelper.GetIncomeExpenseReport(startDate, endDate, "Expense");
                double totalExpense = DataProcessingHelper.GetTotalIncomeExpense(startDate, endDate, "Expense");

                List<ExpenseReportDto> ExpenseReportDto = new List<ExpenseReportDto>();
                ExpenseData.ForEach(idata =>
                {
                    ExpenseReportDto datum = new ExpenseReportDto();
                    datum.TransactionCategory = idata.TransactionCategory;
                    datum.Amount = idata.Amount;
                    datum.Percentage = (idata.Amount / totalExpense);
                    ExpenseReportDto.Add(datum);
                });
                ExpenseReportView.ItemsSource = ExpenseReportDto;
                LblTotalExpense.Text = "Total Expense : " + totalExpense.ToString("N2");

                //data.ForEach(d => Console.WriteLine(d.TransactionCategory.Name + " " + d.Amount));
                LblBalance.Text = "Balance : " + (totalIncome - totalExpense).ToString("N2");
                if(totalIncome - totalExpense >= 0)
                {
                    LblBalance.Foreground = new SolidColorBrush(Color.FromRgb(58, 110, 165));
                }
                else { LblBalance.Foreground = new SolidColorBrush(Color.FromRgb(255, 103, 0)); }
            }

            
        }
    
        public void FinantialPrediction()
        {
            //Generate 3 mothths dates
            List<DateTime> months = new List<DateTime>();
            DateTime StartingDateOfCurrentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            months.Add(StartingDateOfCurrentMonth.AddMonths(1));
            for(int i = 1; i <= 3; i++)
            {
                DateTime lastMonth = StartingDateOfCurrentMonth.AddMonths(-i);
                months.Add(lastMonth);
            }

            //Get Balance 
            double totalIncome = 0;
            double totalExpense = 0;
            months.ForEach(m =>
            {
                totalIncome += DataProcessingHelper.GetTotalIncomeExpense(m.AddMonths(-1), m.AddDays(-1), "Income");
                totalExpense += DataProcessingHelper.GetTotalIncomeExpense(m.AddMonths(-1), m.AddDays(-1), "Expense");

                
            });


            double meanOfIncome = totalIncome / months.Count;
            double meanOfExpense = totalExpense / months.Count;

            Console.WriteLine(meanOfIncome);
            Console.WriteLine(meanOfExpense);

            lblExpectedIncome.Text = meanOfIncome.ToString("N0");
            lblExpectedExpense.Text = meanOfExpense.ToString("N0");
            lblExpectedBalance.Text = (meanOfIncome - meanOfExpense).ToString("N0");

            if (meanOfIncome - meanOfExpense < 0)
            {
                lblExpectedBalance.Foreground = new SolidColorBrush(Color.FromRgb(255, 103, 0));
            }
            else
            {
                lblExpectedBalance.Foreground = new SolidColorBrush(Color.FromRgb(58, 110, 165));
            }

            //Get mean and display
        }
    }
}
