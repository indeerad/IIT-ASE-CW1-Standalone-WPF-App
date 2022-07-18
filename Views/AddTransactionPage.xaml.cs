using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Personal_Finance_Manager_V1.Controllers;
using Personal_Finance_Manager_V1.Models;

namespace Personal_Finance_Manager_V1.Views
{
    public partial class AddTransactionPage : Page
    {
        public static List<TransactionType> TransactionTypes { get; set; }
        public static List<TransactionCategory> TransactionCategories { get; set; }
        private Transaction OldTransaction;
        private bool Insrtible = true;


        public AddTransactionPage()
        {
            InitializeComponent();
            CmbTransactionCategory.IsEnabled = false;
            TransactionTypes = PreData.TransactionTypeList;
            DataContext = this;     
        }

        // Update
        public AddTransactionPage(int TransactionId)
        {
            InitializeComponent();
            Insrtible = false;
            LblTitle.Text = "Update a Transaction";
            CmbTransactionCategory.IsEnabled = false;
            TransactionTypes = PreData.TransactionTypeList;
            DataContext = this;

            LoadDate(TransactionId);
        }

        private void LoadDate(int TransactionId)
        {
            OldTransaction = DataProcessingHelper.GetTransaction(TransactionId);
           
            
            TxtAmount.Text = OldTransaction.Amount.ToString();
            TxtDescription.Text = OldTransaction.Description.ToString();
            DoTransaction.SelectedDate = OldTransaction.Date;
            CbxRucurring.IsChecked = OldTransaction.IsRecurring;
            CmbTransactionType.SelectedValue = OldTransaction.TransactionType.ToString();
            CmbTransactionCategory.SelectedItem = OldTransaction.TransactionCategory.ToString();

            if(OldTransaction.TransactionType.Name == "Income") { 
                CmbTransactionType.SelectedIndex = 0;
                if (OldTransaction.TransactionCategory.Name == "Salary") { CmbTransactionCategory.SelectedIndex = 0; }
                if (OldTransaction.TransactionCategory.Name == "Allowance") { CmbTransactionCategory.SelectedIndex = 1; }
                if (OldTransaction.TransactionCategory.Name == "Bonus") { CmbTransactionCategory.SelectedIndex = 2; }
                if (OldTransaction.TransactionCategory.Name == "Petty Cash") { CmbTransactionCategory.SelectedIndex = 3; }

            }
            if (OldTransaction.TransactionType.Name == "Expense") { 
                CmbTransactionType.SelectedIndex = 1;
                if (OldTransaction.TransactionCategory.Name == "Food") { CmbTransactionCategory.SelectedIndex = 0; }
                if (OldTransaction.TransactionCategory.Name == "Utlities") { CmbTransactionCategory.SelectedIndex = 1; }
                if (OldTransaction.TransactionCategory.Name == "Transport") { CmbTransactionCategory.SelectedIndex = 2; }
                if (OldTransaction.TransactionCategory.Name == "Apparel") { CmbTransactionCategory.SelectedIndex = 3; }
                if (OldTransaction.TransactionCategory.Name == "Education") { CmbTransactionCategory.SelectedIndex = 3; }
                if (OldTransaction.TransactionCategory.Name == "Household") { CmbTransactionCategory.SelectedIndex = 3; }
                if (OldTransaction.TransactionCategory.Name == "Entertainment") { CmbTransactionCategory.SelectedIndex = 3; }
                if (OldTransaction.TransactionCategory.Name == "Rental") { CmbTransactionCategory.SelectedIndex = 3; }
            } 

           
        }

        private void GetCategoryData(object sender, SelectionChangedEventArgs e)
        {
            TransactionType transactionType = (TransactionType)CmbTransactionType.SelectedItem;
            CmbTransactionCategory.IsEnabled = true;
            if (transactionType != null) 
            {
                if (transactionType.Name.Equals("Income"))
                {
                    Console.WriteLine("Income");
                    TransactionCategories = PreData.IncomeCateoryList;
                }
                if(transactionType.Name.Equals("Expense"))
                {
                    Console.WriteLine("Expense");
                    TransactionCategories = PreData.ExpenseCateoryList;
                }
                CmbTransactionCategory.ItemsSource = TransactionCategories;
                
            }
        }

        public bool Validate() 
        {
            if(CmbTransactionType.SelectedIndex == -1) 
            {
                LblTransactionType.Foreground = new SolidColorBrush(Colors.Red); 
                return false;
            }
            else { LblTransactionType.Foreground = new SolidColorBrush(Colors.Gray); }

            if(CmbTransactionCategory.SelectedIndex == -1)
            {
                LblTransactionCategory.Foreground = new SolidColorBrush(Colors.Red);
                return false;
            }
            else { LblTransactionCategory.Foreground = new SolidColorBrush(Colors.Gray); }

            if (TxtAmount.Text == "")
            {
                LblAmount.Foreground = new SolidColorBrush(Colors.Red);
                return false;
            }
            else {
                int x = 0;
                if (!int.TryParse(TxtAmount.Text, out x) || !(x > 0)) {
                    LblAmount.Foreground = new SolidColorBrush(Colors.Red);
                    LblAmount.Text = "Invalid amount";
                    return false;
                }
                LblAmount.Text = "Enter amount";
                LblAmount.Foreground = new SolidColorBrush(Colors.Gray); 
            }

            if (DoTransaction.SelectedDate == null)
            {
                LblDate.Foreground = new SolidColorBrush(Colors.Red);
                return false;
            }
            else
            { LblDate.Foreground = new SolidColorBrush(Colors.Gray); }
            return true;
        }

        private void BtnSubmit(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {                
                Transaction transaction = new Transaction();
                transaction.TransactionType = (TransactionType)CmbTransactionType.SelectedItem;
                transaction.TransactionCategory = (TransactionCategory)CmbTransactionCategory.SelectedItem;
                transaction.Amount = Double.Parse(TxtAmount.Text);
                transaction.IsRecurring = CbxRucurring.IsChecked ?? false;
                transaction.Description = TxtDescription.Text;
                transaction.Date = (DateTime)DoTransaction.SelectedDate;

                string message;
                if (Insrtible)
                {
                    transaction.Id = DataProcessingHelper.GetNextId();
                    DataProcessingHelper.Insert(transaction);
                    message = "Successfully Saved";
                }
                else
                {
                    transaction.Id = OldTransaction.Id;
                    DataProcessingHelper.Update(transaction);
                    message = "Successfully Updated";
                }
                MessageBox.Show(message);
                WeeklyTransactionPage pg = new WeeklyTransactionPage();
                NavigationService.Navigate(pg);
            }
        }

        private void BtnClear(object sender, RoutedEventArgs e)
        {
            CmbTransactionCategory.SelectedIndex = -1;
            CmbTransactionType.SelectedIndex = -1;
            TxtAmount.Text = "";
            TxtDescription.Text = "";
            CbxRucurring.IsChecked = false;
            DoTransaction.SelectedDate = new DateTime();

            LblAmount.Foreground = new SolidColorBrush(Colors.Gray);
            LblDate.Foreground = new SolidColorBrush(Colors.Gray);
            LblTransactionCategory.Foreground = new SolidColorBrush(Colors.Gray);
            LblTransactionType.Foreground = new SolidColorBrush(Colors.Gray);

        }
    }
}
