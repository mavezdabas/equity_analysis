using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortfolioManager.Views;



namespace PortfolioManagerWindow.Helpers
{
    public interface IModelDialogService
    {
        void ShowDialog<TViewModel>(ViewType viewType, TViewModel viewModel,
            Action onDialogOKClose);
        void ShowDialog<TViewModel>(ViewType viewType, TViewModel viewModel,
            Action onDialogOKClose, Action onDialogCancelClose);
    }

  public  class ModelDialogService:IModelDialogService
    {
        public void ShowDialog<TViewModel>(ViewType viewType, TViewModel viewModel, Action onDialogOKClose)
        {
            IModelWindow view = null;

            switch(viewType)
            {
                case ViewType.HomePageView:
                    {
                        break;
                    }
                case ViewType.CreateOrderView:
                    view = new CreateOrder();
                    break;

                case ViewType.UpdateOrderView:
                    view = new UpdateOrder();
                    break;
                case ViewType.DeleteOrderView:
                   // view = new DeleteOrder();
                    break;
                case ViewType.GraphView:
                  
                    break;
                case ViewType.AmendOpenOrderView:
                  
                    break;
                case ViewType.PortfolioView:
                  
                    break;
                case ViewType.ViewOrderView:
                 
                    break;

                default: 
                    view =null;
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



        public void ShowDialog<TViewModel>(ViewType viewType, TViewModel viewModel, Action onDialogOKClose, Action onDialogCancelClose)
        {
           IModelWindow view = null;
            switch(viewType)
            {
                //case ViewType.HomePageView:
                //    {
                //        view = new HomePageView();
                //        break;
                //    }
                //case ViewType.CreateOrderView:
                //    view =new CreateOrderView();
                //    break;

                //case ViewType.UpdateOrderView:
                //    view=new EditOrderView();
                //    break;
                //case ViewType.DeleteOrderView:
                //    view =new DeleteOrderView();
                //    break;
                //case ViewType.GraphView:
                //    view=new GraphView() ;
                //    break;
                //case ViewType.AmendOpenOrderView:
                //    view=new AmendOpenOrderView();
                //    break;
                default: 
                    view =null;
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



