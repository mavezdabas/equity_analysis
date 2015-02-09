using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using EquityTradingApp.Command;
using EquityTradingApp.Helpers;
using System.Windows;
using EquityTradingApp.ViewModels;
using DataAccessLayer;
using DataAccessLayer.DAL.ExecutionBrokerDAL;
using System.Windows.Controls;
using log4net;
using log4net.Config;

//[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace EquityTradingApp.ViewModels
{
    
    public class LoginWindowViewModel : BaseViewModel
    {
        

        
        private IModalDialogService dialogService;
        private ILoginCredentials logincred;

        public event RequestCloseEventHandler RequestCloseDialog;

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

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged("Password");
            }
        }

        private string error;

        public string Error
        {
            get { return error; }
            set
            {
                error = value;
                RaisePropertyChanged("Error");
            }
        }


        //User userToCheck;

        public LoginWindowViewModel()
        {
            dialogService = new ModalDialogService();
            
            //userToCheck = new User();
        }

        #region ForgotPasswordWindowOpen

        private ICommand openInsertWindowCmd;
        public ICommand OpenInsertWindowCommand
        {
            get
            {
                if (openInsertWindowCmd == null)
                    openInsertWindowCmd = new RelayCommand(p => OpenForgotPasswordWindow());
                return openInsertWindowCmd;
            }
        }

        private void OpenForgotPasswordWindow()
        {
            dialogService.ShowDialog<PasswordResetWindowViewModel>
                (ViewTypes.PasswordWindow, null, () => LoadEmployees());
        }

        private void LoadEmployees()
        {
            //MessageBox.Show("Window Opened");
        }

        #endregion

        #region BrokerMainPageOpen

        private ICommand loginButtonCommand;
        //object parameter ;//= new object();
        public ICommand LoginButtonCommand
        {
            get
            {
                if (loginButtonCommand == null)
                    loginButtonCommand = new RelayCommand(p => OpenBrokerPage(p));
                return loginButtonCommand;
            }
        }


        private void OpenBrokerPage(object p)
        {
            //userToCheck = new User();
            logincred = new LoginCredentials();
            var pBox = p as PasswordBox;
            if (pBox != null)
            {
                Password = pBox.Password;
            }
            else
            {
                Error = "Please Enter Password";
            }
            var password = logincred.ReturnPassword(UserName);
            try
            {

                if ((password) != null && (password == Password))
                {
                    BrokerMainPageViewModel brokerViewModel = new BrokerMainPageViewModel();
                    dialogService.ShowDialog<BrokerMainPageViewModel>(ViewTypes.BrokerPage, brokerViewModel, () => LoadEmployees());
                    
                }
                else
                {
                    if (UserName == null || Password == null)
                    {
                        Error = "Please Enter Valid Details";
                    }
                    else if (UserName != null && Password == null || UserName == null && Password != null)
                    {
                        Error = "Please Enter Valid Details";
                    }

                    else
                    {
                        Error = "Incorrect Username or Password";
                    }
                }
            }
            catch (Exception e)
            {
                log4net.Config.XmlConfigurator.Configure();

                log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                log.Debug(e.Message);
                dialogService.ShowMessage("Enter Valid User Name");
            }

        }

        #endregion

        #region CancelButton

        private ICommand cancelButtonClickCommand;

        public ICommand CancelButtonClickCommand
        {
            get
            {
                if (cancelButtonClickCommand == null)
                    cancelButtonClickCommand = new RelayCommand(p => DoCancel());
                return cancelButtonClickCommand;
            }

        }

        private void DoCancel()
        {
            if (RequestCloseDialog != null)
                RequestCloseDialog(new RequestCloseEventArgs(false));
        }

        #endregion
    }
 }

