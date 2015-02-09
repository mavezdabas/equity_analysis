using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExecutionTraderMainWindow.Views;

namespace ExecutionTraderMainWindow.Helpers
{
    public interface IModalDialogService
    {
        void ShowDialog<TViewModel>(ViewType viewType, TViewModel viewModel,
            Action onDialogOKClose);
        void ShowDialog<TViewModel>(ViewType viewType, TViewModel viewModel,
            Action onDialogOKClose, Action onDialogCancelClose);
    }

    public class ModalDialogService : IModalDialogService
    {
        public void ShowDialog<TViewModel>(ViewType viewType,
            TViewModel viewModel, Action onDialogOKClose)
        {
            IModalWindow view = null;

            switch (viewType)
            {
                case ViewType.EditBlockView:
                    view = new EditBlockView();
                    break;
               
                case ViewType.CreateBlockView:
                    view = new CreateBlockWindow();
                    break;
                
                case ViewType.AddToBlockView:
                    view = new AddOrdersToBlockWindow();
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

        public void ShowDialog<TViewModel>(ViewType viewType,
            TViewModel viewModel, Action onDialogOKClose, Action onDialogCancelClose)
        {
            IModalWindow view = null;

            switch (viewType)
            {
                case ViewType.EditBlockView:
                    view = new EditBlockView();
                    break;
                case ViewType.CreateBlockView:
                    view = new CreateBlockWindow();
                    break;
                case ViewType.AddToBlockView:
                    view = new AddOrdersToBlockWindow();
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
    }
}
