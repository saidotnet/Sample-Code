using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using AgilityCIS.Orion.Services.AgilitySvcProxy;
using Microsoft.Practices.Prism.Commands;

namespace AgilityCIS.Orion.Common
{
    public partial class HeaderPageUC : UserControl
    {
		#region Constructors (1) 

        public HeaderPageUC()
        {
            // Required to initialize variables
            InitializeComponent();
            this.drpCustomerName.SelectionChanged += new SelectionChangedEventHandler(drpCustomerName_SelectionChanged);
            this.txtCustNo.TextChanged += new TextChangedEventHandler(txtCustNo_TextChanged);
            //this.btnFirst.Click += new RoutedEventHandler(btnFirst_Click);
            //this.btnLast.Click += new RoutedEventHandler(btnLast_Click);
            //this.btnPrevious.Click += new RoutedEventHandler(btnPrevious_Click);
            //this.btnNext.Click += new RoutedEventHandler(btnNext_Click);
        }

		#endregion Constructors 



        #region DP's

        #region CustomerNameCollection

        public ObservableCollection<Customer> CustomerNameCollection
        {
            get { return (ObservableCollection<Customer>)GetValue(CustomerNameCollectionProperty); }
            set { SetValue(CustomerNameCollectionProperty, value); }

        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomerNameCollectionProperty =
            DependencyProperty.Register("CustomerNameCollection", typeof(ObservableCollection<Customer>), typeof(HeaderPageUC), new PropertyMetadata(null, new PropertyChangedCallback(CustomerNameCollectionChanged)));


        private static void CustomerNameCollectionChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            HeaderPageUC me = sender as HeaderPageUC;
            if (me != null)
            {
                me.drpCustomerName.ItemsSource = (ObservableCollection<Customer>)e.NewValue;
            }
        }

        #endregion
        #region Selected Customer Name

        public Customer SelectedCustomerName
        {
            get { return (Customer)GetValue(SelectedCustomerNameProperty); }
            set { SetValue(SelectedCustomerNameProperty, value); }

        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedCustomerNameProperty =
            DependencyProperty.Register("SelectedCustomerName", typeof(Customer), typeof(HeaderPageUC), new PropertyMetadata(null, new PropertyChangedCallback(SelectedCustomerNameChanged)));


        private static void SelectedCustomerNameChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            HeaderPageUC me = sender as HeaderPageUC;
            if (me != null)
            {
                me.drpCustomerName.SelectedItem = (Customer)e.NewValue;
            }
        }

        #endregion
        #region Customer Number

        public string CustomerNumber
        {
            get { return (string)GetValue(CustomerNumberProperty); }
            set { SetValue(CustomerNumberProperty, value); }

        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomerNumberProperty =
            DependencyProperty.Register("CustomerNumber", typeof(string), typeof(HeaderPageUC), new PropertyMetadata(null, new PropertyChangedCallback(CustomerNumberChanged)));


        private static void CustomerNumberChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            HeaderPageUC me = sender as HeaderPageUC;
            if (me != null && e.NewValue != null)
            {
                me.txtCustNo.Text = (string)e.NewValue;
            }
        }

        #endregion
        #endregion

        #region Event Handlers

        private void drpCustomerName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Customer)drpCustomerName.SelectedItem != null)
            {
                SelectedCustomerName = drpCustomerName.SelectedItem as Customer;
            }
        }

        private void txtCustNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtCustNo.Text != string.Empty)
            {
                CustomerNumber = (string)txtCustNo.Text;
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            int currentIndex = GetIndex() + 1;
            if (currentIndex < CustomerNameCollection.Count)
            {
                if (CustomerNameCollection != null && CustomerNameCollection.Count > currentIndex)
                {
                    if (currentIndex <= CustomerNameCollection.Count - 1)
                    {
                        SelectedCustomerName = CustomerNameCollection[currentIndex];
                    }
                }
            }
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            int currentIndex = GetIndex() - 1;
            if (currentIndex < CustomerNameCollection.Count)
            {
                if (CustomerNameCollection != null && CustomerNameCollection.Count > currentIndex)
                {
                    if (currentIndex >= 0 && currentIndex <= CustomerNameCollection.Count - 1)
                    {
                        SelectedCustomerName = CustomerNameCollection[currentIndex];
                    }
                }
            }
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerNameCollection != null && CustomerNameCollection.Count > 0)
            {
                SelectedCustomerName = CustomerNameCollection[CustomerNameCollection.Count - 1];
            }
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerNameCollection != null && CustomerNameCollection.Count > 0)
            {
                SelectedCustomerName = CustomerNameCollection[0];
            }
        }

        private int GetIndex()
        {
            int index = 0;
            if (CustomerNameCollection != null && CustomerNameCollection.Count > 0)
            {
                for (int i = 0; i < CustomerNameCollection.Count; i++)
                {
                    if (CustomerNameCollection[i].CustomerNo == SelectedCustomerName.CustomerNo)
                    {
                        index = i;
                        break;
                    }
                }
            }
            return index;

        }
        #endregion

        #region Commands

        #region Search Command
        public object SearchCommand
        {
            get { return (DelegateCommand<object>)GetValue(SearchCommandProperty); }
            set { SetValue(SearchCommandProperty, value); }

        }

        public static readonly DependencyProperty SearchCommandProperty =
            DependencyProperty.Register("SearchCommand", typeof(DelegateCommand<object>), typeof(HeaderPageUC),
                new PropertyMetadata(null, OnSearchCommandParameterChanged));

        private static void OnSearchCommandParameterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HeaderPageUC sc = (HeaderPageUC)d;
            sc.btnsearch.Command = (DelegateCommand<object>)e.NewValue;
        }



        public object DeleteCommand
        {
            get { return (object)GetValue(DeleteCommandProperty); }
            set { SetValue(DeleteCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeleteCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeleteCommandProperty =
            DependencyProperty.Register("DeleteCommand", typeof(DelegateCommand<object>), typeof(HeaderPageUC),
                new PropertyMetadata(null, OnDeleteCommandParameterChanged));

        private static void OnDeleteCommandParameterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HeaderPageUC sc = (HeaderPageUC)d;
            sc.btnDelete.Command = (DelegateCommand<object>)e.NewValue;
        }

        #endregion
        #region Save Command

        public object SaveCommand
        {
            get { return (DelegateCommand<object>)GetValue(SaveCommandProperty); }
            set { SetValue(SaveCommandProperty, value); }

        }

        public static readonly DependencyProperty SaveCommandProperty =
            DependencyProperty.Register("SaveCommand", typeof(DelegateCommand<object>), typeof(HeaderPageUC),
                new PropertyMetadata(null, OnSaveCommandParameterChanged));

        private static void OnSaveCommandParameterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HeaderPageUC sc = (HeaderPageUC)d;
            sc.btnSave.Command = (DelegateCommand<object>)e.NewValue;
        }
        #endregion
        #region Next Command

        public object NextCommand
        {
            get { return (DelegateCommand<object>)GetValue(NextCommandProperty); }
            set { SetValue(NextCommandProperty, value); }

        }

        public static readonly DependencyProperty NextCommandProperty =
            DependencyProperty.Register("NextCommand", typeof(DelegateCommand<object>), typeof(HeaderPageUC),
                new PropertyMetadata(null, OnNextCommandParameterChanged));

        private static void OnNextCommandParameterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HeaderPageUC sc = (HeaderPageUC)d;
            sc.btnNext.Command = (DelegateCommand<object>)e.NewValue;
        }
        #endregion
        #region Previous Command

        public object PreviousCommand
        {
            get { return (DelegateCommand<object>)GetValue(PreviousCommandProperty); }
            set { SetValue(PreviousCommandProperty, value); }

        }

        public static readonly DependencyProperty PreviousCommandProperty =
            DependencyProperty.Register("PreviousCommand", typeof(DelegateCommand<object>), typeof(HeaderPageUC),
                new PropertyMetadata(null, OnPreviousCommandParameterChanged));

        private static void OnPreviousCommandParameterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HeaderPageUC sc = (HeaderPageUC)d;
            sc.btnPrevious.Command = (DelegateCommand<object>)e.NewValue;
        }

        #endregion
        #region First Command

        public object FirstCommand
        {
            get { return (DelegateCommand<object>)GetValue(FirstCommandProperty); }
            set { SetValue(FirstCommandProperty, value); }

        }

        public static readonly DependencyProperty FirstCommandProperty =
            DependencyProperty.Register("FirstCommand", typeof(DelegateCommand<object>), typeof(HeaderPageUC),
                new PropertyMetadata(null, OnFirstCommandParameterChanged));

        private static void OnFirstCommandParameterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HeaderPageUC sc = (HeaderPageUC)d;
            sc.btnFirst.Command = (DelegateCommand<object>)e.NewValue;
        }

        #endregion
        #region Last Command

        public object LastCommand
        {
            get { return (DelegateCommand<object>)GetValue(LastCommandProperty); }
            set { SetValue(LastCommandProperty, value); }

        }

        public static readonly DependencyProperty LastCommandProperty =
            DependencyProperty.Register("LastCommand", typeof(DelegateCommand<object>), typeof(HeaderPageUC),
                new PropertyMetadata(null, OnLastCommandPropertyChanged));

        private static void OnLastCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HeaderPageUC sc = (HeaderPageUC)d;
            sc.btnLast.Command = (DelegateCommand<object>)e.NewValue;
        }

        #endregion
        #endregion
    }
}