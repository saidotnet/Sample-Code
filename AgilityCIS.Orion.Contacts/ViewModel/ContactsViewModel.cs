﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Commands;
using AgilityCIS.Orion.Services.AgilitySvcProxy;
using System.Collections.ObjectModel;
using AgilityCIS.Orion.Common;
using Microsoft.Practices.Prism.Events;
using System.Linq;
using AgilityCIS.Orion.LocalizationManager;
using AgilityCIS.Orion.Common.Enums;
using Microsoft.Practices.Prism.Modularity;
using System.Collections.Generic;

namespace AgilityCIS.Orion.Contacts.ViewModel
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ContactsViewModel : BaseViewModel, INavigationAware
    {
        #region Fields (1)

        private readonly IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;
        [Import(AllowRecomposition = false)]
        public IModuleManager _moduleManager;
        private string _selectedCustomerId;
        private string _seqPartyId;
        private Contact _selectedContactdetails;
        #endregion Fields

        #region Properties(1)

        private ObservableCollection<Contact> _contacts;

       

        

      public ObservableCollection<Contact> Contacts
        {
            get
            {
                return _contacts;
            }
            set
            {
                _contacts = value;
               RaisePropertyChanged("Contacts");
            }
        }
       

        #endregion Property

        #region Constructors (1)

        [ImportingConstructor]
        public ContactsViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this._regionManager = regionManager;
        }

        #endregion Constructors


        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _selectedCustomerId = StoreInstance.Instance.SelectedCustomerId;
            _seqPartyId = StoreInstance.Instance.SelectedPartyId;

            if (_seqPartyId != null)
            {
                LoadContacts();
            }
        }

        private void LoadContacts()
        {
            ServiceAgent.GetContacts(int.Parse(_seqPartyId), (s, e) =>
            {
                if (e.Error != null)
                {
                    HandleError(e.Error);

                 }
                else
                {
                    Contacts = e.Result;
                }


            });
        }
    }

}