using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortfolioManagerWindow.Helpers;
using System.Windows.Input;
using EquityTradingApplication.Commands;
using System.Windows;
using DataAccessLayer;
using PortfolioManager;
using Login.Helpers;

namespace Login.ViewModels
{
   public class MainWindowViewModel:ViewModelBase
   {
       PortfolioDAL dalObject;
       IModelDialogService dialogService;
       public event Login.Helpers.CustomEventHelper.RequestCloseEventHandler RequestCloseDialog;

       public MainWindowViewModel()
       {
           dalObject = new PortfolioDAL();
           dialogService = new ModelDialogService();     
       }

       private string username;
       public string UserName
       {
           get { return username; }
           set { username = value;
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

       private ICommand forgotCommand;
       public ICommand ForgotCommand
       {
           get {
               if (forgotCommand == null)
                   forgotCommand = new RelayCommand(p=>Forgot());
               
               return forgotCommand; }

       }

       private ICommand loginCommand;
       public ICommand LoginCommand
       {
           get {
               if (loginCommand == null)
                   loginCommand = new RelayCommand(p => Login());
               return loginCommand;
           }
       }
       
       private void Login()
       {
           string PasswordFromDAL = dalObject.GetPasswordFromUserName(UserName);
           if (PasswordFromDAL != Password)
               HandleExceptions.ShowMessage("WrongPassword");
           else
           {
               if (dalObject.GetRoleIdFromPassword(Password) == 1)
               {
                   dialogService = new ModelDialogService();
                   dialogService.ShowDialog<PortfolioManager.ViewModels.MainWindowViewModel>(ViewType.ClientWindowView, null, null);

                   //if (RequestCloseDialog != null)
                   //    RequestCloseDialog(new Login.Helpers.CustomEventHelper.RequestCloseEventArgs(false));
               }
               else if (dalObject.GetRoleIdFromPassword(Password) == 2)
               {
                   dialogService.ShowDialog<Trader.ViewModels.MainWindowViewModel>(ViewType.TraderView, null, null);
               }
           }
       }

       private void Forgot()
       {
           dialogService.ShowDialog<ForgotPasswordViewModel>(ViewType.ForgotPassword,null,null);
       }

    }
}
