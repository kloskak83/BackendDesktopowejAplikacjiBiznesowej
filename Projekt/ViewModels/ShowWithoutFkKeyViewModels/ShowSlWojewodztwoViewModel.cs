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
    internal class ShowSlWojewodztwoViewModel : WszystkieViewModel<SlWojewodztwo>
    {
        public ShowSlWojewodztwoViewModel() : base("Slownik wojewodztwa")
        {
        }
        public override void load()
        {
            List = new ObservableCollection<SlWojewodztwo>(_dbContext.SlWojewodztwos);
        }

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Nazwa" };
        }
        public override void sort()
        {

            if (SortField == "Name")
                List = new ObservableCollection<SlWojewodztwo>(List.OrderBy(item => item.WojNazwa));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa" };
        }
        public override void find()
        {
            load();
            if (FindField == "Nazwa")
                List = new ObservableCollection<SlWojewodztwo>(List.Where(item => item.WojNazwa
           != null && item.WojNazwa.Contains(FindTextBox)));        
        }
    }     
}
