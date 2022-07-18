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
using Personal_Finance_Manager_V1.Views;
using Personal_Finance_Manager_V1.Controllers;
using System.Globalization;
using Personal_Finance_Manager_V1.Models;

namespace Personal_Finance_Manager_V1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            new PreData();
            MainWindowFrame.Content = new WeeklyTransactionPage();
            TransactionMenu.SelectedIndex = 1;
        }

        private void LoadAddTransactionPage(object sender, RoutedEventArgs e)
        {
            TransactionMenu.SelectedItem = null;
            ReportMenu.SelectedItem = null;
            MainWindowFrame.Content = new AddTransactionPage();
        }

        private void LoadDailyTransactionPage(object sender, RoutedEventArgs e)
        {
            ReportMenu.SelectedItem = null;
            MainWindowFrame.Content = new DailyTransactionPage();
        }

        private void LoadWeeklyTransactionPage(object sender, RoutedEventArgs e)
        {
            ReportMenu.SelectedItem = null;
            MainWindowFrame.Content = new WeeklyTransactionPage();
        }

        private void LoadIncomeReportPage(object sender, RoutedEventArgs e)
        {
            TransactionMenu.SelectedItem = null;
            MainWindowFrame.Content = new IncomeReportPage();
        }

        private void Dragable(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void Minimize_window(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Close_window(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
