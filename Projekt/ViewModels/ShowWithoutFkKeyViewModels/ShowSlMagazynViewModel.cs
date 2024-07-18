using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Models.Entities;
using Projekt.Models.EntitiesForView;

namespace Projekt.ViewModels.ShowWithoutFkKeyViewModels
{
    class ShowSlMagazynViewModel : WszystkieViewModel<SlMagazyn>
    {
        public ShowSlMagazynViewModel() : base("Magazyny")
        {
        }
        public override void load()
        {
            List = new ObservableCollection<SlMagazyn>(_dbContext.SlMagazyns);
        }

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Symbol","Nazwa", "Opis"};
        }
        public override void sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<SlMagazyn>(List.OrderBy(item => item.MagNazwa));
            if (SortField == "Opis")
                List = new ObservableCollection<SlMagazyn>(List.OrderBy(item => item.MagOpis));
            if (SortField == "Symbol")
                List = new ObservableCollection<SlMagazyn>(List.OrderBy(item => item.MagSymbol));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Symbol", "Nazwa", "Opis" };
        }
        public override void find()
        {
            load();
            if (FindField == "Symbol")
                List = new ObservableCollection<SlMagazyn>(List.Where(item => item.MagSymbol
           != null && item.MagSymbol.Contains(FindTextBox)));
            if (FindField == "Nazwa")
                List = new ObservableCollection<SlMagazyn>(List.Where(item => item.MagNazwa
           != null && item.MagNazwa.Contains(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<SlMagazyn>(List.Where(item => item.MagOpis 
                != null && item.MagOpis.Contains(FindTextBox)));
        }

    }
}
