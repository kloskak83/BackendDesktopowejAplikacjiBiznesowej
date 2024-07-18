using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Projekt.Helpers;
using Projekt.Models.EntitiesForView;

namespace Projekt.ViewModels.ChoiceWindowsViewModel
{
    class ChooseTowarViewModel : WszystkieViewModel<TwTowarForViewsAddFaktura>
    {
        private BaseCommand _WybierzTowarCmd;
        public ICommand WybierzTowarCmd
        {
            get
            {
                if (_WybierzTowarCmd == null)
                    _WybierzTowarCmd = new BaseCommand(WybierzIZamknij);
                return _WybierzTowarCmd;
            }
        }
        public ChooseTowarViewModel() : base("Wybierz towar")
        {
        }

        

        private TwTowarForViewsAddFaktura _WybranyTowar;
        public TwTowarForViewsAddFaktura WybranyTowar
        {
            get
            {
                return _WybranyTowar;
            }
            set
            {
                if (_WybranyTowar != value)
                {
                    _WybranyTowar = value;
                }
            }
        }

        public override void load()
        {
            List = new ObservableCollection<TwTowarForViewsAddFaktura>(
                from towary in _dbContext.TwTowars
                select new TwTowarForViewsAddFaktura
                {
                    Id = towary.TwId,
                    Symbol = towary.TwSymbol,
                    Nazwa = towary.TwNazwa,
                    Ilosc = 1,
                    //Todo poprawic na jakas wybrana cene
                    Cena = 10,

                });
        }

        private void WybierzIZamknij()
        {
            Messenger.Default.Send(_WybranyTowar);
            OnRequestClose();
        }

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Symbol", "Nazwa"};
        }
        public override void sort()
        {
            if (SortField == "Symbol")
                List = new ObservableCollection<TwTowarForViewsAddFaktura>(List.OrderBy(item => item.Symbol));
            if (SortField == "Nazwa")
                List = new ObservableCollection<TwTowarForViewsAddFaktura>(List.OrderBy(item => item.Nazwa));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Symbol", "Nazwa", "Grupa", "Dostawca", "Opis" };
        }
        public override void find()
        {
            load();
            if (FindField == "Symbol")
                List = new ObservableCollection<TwTowarForViewsAddFaktura>(List.Where(item => item.Symbol
           != null && item.Symbol.Contains(FindTextBox)));
            if (FindField == "Nazwa")
                List = new ObservableCollection<TwTowarForViewsAddFaktura>(List.Where(item => item.Nazwa
           != null && item.Nazwa.Contains(FindTextBox)));
        }

    }
}
