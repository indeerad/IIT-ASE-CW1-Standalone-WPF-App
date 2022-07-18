using System;
using System.Collections.Generic;
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
using System.Globalization;

namespace Personal_Finance_Manager_V1.Views
{
    /// <summary>
    /// Interaction logic for WeeklyTransactionPage.xaml
    /// </summary>
    public partial class WeeklyTransactionPage : Page
    {
        private DateTime activeMonth = DateTime.Now;

        public WeeklyTransactionPage()
        {
            InitializeComponent();
            Initialize();            
        }

        public void Initialize() {
            string[] NamesOfMonths = DateTimeFormatInfo.CurrentInfo.MonthNames;
            CmbMonth.ItemsSource = NamesOfMonths.Reverse().Skip(1).Reverse();
            CmbMonth.SelectedIndex = DateTime.Now.Month - 1;

            string[] years = { "2019", "2020", "2021", "2022" };
            CmbYear.ItemsSource = years;
            CmbYear.SelectedValue = DateTime.Now.Year.ToString();
        }

        public void SetActiveMonth(object sender, SelectionChangedEventArgs e) 
        {
            if(CmbYear.SelectedValue != null && CmbMonth.SelectedIndex != -1)
            {
                activeMonth = DateTime.Parse(CmbYear.SelectedValue + "-" + (CmbMonth.SelectedIndex+1) + "-" + "01");
                LoadData();
            }
            
        }


        public void LoadData()
        {
            var dates = Enumerable.Range(1, DateTime.DaysInMonth(activeMonth.Year, activeMonth.Month)).Select(n => new DateTime(activeMonth.Year, activeMonth.Month, n));
            var weekends = from d in dates where d.DayOfWeek == DayOfWeek.Monday select d;

            List<WeeklyViewDto> data = new List<WeeklyViewDto>();
            weekends.ToList().ForEach(weekStart =>
            {
                WeeklyViewDto datum = new WeeklyViewDto();
                datum.StartDate = weekStart;
                datum.EndDate = weekStart.AddDays(6);
                datum.TransactionList = DataProcessingHelper.GetTransactionsByWeek(weekStart);
                
                data.Add(datum);
            });
            data.Reverse();
            TList.ItemsSource = data;
        }

        public void BtnUpdate(object sender, RoutedEventArgs e)
        {
            int TransactionId = (int)((Button)sender).Tag;

            AddTransactionPage pg = new AddTransactionPage(TransactionId);
            NavigationService.Navigate(pg);

        }

        public void BtnDelete(object sender, RoutedEventArgs e)
        {
            int TransactionId = (int)((Button)sender).Tag;

            MessageBoxResult res = MessageBox.Show("Are you sure that you want to delete the transaction. Deleting a recurring transaction will lead to " +
                "removal of all the transactions. Insted update such transaction", "Configuration", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (res == MessageBoxResult.Yes)
            {
                DataProcessingHelper.Delete(TransactionId);
                LoadData();
            }

        }
    }
}
