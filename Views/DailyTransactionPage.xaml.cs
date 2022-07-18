using System;
using System.Runtime;
using System.Collections.Generic;
using System.Windows.Controls;
using Personal_Finance_Manager_V1.Controllers;
using Personal_Finance_Manager_V1.Models;
using System.Linq;
using System.Windows;

namespace Personal_Finance_Manager_V1.Views
{
    /// <summary>
    /// Interaction logic for DailyTransactionPage.xaml
    /// </summary>
    public partial class DailyTransactionPage : Page
    {
        //private readonly List<Transaction> TransactionList;

        public DailyTransactionPage()
        {
            InitializeComponent();
            PreData.RefreshData();
            LoadData();
            DataContext = this;
        }

        public void LoadData()
        {
            TList.ItemsSource = null;
            TList.ItemsSource = PreData.ProcessedTransactionList;
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
