using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Models.Entities;
using Projekt.Models.EntitiesForView;

namespace Projekt.ViewModels.ShowWithFkKeyViewModels
{
    internal class WszystkieEwidencjeViewModel : WszystkieViewModel<AdrEwidencjaForViews>
    {
        public WszystkieEwidencjeViewModel() : base("Wszystkie ewidencje")
        {
        }
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Nazwa", "Adres", "Nr telefonu", "Nazwa pełna" };
        }
        public override void sort()
        {

            if (SortField == "Nazwa")
                List = new ObservableCollection<AdrEwidencjaForViews>(List.OrderBy(item => item.Nazwa));
            if (SortField == "Adres")
                List = new ObservableCollection<AdrEwidencjaForViews>(List.OrderBy(item => item.Adres));
            if (SortField == "Nr telefonu")
                List = new ObservableCollection<AdrEwidencjaForViews>(List.OrderBy(item => item.NrTelefonu));
            if (SortField == "Nazwa pełna")
                List = new ObservableCollection<AdrEwidencjaForViews>(List.OrderBy(item => item.NazwaPelna));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa", "Adres", "Nr telefonu", "Nazwa pełna" };
        }
        public override void find()
        {
            load();
            if (FindField == "Nazwa")
                List = new ObservableCollection<AdrEwidencjaForViews>(List.Where(item => item.Nazwa
           != null && item.Nazwa.Contains(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<AdrEwidencjaForViews>(List.Where(item => item.Adres
                != null && item.Adres.Contains(FindTextBox)));
            if (FindField == "Nr telefonu")
                List = new ObservableCollection<AdrEwidencjaForViews>(List.Where(item => item.NrTelefonu
                != null && item.NrTelefonu.Contains(FindTextBox)));
            if (FindField == "Nazwa pełna")
                List = new ObservableCollection<AdrEwidencjaForViews>(List.Where(item => item.NazwaPelna
                != null && item.NazwaPelna.Contains(FindTextBox)));
        }

        public override void load()
        {
            List = new System.Collections.ObjectModel.ObservableCollection<AdrEwidencjaForViews> (
                    from ewidencje in _dbContext.AdrEwidencjas
                    select new AdrEwidencjaForViews
                    {
                        Nazwa = ewidencje.AdrNazwa,
                        NazwaPelna = ewidencje.AdrNazwaPelna,
                        NrTelefonu = ewidencje.AdrTelefon,
                        Adres = ewidencje.AdrMiejscowosc + " " + ewidencje.AdrKod,
                        Wojewodztwo = ewidencje.AdrIdWojewodztwoNavigation.WojNazwa,
                        Panstwo = ewidencje.AdrIdPanstwoNavigation.PaNazwa
                    }
                );
        }
    }
}
