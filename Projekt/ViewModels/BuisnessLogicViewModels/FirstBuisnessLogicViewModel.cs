using Azure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Projekt.Helpers;
using Projekt.Models.BuisnessLogic;
using Projekt.Models.Context;
using Projekt.ViewModels.ShowWithoutFkKeyViewModels;

namespace Projekt.ViewModels.BuisnessLogicViewModels
{
    internal class FirstBuisnessLogicViewModel : WorkspaceViewModel
    {
        #region db
        protected readonly ProjektDbContext _dbContext;
        #endregion

        public FirstBuisnessLogicViewModel()
        {
            base.DisplayName = "Pierwsza logika bisnesowa";
            _dbContext = new ProjektDbContext();
        }

        private float? _Wynik;
        public float? Wynik
        {
            get { return _Wynik; }
            set
            {
                if (value != _Wynik)
                {
                    _Wynik = value;
                    OnPropertyChanged(() => Wynik);
                }
            }
        }

        #region Command
        private BaseCommand _ObliczWynikCommand;
        //Ten properties zostanie podpiety pod przycisk ObliczWynik, wywola on funkcje ObliczWynikUtargClick
        public ICommand ObliczWynikCommand
        {
            get
            {
                if (_ObliczWynikCommand == null)
                {
                    _ObliczWynikCommand = new BaseCommand(() => obliczWynikClik());
                }
                return _ObliczWynikCommand;
            }
        }

        private void obliczWynikClik()
        {
            //Wywolanie funkcji biznesowej, 
           // Wynik = new UtargB(fakturyEntities).UtargTowarOkres(IdTowaru, DataOd, DataDo);
            Wynik = new LiczbaTowarowB(_dbContext).ListaTowaroWBazie();
        }
        #endregion
    }
}
