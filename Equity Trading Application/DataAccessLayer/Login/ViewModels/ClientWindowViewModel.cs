using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using EquityTradingApplication.Helpers;
using PortfolioManagerWindow.Helpers;
using System.Windows.Input;
using EquityTradingApplication.Commands;

namespace Login.ViewModels
{
    public class ClientWindowViewModel
    {

        PortfolioDAL dalObject;
        public List<ClientInfo> Brushes;
        IModelDialogService dialogService;

        public ClientWindowViewModel()
        {
            dalObject = new PortfolioDAL();
            Brushes = new List<ClientInfo>();
            dialogService = new ModelDialogService();
            LoadClientImages();
        }

        private ICommand openSapientPortfolio;
        public ICommand OpenSapientPortfolio
        {
            get
            {
                if (openSapientPortfolio == null)
                    openSapientPortfolio = new RelayCommand(p => OpenSapient(p));
                return openSapientPortfolio;
            }
        }

        private void OpenSapient(object obj)
        {

            var res = obj as ClientInfo;
            dialogService.ShowDialog<PortfolioManager.ViewModels.MainWindowViewModel>(ViewType.PortfolioView, null, null);

        }

        private void LoadClientImages()
        {
            if (dalObject != null)
            {
                List<string> list = dalObject.GetAllClients();

                foreach (var item in list)
                {

                    //  for (int i = 0; i < 4; i++)
                    // {
                    switch (item)
                    {
                        case "Sapient":

                            ImageBrush brush = new ImageBrush();
                            Image image = new Image();
                            image.Source = new BitmapImage(
                                new Uri("C:\\Users\\Mavez  S Dabas\\Desktop\\MockProject\\New folder (2)\\DataAccessLayer\\Login\\Resources\\Sapient.jpeg"));


                            Brushes.Add(new ClientInfo()
                           {
                               Image = image.Source,
                               ClientName = item,
                               OpenCommand = OpenSapientPortfolio
                           });
                            break;

                        case "Google":
                            ImageBrush brush1 = new ImageBrush();
                            Image image1 = new Image();
                            image1.Source = new BitmapImage(
                                new Uri("C:\\Users\\Mavez  S Dabas\\Desktop\\MockProject\\New folder (2)\\DataAccessLayer\\Login\\Resources\\Google.jpg"));
                            Brushes.Add(new ClientInfo()
                            {
                                Image = image1.Source,
                                ClientName = item,
                                OpenCommand = OpenSapientPortfolio
                            });
                            break;

                        case "Microsoft":
                            ImageBrush brush2 = new ImageBrush();
                            Image image2 = new Image();
                            image2.Source = new BitmapImage(
                                new Uri("C:\\Users\\Mavez  S Dabas\\Desktop\\MockProject\\New folder (2)\\DataAccessLayer\\Login\\Resources\\Microsoft.jpg"));
                            Brushes.Add(new ClientInfo()
                            {
                                Image = image2.Source,
                                ClientName = item,
                                OpenCommand = OpenSapientPortfolio
                            });
                            break;

                        case "Apple":
                            ImageBrush brush3 = new ImageBrush();
                            Image image3 = new Image();
                            image3.Source = new BitmapImage(
                                new Uri("C:\\Users\\Mavez  S Dabas\\Desktop\\MockProject\\New folder (2)\\DataAccessLayer\\Login\\Resources\\Apple.jpg"));
                            Brushes.Add(new ClientInfo()
                            {
                                Image = image3.Source,
                                ClientName = item,
                                OpenCommand = OpenSapientPortfolio
                            });
                            break;


                        default:
                            break;
                    }

                }
            }
        }
    }
}
