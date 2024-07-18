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
    class ShowSlPolaWlasnieViewModel : WszystkieViewModel<SlPolaWlasne>
    {
        public ShowSlPolaWlasnieViewModel() : base("Pola własne")
        {
        }
        public override void load()
        {
            List = new ObservableCollection<SlPolaWlasne>(_dbContext.SlPolaWlasnes);
        }
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Nazwa", "Opis"};
        }
        public override void sort()
        {

            if (SortField == "Nazwa")
                List = new ObservableCollection<SlPolaWlasne>(List.OrderBy(item => item.PwNazwaPola));
            if (SortField == "Opis")
                List = new ObservableCollection<SlPolaWlasne>(List.OrderBy(item => item.PwOpisPola));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa", "Opis" };
        }
        public override void find()
        {
            load();
            if (FindField == "Nazwa")
                List = new ObservableCollection<SlPolaWlasne>(List.Where(item => item.PwNazwaPola
           != null && item.PwNazwaPola.Contains(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<SlPolaWlasne>(List.Where(item => item.PwOpisPola 
                != null && item.PwOpisPola.Contains(FindTextBox)));
        }

    }
}
