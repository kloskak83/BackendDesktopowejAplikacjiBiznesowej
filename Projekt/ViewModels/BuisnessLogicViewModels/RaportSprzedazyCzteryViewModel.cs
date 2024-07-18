using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    class RaportSprzedazyCzteryViewModel : WorkspaceViewModel
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

        private int _IdGrupy;
        public int IdGrupy
        {
            get { return _IdGrupy; }
            set
            {
                if (value != _IdGrupy)
                {
                    _IdGrupy = value;
                    OnPropertyChanged(() => IdGrupy);
                }
            }
        }

        private decimal? _Sprzedaz;
        public decimal? Sprzedaz
        {
            get { return _Sprzedaz; }
            set
            {
                if (value != _Sprzedaz)
                {
                    _Sprzedaz = value;
                    OnPropertyChanged(() => Sprzedaz);
                }
            }
        }
        private ObservableCollection<TwTowarForViewsListB>? _towary;
        public ObservableCollection<TwTowarForViewsListB>? Towary
        {
            get { return _towary; }
            set { _towary = value; OnPropertyChanged(() => Towary); }
        }

        public IEnumerable<KeyAndValue> GrupyComboBoxItems
        {
            get
            {
                return new GrupyB(_dbContext).GetGrupyKeyAndValueItems();
            }
        }
        public RaportSprzedazyCzteryViewModel()
        {
            base.DisplayName = "Raport sprzedazy grupy";
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
                    _ObliczCommand = new BaseCommand(() => obliczSprzedazClik(IdGrupy, DataOd, DataDo));
                }
                return _ObliczCommand;
            }
        }
        private void obliczSprzedazClik(int IdGrupy, DateTime DataOd, DateTime DataDo) 
        {
            Sprzedaz = new GrupyB(_dbContext).SprzedazGrupaOkres(IdGrupy, DataOd, DataDo);
            updateTowary(IdGrupy, DataOd, DataDo);
        }

        private void updateTowary(int IdGrupy, DateTime DataOd, DateTime DataDo)
        {
            Towary = new GrupyB(_dbContext).GetWybraneTowary<TwTowarForViewsListB>(IdGrupy, DataOd, DataDo);
        }
        #endregion
    }
}
