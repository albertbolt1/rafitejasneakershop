using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace YetAnotherShoppingApp.Views
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        const string ConnectionString = "server = localhost; user id = root; database=dummycreditcard;Password=albertbolt23;";
        string secretCode;
        string money;
        string moneyinATM;
        int id;
        public BlankPage1()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var value = (String)e.Parameter;
            money = value;
            ValueTextBox.Text = value;
        }
    
       private void ClosePopupClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
       {
           // if the Popup is open, then close it 
           if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
       }
    
        private void OnWindowsCheckoutClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

            

            if (!StandardPopup.IsOpen) { StandardPopup.IsOpen = true; }
    
            //
            //
            //
            //this.ViewModel.OnWindowsCheckoutClicked();
        }
  
        private void OnSubmitClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            string nameOnCard = name.Text;
            string cardNumber = card_number.Text;
            string CVV = cvv.Text;
            string expiryMonth = expiry_month.Text;
            string expiryYear = expiry_year.Text;

            using (MySqlConnection sqlconn = new MySqlConnection(ConnectionString))
            {
                MySqlDataReader rdr = null;
                sqlconn.Open();
                var stm = "SELECT CARDID,SECRETCODE,AMOUNT FROM dummycard WHERE NAME='"+nameOnCard+"' AND CARDNUMBER='"+cardNumber+
                    "' AND CVV='"+CVV+"' AND EXPIRYMONTH='"+expiryMonth+"' AND EXPIRYYEAR='"+expiryYear+"'";
                var cmd = new MySqlCommand(stm, sqlconn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    id = Int32.Parse(rdr["CARDID"].ToString());
                    secretCode = rdr["SECRETCODE"].ToString(); 
                   moneyinATM = rdr["AMOUNT"].ToString();
                }
                sqlconn.Close();

            }

            if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
            if (!StandardPopup1.IsOpen) { StandardPopup1.IsOpen = true; }
            // Frame.Navigate(typeof(Views.BlankPage1), this.ViewModel.TotalCostString);
            //
            //
            //
            //this.ViewModel.OnWindowsCheckoutClicked();
        }
        
        private void OnCloseClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // if the Popup is open, then close it 
            if (StandardPopup2.IsOpen) { StandardPopup2.IsOpen = false; }
        }

        private void OnCloseClicked1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // if the Popup is open, then close it 
            if (StandardPopup4.IsOpen) { StandardPopup4.IsOpen = false; }
        }

        private void OnCloseClicked2(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // if the Popup is open, then close it 
            if (StandardPopup3.IsOpen) { StandardPopup4.IsOpen = false; }
        }
        private void OnSubmitClicked1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            string presentCode = secret_code.Text;
            if(secretCode!=presentCode)
            {
                if (StandardPopup1.IsOpen) { StandardPopup1.IsOpen = false; }
                if (!StandardPopup3.IsOpen) { StandardPopup3.IsOpen = true; }

            }
            else
            {
                bool moneyInATMlessthanitemscost;
                double remainingMoney=0;
                using (MySqlConnection sqlconn = new MySqlConnection(ConnectionString))
                {
                    double itemsCost = Convert.ToDouble(money.Substring(2));
                    double moneyInATM = Convert.ToDouble(moneyinATM);
                    
                    if(moneyInATM<itemsCost)
                    {
                        moneyInATMlessthanitemscost = true;
                    }
                    else
                    {
                        moneyInATMlessthanitemscost = false;
                    }
                    if (!moneyInATMlessthanitemscost)
                    {
                        remainingMoney = moneyInATM-itemsCost;
                        sqlconn.Open();
                        var stm = "UPDATE dummycard SET AMOUNT=" + remainingMoney + " WHERE CARDID=" + id;
                        var cmd = new MySqlCommand(stm, sqlconn);
                        cmd.ExecuteScalar();
                        sqlconn.Close();

                    }
                    

                }
                if(moneyInATMlessthanitemscost)
                {
                    if (StandardPopup1.IsOpen) { StandardPopup1.IsOpen = false; }
                    if (!StandardPopup4.IsOpen) { StandardPopup4.IsOpen = true; }
                }
                else
                {
                    if (StandardPopup1.IsOpen) { StandardPopup1.IsOpen = false; }
                    if (!StandardPopup2.IsOpen) {
                        balanceamount.Text = "THE BALANCE IN CARD IS "+ remainingMoney;
                        StandardPopup2.IsOpen = true; }
                }
                

            }


            // Frame.Navigate(typeof(Views.BlankPage1), this.ViewModel.TotalCostString);
            //
            //
            //
            //this.ViewModel.OnWindowsCheckoutClicked();
        }
      
        private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {

        }
    }
}
