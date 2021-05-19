//  ---------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// 
//  The MIT License (MIT)
// 
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
// 
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  ---------------------------------------------------------------------------------

using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using Windows.UI.Xaml.Controls;


namespace YetAnotherShoppingApp
{
    public sealed partial class ShoppingCartPage : Page
    {
        
        const string ConnectionString = "server = localhost; user id = root; database=payrolldb;Password=albertbolt23;";
        internal ShoppingCartPageViewModel ViewModel { private set; get; }

        public ShoppingCartPage()
        {
            this.InitializeComponent();
            this.ViewModel = new ShoppingCartPageViewModel();

            this.Loaded += OnLoaded;
            this.Unloaded += OnUnloaded;
        }

        private void OnLoaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.ViewModel.OnLoaded();
        }

        private void OnUnloaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.ViewModel.OnUnloaded();
        }

        private void OnRemoveClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var button = (HyperlinkButton)sender;
            var entryViewModel = (ShoppingCartEntryViewModel)button.Tag;

            this.ViewModel.OnEntryRemoveClick(entryViewModel);
        }

        /*
        private void ClosePopupClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // if the Popup is open, then close it 
            if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
        }
        */
        private void OnWindowsCheckoutClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
          
            //using(MySqlConnection sqlconn = new MySqlConnection(ConnectionString))
            //{
             //   sqlconn.Open();
               // someone.Text = sqlconn.State.ToString();
            //}
         
            //if (!StandardPopup.IsOpen) { StandardPopup.IsOpen = true; }
            Frame.Navigate(typeof(Views.BlankPage1), this.ViewModel.TotalCostString);
            //
            //
            //
            //this.ViewModel.OnWindowsCheckoutClicked();
        }
        /*
        private void OnSubmitClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

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
        private void OnSubmitClicked1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

    
            if (StandardPopup1.IsOpen) { StandardPopup1.IsOpen = false; }
            if (!StandardPopup2.IsOpen) { StandardPopup2.IsOpen = true; }

            // Frame.Navigate(typeof(Views.BlankPage1), this.ViewModel.TotalCostString);
            //
            //
            //
            //this.ViewModel.OnWindowsCheckoutClicked();
        }
        */
        private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {

        }

  



    }
}
