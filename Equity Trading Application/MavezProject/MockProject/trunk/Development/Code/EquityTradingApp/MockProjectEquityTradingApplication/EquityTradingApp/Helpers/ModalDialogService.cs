using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EquityTradingApp.Views;
using LoginWindowForEquityTradingSystem.Views;
using System.Windows;

namespace EquityTradingApp.Helpers
{
    public interface IModalDialogService
    {
        void ShowDialog<TViewModel>(ViewTypes viewType, TViewModel viewModel,
            Action onDialogOKClose);
        void ShowDialog<TViewModel>(ViewTypes viewType, TViewModel viewModel,
            Action onDialogOKClose, Action onDialogCancelClose);

        void ShowMessage(string messageToDisplay);
    }

    public class ModalDialogService : IModalDialogService
    {
        public void ShowDialog<TViewModel>(ViewTypes viewType,
            TViewModel viewModel, Action onDialogOKClose)
        {
            IModalWindow view = null;

            switch (viewType)
            {
                case ViewTypes.ConfigurationWindow:
                    view = new ConfigurationWindow();
                    break;
                case ViewTypes.LoginWindow:
                    view = new LoginWindow();
                    break;
                case ViewTypes.PasswordWindow:
                    view = new PasswordResetWindow();
                    break;
                case ViewTypes.ResetPassword:
                    view = new ResetPassword();
                    break;
                case ViewTypes.BrokerPage:
                    view = new BrokerMainPageWindow();
                    break;
                default:
                    view = null;
                    break;
            }

            if (view != null)
            {
                if (viewModel != null)
                    view.DataContext = viewModel;
                if (onDialogOKClose != null)
                {
                    view.Closed += (s, e) => onDialogOKClose();
                }
                view.ShowDialog();
            }
        }

        public void ShowDialog<TViewModel>(ViewTypes viewType,
            TViewModel viewModel, Action onDialogOKClose, Action onDialogCancelClose)
        {
            IModalWindow view = null;

            switch (viewType)
            {
                case ViewTypes.ConfigurationWindow:
                    view = new ConfigurationWindow();
                    break;
                case ViewTypes.LoginWindow:
                    view = new LoginWindow();
                    break;
                case ViewTypes.PasswordWindow:
                    view = new PasswordResetWindow();
                    break;
                case ViewTypes.ResetPassword:
                    view = new ResetPassword();
                    break;
                case ViewTypes.BrokerPage:
                    view = new BrokerMainPageWindow();
                    break;
                default:
                    view = null;
                    break;
            }

            if (view != null)
            {
                if (viewModel != null)
                    view.DataContext = viewModel;
                if (onDialogOKClose != null)
                {
                    view.Closed += (s, e) => onDialogOKClose();
                }
                if (onDialogCancelClose != null)
                {
                    view.Closed += (s, e) => onDialogCancelClose();
                }
                view.ShowDialog();
            }
        }


        public void ShowMessage(string messageToDisplay)
        {
            MessageBox.Show(messageToDisplay);
        }
    }
}
