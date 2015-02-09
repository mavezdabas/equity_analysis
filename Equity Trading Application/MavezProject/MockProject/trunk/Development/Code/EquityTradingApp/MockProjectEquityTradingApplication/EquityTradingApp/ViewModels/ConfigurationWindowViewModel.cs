using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Collections.ObjectModel;
using AutoMapper;
using System.Windows.Input;
using EquityTradingApp.Command;
using EquityTradingApp.Helpers;
using DataAccessLayer.DAL.ExecutionBrokerDAL;

namespace EquityTradingApp.ViewModels
{
    class ConfigurationWindowViewModel : BaseViewModel
    {
        private ISecurityConfigurationDAL dalObj;
        public ObservableCollection<Security> securities { get; set; }
        public Security security { get; set; }
        public event RequestCloseEventHandler RequestCloseDialog;
        


        private Security config;
        public Security Config
        {
            get { return config; }
            set
            {
                config = value;
                if (config.SecurityConfigurationDetails != null)
                {
                    SecurityConfig = new ObservableCollection<SecurityConfigurationDetail>() { config.SecurityConfigurationDetails.FirstOrDefault() };
                }
                else
                {
                    SecurityConfig = new ObservableCollection<SecurityConfigurationDetail>();
                    //SecurityConfigurationDetail configurationObject = new SecurityConfigurationDetail();
                }
            }
        }

        private ObservableCollection<SecurityConfigurationDetail> securityConfig;

        public ObservableCollection<SecurityConfigurationDetail> SecurityConfig
        {
            get { return securityConfig; }
            set
            {
                securityConfig = value;
                RaisePropertyChanged("SecurityConfig");
            }
        }



        public ConfigurationWindowViewModel()
        {
            //Mapper.CreateMap<Security, Security>();
            dalObj = new SecurityConfigurationDAL();
            securities = new ObservableCollection<Security>();
            LoadCollection();
            //dalObj.LoadConfigurationDetails();
        }

        public void LoadCollection()
        {
            if (securities != null)
                securities.Clear();
            (dalObj.GetSecurities()).ForEach(security => securities.Add(security));
        }

        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                    saveCommand = new RelayCommand(p => DoSave());
                return saveCommand;
            }
        }

        private void DoSave()
        {
            if (config.SecurityConfigurationDetails != null)
                dalObj.UpdateSecurityConfig(config.SecurityConfigurationDetails.FirstOrDefault());
            else
            {
                //SecurityConfigurationDetail configurationObject = new SecurityConfigurationDetail();
                var securityConfig = SecurityConfig.FirstOrDefault();
                securityConfig.SecurityID = config.SecurityID;
                dalObj.AddSecurityConfig(SecurityConfig.FirstOrDefault());
            }
            if (RequestCloseDialog != null)
                RequestCloseDialog(new RequestCloseEventArgs(true));
        }

        private ICommand cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                if (cancelCommand == null)
                    cancelCommand = new RelayCommand(p => DoCancel());
                return cancelCommand;
            }
        }

        private void DoCancel()
        {
            if (RequestCloseDialog != null)
                RequestCloseDialog(new RequestCloseEventArgs(false));
        }
    }
}

