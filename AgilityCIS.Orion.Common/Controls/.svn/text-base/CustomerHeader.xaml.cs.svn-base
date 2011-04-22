using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace AgilityCIS.Orion.Common.Controls
{
    public partial class CustomerHeader : UserControl
    {
		#region Constructors (1) 

        public CustomerHeader()
        {
            InitializeComponent();
        }

		#endregion Constructors 



        #region Decisions
           
        public string DecisionsText
        {
            get { return (string)GetValue(DecisionsTextProperty); }
            set  { SetValue(DecisionsTextProperty, value); }

        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DecisionsTextProperty =
            DependencyProperty.Register("DecisionsText", typeof(string), typeof(CustomerHeader), new PropertyMetadata(null, new PropertyChangedCallback(DecisionsTextChanged)));


        private static void DecisionsTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            CustomerHeader me = sender as CustomerHeader;
            if (me != null)
            {
              me.txtDecisions.Text = (string)e.NewValue;
            }
        }

        #endregion

        #region Billing

        public string BillingText
        {
            get { return (string)GetValue(BillingTextProperty); }
            set { SetValue(BillingTextProperty, value); }

        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BillingTextProperty =
            DependencyProperty.Register("BillingText", typeof(string), typeof(CustomerHeader), new PropertyMetadata(null, new PropertyChangedCallback(BillingTextChanged)));


        private static void BillingTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            CustomerHeader me = sender as CustomerHeader;
            if (me != null)
            {
                me.txtBilling.Text = (string)e.NewValue;
            }
        }

        #endregion

        #region Account Manager Name

        public string AcctManagerText
        {
            get { return (string)GetValue(AcctManagerTextProperty); }
            set { SetValue(AcctManagerTextProperty, value); }

        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AcctManagerTextProperty =
            DependencyProperty.Register("AcctManagerText", typeof(string), typeof(CustomerHeader), new PropertyMetadata(null, new PropertyChangedCallback(AcctManagerTextChanged)));


        private static void AcctManagerTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            CustomerHeader me = sender as CustomerHeader;
            if (me != null)
            {
                me.txtAccountManagerName.Text = (string)e.NewValue;
            }
        }

        #endregion

        #region Distric Code

        public string DistricCodeText
        {
            get { return (string)GetValue(DistricCodeTextProperty); }
            set { SetValue(DistricCodeTextProperty, value); }

        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DistricCodeTextProperty =
            DependencyProperty.Register("DistricCodeText", typeof(string), typeof(CustomerHeader), new PropertyMetadata(null, new PropertyChangedCallback(DistricCodeTextChanged)));


        private static void DistricCodeTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            CustomerHeader me = sender as CustomerHeader;
            if (me != null)
            {
                me.txtDistricCode.Text = (string)e.NewValue;
            }
        }

        #endregion

        #region Phone

        public string PhoneText
        {
            get { return (string)GetValue(PhoneTextProperty); }
            set { SetValue(PhoneTextProperty, value); }

        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PhoneTextProperty =
            DependencyProperty.Register("PhoneText", typeof(string), typeof(CustomerHeader), new PropertyMetadata(null, new PropertyChangedCallback(PhoneTextChanged)));


        private static void PhoneTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            CustomerHeader me = sender as CustomerHeader;
            if (me != null)
            {
                me.txtPhone.Text = (string)e.NewValue;
            }
        }

        #endregion

        #region Fax

        public string FaxText
        {
            get { return (string)GetValue(FaxTextProperty); }
            set { SetValue(FaxTextProperty, value); }

        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FaxTextProperty =
            DependencyProperty.Register("FaxText", typeof(string), typeof(CustomerHeader), new PropertyMetadata(null, new PropertyChangedCallback(FaxTextChanged)));


        private static void FaxTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            CustomerHeader me = sender as CustomerHeader;
            if (me != null)
            {
                me.txtFax.Text = (string)e.NewValue;
            }
        }

        #endregion

        #region Credit Status Code

        public string CreditStatustext
        {
            get { return (string)GetValue(CreditStatustextProperty); }
            set { SetValue(CreditStatustextProperty, value); }

        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreditStatustextProperty =
            DependencyProperty.Register("CreditStatustext", typeof(string), typeof(CustomerHeader), new PropertyMetadata(null, new PropertyChangedCallback(CreditStatustextChanged)));


        private static void CreditStatustextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            CustomerHeader me = sender as CustomerHeader;
            if (me != null)
            {
                me.txtCreditStatusCode.Text = (string)e.NewValue;
            }
        }

        #endregion

        #region Total Balance

        public string TotalBalanceText
        {
            get { return (string)GetValue(TotalBalanceTextProperty); }
            set { SetValue(TotalBalanceTextProperty, value); }

        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TotalBalanceTextProperty =
            DependencyProperty.Register("TotalBalanceText", typeof(string), typeof(CustomerHeader), new PropertyMetadata(null, new PropertyChangedCallback(TotalBalanceTextChanged)));


        private static void TotalBalanceTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            CustomerHeader me = sender as CustomerHeader;
            if (me != null)
            {
                me.txtTotalBalance.Text = (string)e.NewValue;
            }
        }

        #endregion

        #region OverDue

        public string OverDueText
        {
            get { return (string)GetValue(OverDueTextProperty); }
            set { SetValue(OverDueTextProperty, value); }

        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OverDueTextProperty =
            DependencyProperty.Register("OverDueText", typeof(string), typeof(CustomerHeader), new PropertyMetadata(null, new PropertyChangedCallback(OverDueTextChanged)));


        private static void OverDueTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            CustomerHeader me = sender as CustomerHeader;
            if (me != null)
            {
                me.txtOverdue.Text = (string)e.NewValue;
            }
        }

        #endregion

        #region Current

        public string CurrentText
        {
            get { return (string)GetValue(CurrentTextProperty); }
            set { SetValue(CurrentTextProperty, value); }

        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentTextProperty =
            DependencyProperty.Register("CurrentText", typeof(string), typeof(CustomerHeader), new PropertyMetadata(null, new PropertyChangedCallback(CurrentTextChanged)));


        private static void CurrentTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            CustomerHeader me = sender as CustomerHeader;
            if (me != null)
            {
                me.txtCurrent.Text = (string)e.NewValue;
            }
        }

        #endregion

        #region Street Address 1

        public string StreetAddr1Text
        {
            get { return (string)GetValue(StreetAddr1TextProperty); }
            set { SetValue(StreetAddr1TextProperty, value); }

        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StreetAddr1TextProperty =
            DependencyProperty.Register("StreetAddr1Text", typeof(string), typeof(CustomerHeader), new PropertyMetadata(null, new PropertyChangedCallback(StreetAddr1TextChanged)));


        private static void StreetAddr1TextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            CustomerHeader me = sender as CustomerHeader;
            if (me != null)
            {
                me.txtStreetAddr1.Text = (string)e.NewValue;
            }
        }

        #endregion

        #region Street Address 2

        public string StreetAddr2Text
        {
            get { return (string)GetValue(StreetAddr2TextProperty); }
            set { SetValue(StreetAddr2TextProperty, value); }

        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StreetAddr2TextProperty =
            DependencyProperty.Register("StreetAddr2Text", typeof(string), typeof(CustomerHeader), new PropertyMetadata(null, new PropertyChangedCallback(StreetAddr2TextChanged)));


        private static void StreetAddr2TextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            CustomerHeader me = sender as CustomerHeader;
            if (me != null)
            {
                me.txtStreetAddr2.Text = (string)e.NewValue;
            }
        }

        #endregion

        #region Street Address 3

        public string StreetAddr3Text
        {
            get { return (string)GetValue(StreetAddr3TextProperty); }
            set { SetValue(StreetAddr3TextProperty, value); }

        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StreetAddr3TextProperty =
            DependencyProperty.Register("StreetAddr3Text", typeof(string), typeof(CustomerHeader), new PropertyMetadata(null, new PropertyChangedCallback(StreetAddr3TextChanged)));


        private static void StreetAddr3TextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            CustomerHeader me = sender as CustomerHeader;
            if (me != null)
            {
                me.txtStreetAddr3.Text = (string)e.NewValue;
            }
        }

        #endregion

        #region Postal Address 1

        public string PostalAddressText
        {
            get { return (string)GetValue(PostalAddress1TextProperty); }
            set { SetValue(PostalAddress1TextProperty, value); }

        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PostalAddress1TextProperty =
            DependencyProperty.Register("PostalAddressText", typeof(string), typeof(CustomerHeader), new PropertyMetadata(null, new PropertyChangedCallback(PostalAddress1TextChanged)));


        private static void PostalAddress1TextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            CustomerHeader me = sender as CustomerHeader;
            if (me != null)
            {
                me.txtPostalAddr1.Text = (string)e.NewValue;
            }
        }

        #endregion

        #region Postal Address 2

        public string PostalAddress2Text
        {
            get { return (string)GetValue(PostalAddress2TextProperty); }
            set { SetValue(PostalAddress2TextProperty, value); }

        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PostalAddress2TextProperty =
            DependencyProperty.Register("PostalAddress2Text", typeof(string), typeof(CustomerHeader), new PropertyMetadata(null, new PropertyChangedCallback(PostalAddress2TextChanged)));


        private static void PostalAddress2TextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            CustomerHeader me = sender as CustomerHeader;
            if (me != null)
            {
                me.txtPostalAddr2.Text = (string)e.NewValue;
            }
        }

        #endregion

        #region Postal Address 3

        public string PostalAddress3Text
        {
            get { return (string)GetValue(PostalAddress3TextProperty); }
            set { SetValue(PostalAddress3TextProperty, value); }

        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PostalAddress3TextProperty =
            DependencyProperty.Register("PostalAddress3Text", typeof(string), typeof(CustomerHeader), new PropertyMetadata(null, new PropertyChangedCallback(PostalAddress3TextChanged)));


        private static void PostalAddress3TextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            CustomerHeader me = sender as CustomerHeader;
            if (me != null)
            {
                me.txtPostalAddr3.Text = (string)e.NewValue;
            }
        }

        #endregion
    }
}
