using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EquityTradingApp.Helpers;
using System.Windows.Input;
using EquityTradingApp.Command;
using System.Windows;
using System.ComponentModel;
using DataAccessLayer;
using DataAccessLayer.DAL.ExecutionBrokerDAL;




namespace EquityTradingApp.ViewModels
{
    class PasswordResetWindowViewModel : IEquityModelHelper
    {

        public event RequestCloseEventHandler RequestCloseDialog;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                RaisePropertyChanged("UserName");
            }
        }


        private int userID;

        public int UserID
        {
            get { return userID; }
            set
            {
                userID = value;
                RaisePropertyChanged("UserID");
            }
        }

        private DateTime dateOfBirth;

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                dateOfBirth = value;
                RaisePropertyChanged("DateOfBirth");
            }
        }

        User userForResettingPassword;


        public IModalDialogService passwordResetDialogService;

        ILoginCredentials dalObject;

        public PasswordResetWindowViewModel()
        {
            passwordResetDialogService = new ModalDialogService();

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
            dalObject = new LoginCredentials();
            User brokerDetails = dalObject.CheckForPassword(UserName);

            userForResettingPassword = new User() { UserID = UserID, DOB = dateOfBirth, UserName = UserName };

            if (brokerDetails != null && brokerDetails.UserName == UserName && brokerDetails.UserID == UserID && brokerDetails.DOB == DateOfBirth)
            {
                userForResettingPassword.Name = brokerDetails.Name;
                userForResettingPassword.RoleID = brokerDetails.RoleID;
                ResetPasswordViewModel resetPasswordObject = new ResetPasswordViewModel(userForResettingPassword);

                passwordResetDialogService.ShowDialog<ResetPasswordViewModel>(ViewTypes.ResetPassword, resetPasswordObject, () => OnWindowLoad());

            }

            else
            {
                passwordResetDialogService.ShowMessage("Wrong information entered");
                
            }

            if (RequestCloseDialog != null)
                RequestCloseDialog(new RequestCloseEventArgs(true));
        }

        private void OnWindowLoad()
        {
            passwordResetDialogService.ShowMessage("Reset Password Window is opened");
        }

        //public ICommand SaveCommand
        //{
        //    get { throw new NotImplementedException(); }
        //}

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
    //class PasswordResetWindowViewModel : IEquityModelHelper
    //{

    //    public event RequestCloseEventHandler RequestCloseDialog;

    //    //public event PropertyChangedEventHandler PropertyChanged;

    //    //protected virtual void RaisePropertyChanged(string propertyName)
    //    //{
    //    //    if (PropertyChanged != null)
    //    //        PropertyChanged(this,
    //    //            new PropertyChangedEventArgs(propertyName));
    //    //}

    //    //private bool? dialogResult;

    //    //public bool? DialogResult
    //    //{
    //    //    get { return dialogResult; }
    //    //    private set 
    //    //    { 
    //    //        dialogResult = value;
    //    //        RaisePropertyChanged("DialogResult");
    //    //    }
    //    //}


    //    public IModalDialogService passwordResetDialogService;



    //    public PasswordResetWindowViewModel()
    //    {
    //        passwordResetDialogService = new ModalDialogService();

    //    }

    //    private ICommand okCommand;

    //    public ICommand OkCommand
    //    {
    //        get
    //        {
    //            if (okCommand == null)
    //                okCommand = new RelayCommand(p => OKClicked());
    //            return okCommand;
    //        }
    //    }

    //    private void OKClicked()
    //    {
    //        passwordResetDialogService.ShowDialog<ResetPasswordViewModel>(ViewTypes.ResetPassword, null, () => OnWindowLoad());
    //        if (RequestCloseDialog != null)
    //            RequestCloseDialog(new RequestCloseEventArgs(true));
    //    }

    //    private void OnWindowLoad()
    //    {
    //        MessageBox.Show("Reset Password Window is opened");
    //    }

    //    //public ICommand SaveCommand
    //    //{
    //    //    get { throw new NotImplementedException(); }
    //    //}

    //    private ICommand cancelCommand;
    //    public ICommand CancelCommand
    //    {
    //        get
    //        {
    //            if (cancelCommand == null)
    //                cancelCommand = new RelayCommand(p => DoCancelClose());
    //            return cancelCommand;
    //        }
    //    }

    //    private void DoCancelClose()
    //    {
    //        if (RequestCloseDialog != null)
    //            RequestCloseDialog(new RequestCloseEventArgs(false));
    //    }

    //}
}
