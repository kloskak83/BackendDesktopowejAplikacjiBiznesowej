using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Projekt.Helpers;
using Projekt.Models.BuisnessLogic;
using Projekt.Models.Context;
using Projekt.Models.EntitiesForView;
using Projekt.ViewModels.ShowWithoutFkKeyViewModels;

namespace Projekt.ViewModels.BuisnessLogicViewModels
{
    class RaportSprzedazyViewModel : WorkspaceViewModel
    {

        protected readonly ProjektDbContext _dbContext;

        private DateTime _DataOd;
        public DateTime DataOd
        {
            get { return _DataOd; }
            set
            {
                if (value != _DataOd)
                {
                    _DataOd = value;
                    OnPropertyChanged(() => DataOd);
                }
            }
        }

        private DateTime _DataDo;
        public DateTime DataDo
        {
            get { return _DataDo; }
            set
            {
                if (value != _DataDo)
                {
                    _DataDo = value;
                    OnPropertyChanged(() => DataDo);
                }
            }
        }

        private int _IdTowaru;
        public int IdTowaru
        {
            get { return _IdTowaru; }
            set
            {
                if (value != _IdTowaru)
                {
                    _IdTowaru = value;
                    OnPropertyChanged(() => IdTowaru);
                }
            }
        }

        private decimal? _Utarg;
        public decimal? Utarg
        {
            get { return _Utarg; }
            set
            {
                if (value != _Utarg)
                {
                    _Utarg = value;
                    OnPropertyChanged(() => Utarg);
                }
            }
        }

        public IEnumerable<KeyAndValue> TowaryComboBoxItems
        {
            get
            {                
                return new TowarB(_dbContext).GetTowaryKeyAndValueItems();
            }
        }
        public RaportSprzedazyViewModel()
        {
            base.DisplayName = "Raport sprzedazy";
            _dbContext = new ProjektDbContext();
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
        }

        #region Command
        private BaseCommand _ObliczCommand;
        //Ten properties zostanie podpiety pod przycisk oblicz, wywola on funkcje obliczUtargClick
        public ICommand ObliczCommand
        {
            get
            {
                if (_ObliczCommand == null)
                {
                    _ObliczCommand = new BaseCommand(() => obliczUtargClik());
                }
                return _ObliczCommand;
            }
        }
        #endregion

        private void obliczUtargClik()
        {
           // Wywolanie funkcji biznesowej, 
            Utarg = new UtargB(_dbContext).UtargTowarOkres(IdTowaru, DataOd, DataDo);
        }
    }
}
