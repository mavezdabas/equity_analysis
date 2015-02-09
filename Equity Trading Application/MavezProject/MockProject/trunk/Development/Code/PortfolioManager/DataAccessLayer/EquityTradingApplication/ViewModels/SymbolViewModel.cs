using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using AutoMapper;
using System.Windows.Input;
using EquityTradingApplication.Commands;
using EquityTradingApplication.Helpers;

namespace EquityTradingApplication.ViewModels
{
    class SymbolViewModel:ViewModelBase
    {
        private ExceptionHandler ex;
        public event EquityTradingApplication.Helpers.SymbolSelectionEventHelper.SymbolSelectionEventHandler SymbolEventHandler;
        public event EquityTradingApplication.Helpers.CustomEventHelper.RequestCloseEventHandler RequestCloseDialog;
        public SymbolViewModel()
        {
           IPortfolioDAL portfolioDAL = new PortfolioDAL();
           Mapper.CreateMap<Security, SecurityModel>();
           securitySymbolList = new List<SecurityModel>();
           portfolioDAL.GetAllSecurities().ForEach(e => securitySymbolList.Add(Mapper.Map<Security, SecurityModel>(e)));
        }

        private ICommand selectCommand;
        public ICommand SelectCommand
        {
            get
            {
                if (selectCommand == null)
                    selectCommand = new RelayCommand(p => SelectSecurityModel());
                return selectCommand;
            }
        }

        private void SelectSecurityModel()
        {
            try
            {
                string symbolName = null;
                if (SecurityModel != null)
                {
                    symbolName = SecurityModel.SecuritySymbol;
                }
                if (SymbolEventHandler != null)
                    SymbolEventHandler(new EquityTradingApplication.Helpers.SymbolSelectionEventHelper.SymbolSelectionEventArgs(symbolName));

                if (RequestCloseDialog != null)
                    RequestCloseDialog(new EquityTradingApplication.Helpers.CustomEventHelper.RequestCloseEventArgs(false));
            }
            catch (Exception)
            {

                ex = new ExceptionHandler(codes.GenericException);
            }
        }


        private ICommand cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                if (cancelCommand == null)
                    cancelCommand = new RelayCommand(p => Cancel());
                return cancelCommand;
            }
        }

        private void Cancel()
        {
            try
            {
                if (RequestCloseDialog != null)
                    RequestCloseDialog(new EquityTradingApplication.Helpers.CustomEventHelper.RequestCloseEventArgs(false));
            }
            catch (Exception)
            {

                ex = new ExceptionHandler(codes.GenericException);
            }
        }

        private SecurityModel securityModel;
        public SecurityModel SecurityModel
        {
            get
            {
                return securityModel;
            }

            set
            {
                securityModel = value;
                RaisePropertyChanged("SecurityModel");
            }
        }
        private List<SecurityModel> securitySymbolList;
        public List<SecurityModel> SecuritySymbolList
        { 
            get
            {
                return securitySymbolList;
            }
            set
            {
                securitySymbolList = value;
                RaisePropertyChanged("SecuritySymbolList");
            }


        }
        }
    }

