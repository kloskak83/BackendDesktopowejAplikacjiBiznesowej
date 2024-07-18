using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Projekt.ViewModels.ModalWindowsViewModel;
using Projekt.ViewModels.ShowWithoutFkKeyViewModels;
using Projekt.Views.ModalWindowsView;

namespace Projekt.Helpers
{
    public static class WindowManager
    {
        public static void OpenModalWindow(WorkspaceViewModel viewModel)
        {
            if (viewModel is KalkulacjaCenViewModel pozycjaFakturyViewModel)
            {
                Window window = new();
                KalkulacjaCenView userControl = new()
                {
                    DataContext = pozycjaFakturyViewModel
                };
                window.Content = userControl;
                window.Title = pozycjaFakturyViewModel.DisplayName;
                window.Owner = App.Current.MainWindow;
                pozycjaFakturyViewModel.RequestClose += (x, y) =>
                {
                    window.Close();
                };
                window.ShowDialog();
            }
        }
    }
}
