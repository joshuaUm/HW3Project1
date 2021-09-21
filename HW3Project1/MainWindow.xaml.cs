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

namespace HW3Project1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double Mortgage = 0, Balance = 0;

        public const double ANNUAL_INTEREST_RATE = 6.39, MONTHLY_INTEREST_RATE = ANNUAL_INTEREST_RATE / 12;
        
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void updatePayment(bool updateOutput)
        {


            if (updateOutput)
            {
                double interestAmount = Balance * MONTHLY_INTEREST_RATE;
                double principalAmount = Mortgage - interestAmount;
                interestTextBox.Text = "$ " + Math.Round(interestAmount,2);
                principalTextBox.Text = "$ " + Math.Round(principalAmount,2);
            }
            else
            {
                interestTextBox.Text = "";
                principalTextBox.Text = "";
            }


        }

        private void mortgageTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            

            double num;
            if (double.TryParse(mortgageTextBox.Text,out num))
            {
                Mortgage = num;
                updatePayment(true);
            }
            else
            {
                if(interestTextBox != null && balanceTextBox != null)
                    updatePayment(false);
            }
        }

        private void balanceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            double num;
            if (double.TryParse(balanceTextBox.Text, out num))
            {
                Balance = num;
                updatePayment(true);
            }
            else
            {
                if (interestTextBox != null && balanceTextBox != null)
                    updatePayment(false);
            }
        }
    }
}
