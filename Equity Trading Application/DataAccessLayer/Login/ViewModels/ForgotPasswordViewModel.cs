using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortfolioManagerWindow.Helpers;
using System.Windows.Input;
using EquityTradingApplication.Commands;
using DataAccessLayer;
using Login.Helpers;

namespace Login.ViewModels
{
  public class ForgotPasswordViewModel:ViewModelBase
    {
      private PortfolioDAL dalObject;

      public ForgotPasswordViewModel()
      {
          dalObject = new PortfolioDAL();
          UserName = " Username";
          NewPassword = "New Password";
          Key = "Key";

      }

        private string username;
        public string UserName
        {
            get { return username; }
            set { username = value;
            RaisePropertyChanged("UserName");
            }
        }

        private string newPassword;
        public string NewPassword
        {
            get { return newPassword; }
            set { newPassword = value;
            RaisePropertyChanged("NewPassword");
            }
        }

        private string key;
        public string Key
        {
            get { return key; }
            set { key = value;
            RaisePropertyChanged("Key");
            }
        }

        private ICommand resetCommand;

        public ICommand ResetCommand
        {
            get {
                if (resetCommand == null)
                    resetCommand = new RelayCommand(p=>Reset());
                return resetCommand; }
        }

        private void Reset()
        {
            string keyFromDAL = dalObject.GetKeyFromUserName(UserName);
            if (keyFromDAL != Key)
                HandleExceptions.ShowMessage("WrongKey");

            else
            {
                User user = dalObject.GetUserFromUserName(UserName);
                user.Password = NewPassword;
                dalObject.UpdateUser(user);
            
            }
                
        }

    }
}
