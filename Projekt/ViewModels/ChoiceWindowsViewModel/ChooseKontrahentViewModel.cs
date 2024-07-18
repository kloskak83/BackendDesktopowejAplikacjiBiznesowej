using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Models.Entities;
using System.Collections.ObjectModel;
using Projekt.Models.EntitiesForView;
using System.Windows.Input;
using Projekt.Helpers;
using GalaSoft.MvvmLight.Messaging;

namespace Projekt.ViewModels.ChoiceWindowsViewModel
{

    internal class ChooseKontrahentViewModel : WszystkieViewModel<KhKontrahenciForViews>
    {
        #region Commands

        private BaseCommand _WybierzKontrahentaCmd;
        public ICommand WybierzKontrahentaCmd
        {
            get
            {
                if (_WybierzKontrahentaCmd == null)
                    _WybierzKontrahentaCmd = new BaseCommand(WybierzIZamknij);
                return _WybierzKontrahentaCmd;
            }
        }

        #endregion

        #region PropertisyZWidoku
        private KhKontrahenciForViews _WybranyKontrahent;
        public KhKontrahenciForViews WybranyKontrahent
        {
            get
            {
                return _WybranyKontrahent;
            }
            set
            {
                if (_WybranyKontrahent != value)
                {
                    _WybranyKontrahent = value;
                }
            }
        }
        #endregion
        public ChooseKontrahentViewModel() : base("Wybierz dostawce")
        {
        }
        
        public override void load()
        {
            List = new ObservableCollection<KhKontrahenciForViews>(
                from kontrahenci in _dbContext.KhKontrahents 
                select new KhKontrahenciForViews
                {
                    Id = kontrahenci.KhId,
                    Symbol = kontrahenci.KhSymbol,                    
                    GrupaKontrahenta = kontrahenci.KhIdGrupaNavigation.GrkNazwa,
                    Adres = kontrahenci.KhIdAdresuNavigation.AdrMiejscowosc

                });
        }

        private void WybierzIZamknij()
        {
            Messenger.Default.Send(_WybranyKontrahent);
            OnRequestClose();
        }

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Name", "Adres", "Symbol" };
        }
        public override void sort()
        {

            if (SortField == "Name")
                List = new ObservableCollection<KhKontrahenciForViews>(List.OrderBy(item => item.Name));
            if (SortField == "Adres")
                List = new ObservableCollection<KhKontrahenciForViews>(List.OrderBy(item => item.Adres));
            if (SortField == "Symbol")
                List = new ObservableCollection<KhKontrahenciForViews>(List.OrderBy(item => item.Symbol));

        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Symbol", "Adres" };
        }
        public override void find()
        {
            load();
            if (FindField == "Symbol")
                List = new ObservableCollection<KhKontrahenciForViews>(List.Where(item => item.Symbol
           != null && item.Symbol.StartsWith(FindTextBox)));
            if (FindField == "Adres")
                List = new ObservableCollection<KhKontrahenciForViews>(List.Where(item => item.Adres != null && item.Adres.StartsWith(FindTextBox)));
        }

    }
}
