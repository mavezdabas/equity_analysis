using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using EquityTradingApplication.Commands;
using DataAccessLayer;
using AutoMapper;
using EquityTradingApplication.Helpers;
using System.Windows.Controls;
using ExecutionTraderMainWindow.ViewModel;
using EquityTradingApplication.ApplicationHelper;
using System.Windows;

namespace EquityTradingApplication.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private ExceptionHandler ex;
        private UserModel user;
        private IUserDAL dalObject;
        IModelDialogService dialogService;
        public event Action RequestCloseDialog;
        private string message;
      //  LoginViewModel l=new LoginViewModel();
        

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                RaisePropertyChanged("Message");
            }
        }


        public LoginViewModel()
        {
            Mapper.CreateMap<User, UserModel>();
            Mapper.CreateMap<UserModel, User>();
            dalObject = new UserDAL();
           
            user = new UserModel();
           
            //UserName = "";


            dialogService = new ModelDialogService();

        }


        public string UserName
        {
            get { return user.UserName; }
            set
            {
                //if (string.IsNullOrEmpty(value))
                //    throw new Exception("Name is mandatory.");
                // if (value.Length < 3)
                // throw new Exception("Name is mandatory!");
                user.UserName = value;
               // ForgotBtnEnabled = true;
            }
        }

        public bool  ForgotBtnEnabled { get; set; }


        public string Password
        {
            get { return user.Password; }
            set
            {
                //if (string.IsNullOrEmpty(value))
                //throw new Exception("Password is mandatory.");
                user.Password = value;
            }
        }


        private ICommand loginCommand;

        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                    loginCommand = new RelayCommand(p => LoadUserType(p));
                return loginCommand;
            }

        }

        private void LoadUserType(object obj)
        {
            //  var pwd = obj as LoginViewModel;
            var pwd = obj as PasswordBox;
            Password = pwd.Password;

            try
            {

                if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
                {

                    UserModel userModel = Mapper.Map<User, UserModel>(dalObject.getUserByUser(Mapper.Map<UserModel, User>(user)));

                    if (userModel != null)
                    {
                    
                        string userRole = dalObject.GetRoleNameByRoleID(userModel.RoleID);
                        if (userRole == "PM")
                        {
                            ApplicationState.SetValue("currentUserId", userModel.UserID);   //Aakanksha adding here
                            if (RequestCloseDialog != null)
                            {
                                RequestCloseDialog();
                            }

                            dialogService.ShowDialog<HomePageViewModel>(ViewType.HomePageView, null, null);
                            Message = string.Empty;
                        }
                        else if (userRole == "ET")
                        {
                            ApplicationState.SetValue("currentUserId", userModel.UserID);   //Aakanksha adding here
                            if (RequestCloseDialog != null)
                            {
                                RequestCloseDialog();
                            }

                            dialogService.ShowDialog<MainWindowExecutionTraderViewModel>(ViewType.ETLoginView, null, null);
                            Message = string.Empty;

                        }

                    }

                    else
                    {
                        Message = "Invalid username or password!";
                    }

                }

                else
                {
                    Message = "Please enter username or password!";
                }
            }
            catch (Exception)
            {
                ex = new ExceptionHandler(codes.GenericException);
               
            }


        }



        private ICommand forgotPasswordCommand;

        public ICommand ForgotPasswordCommand
        {
            get
            {

                if (forgotPasswordCommand == null)
                    forgotPasswordCommand = new RelayCommand(p=> EnableForgot(),p => Forgot());
                return forgotPasswordCommand;
            }

        }

        private bool EnableForgot()
        {
            var users = dalObject.GetAllUsers();
            foreach (var item in users)
            {
                if (item.UserName == UserName)
                {
                    return true;
                }
            }
            if (string.IsNullOrEmpty(UserName))
                return false;

            return false;
        }


        private void Forgot()
        {
            ForgotPasswordViewModel forgotObj = new ForgotPasswordViewModel(UserName);
            dialogService.ShowDialog<ForgotPasswordViewModel>(ViewType.ForgotPasswordView, forgotObj, null);
        }




    }
}
