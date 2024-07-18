using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class RaportSprzedazDostawcyViewModel : WorkspaceViewModel
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

        private int _IdKontrahenta;
        public int IdKontrahenta
        {
            get { return _IdKontrahenta; }
            set
            {
                if (value != _IdKontrahenta)
                {
                    _IdKontrahenta = value;
                    OnPropertyChanged(() => IdKontrahenta);
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

        public IEnumerable<KeyAndValue> KontrahenciComboBoxItems
        {
            get
            {
                return new KontrahentB(_dbContext).GetKontrahentKeyAndValueItems();
            }
        }
        public RaportSprzedazDostawcyViewModel()
        {
            base.DisplayName = "Raport sprzedazy kontrahenta";
            _dbContext = new ProjektDbContext();
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
            _Towary = new ObservableCollection<TwTowarForViewsListB>();
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
                    _ObliczCommand = new BaseCommand(() => obliczSprzedazClik());
                }
                return _ObliczCommand;
            }
        }
        #endregion

        private ObservableCollection<TwTowarForViewsListB> _Towary;
        public ObservableCollection<TwTowarForViewsListB> Towary
        {
            get
            {                                 
                return _Towary;
            }
            set
            {
                _Towary = value;
                OnPropertyChanged(() => Towary);
            }
        }
    //   from dokDokumenty in _dbContext.DokDokuments
    //   select new DokDokumentForViews
    //        {
    //            RodzajDokumentu = dokDokumenty.DokKategoriaDokumentu.KdNazwa, 
    //            NrDokumentu = dokDokumenty.DokTytul,
    //            Magazyn = dokDokumenty.DokMag.MagNazwa,
    //            DataDokumentu = dokDokumenty.DokDataWyst
    //}
    private void obliczSprzedazClik()
        {
            // Wywolanie funkcji biznesowej, SprzedazKontrahentaOkres
           // Sprzedaz = new UtargB(_dbContext).UtargTowarOkres(IdTowaru, DataOd, DataDo);
            Sprzedaz = new SprzedazB(_dbContext).SprzedazKontrahentaOkres(IdKontrahenta, DataOd, DataDo)??0;
            odswiezListeTowarow();
        }            
        private void odswiezListeTowarow()
        {
            IEnumerable<TwTowarForViewsListB> listaDoDodania = new SprzedazB(_dbContext).PobierzListeTop(IdKontrahenta, DataOd, DataDo);
            Towary.Clear();
            foreach (TwTowarForViewsListB item in listaDoDodania)
            {
                Towary.Add(item);
            }
           // Towary.Add(new SprzedazB(_dbContext).PobierzListeTop(IdKontrahenta, DataOd, DataDo));
        }
    }

}
