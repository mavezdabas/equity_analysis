using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using EquityTradingApp.Command;
using EquityTradingApp.Helpers;
using DataAccessLayer.DAL.ExecutionBrokerDAL;
using System.ComponentModel;
using DataAccessLayer;

namespace EquityTradingApp.ViewModels
{
    class ResetPasswordViewModel : IEquityModelHelper
    {
        public event RequestCloseEventHandler RequestCloseDialog;

        public IModalDialogService resetPasswordDialogService;
        ILoginCredentials dalObject;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
        }

        private string resetPassowrd;

        public string ResetPassword
        {
            get { return resetPassowrd; }
            set
            {
                resetPassowrd = value;
                RaisePropertyChanged("ResetPassword");
            }
        }

        private string confirmPassword;

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                RaisePropertyChanged("ConfirmPassword");
            }
        }

        public User userDetailsToReset;

        public ResetPasswordViewModel(User userDetailsReset)
        {
            resetPasswordDialogService = new ModalDialogService();
            userDetailsToReset = userDetailsReset;
        }

        private ICommand okCommand;

        public ICommand OkCommand
        {
            get
            {
                if (okCommand == null)
                    okCommand = new RelayCommand(p => OKClicked());
                return okCommand;
            }
        }

        private void OKClicked()
        {
            if (ConfirmPassword == ResetPassword)
            {
                dalObject = new LoginCredentials();
                userDetailsToReset.Password = ConfirmPassword;
                dalObject.UpdateBrokerPassword(userDetailsToReset);
                //resetPasswordDialogService.ShowDialog<ResetPasswordViewModel>(ViewTypes.ResetPassword, null, () => OnWindowLoad());

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
                    cancelCommand = new RelayCommand(p => DoCancelClose());
                return cancelCommand;
            }
        }

        private void DoCancelClose()
        {
            if (RequestCloseDialog != null)
                RequestCloseDialog(new RequestCloseEventArgs(false));
        }

    }
}

