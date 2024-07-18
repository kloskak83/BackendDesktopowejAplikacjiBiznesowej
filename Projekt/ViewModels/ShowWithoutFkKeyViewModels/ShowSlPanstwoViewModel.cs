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
    class ShowSlPanstwoViewModel : WszystkieViewModel<SlPanstwo>
    {
        public ShowSlPanstwoViewModel() : base("Państwa")
        {
        }
        public override void load()
        {
            List = new ObservableCollection<SlPanstwo>(_dbContext.SlPanstwos);
        }
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Państwo","Kod państwa" };
        }
        public override void sort()
        {
            if (SortField == "Państwo")
                List = new ObservableCollection<SlPanstwo>(List.OrderBy(item => item.PaNazwa));
            if (SortField == "Kod państwa")
                List = new ObservableCollection<SlPanstwo>(List.OrderBy(item => item.PaKodPanstwaUe));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Państwo","Kod państwa" };
        }
        public override void find()
        {
            load();
            if (FindField == "Państwo")
                List = new ObservableCollection<SlPanstwo>(List.Where(item => item.PaNazwa
           != null && item.PaNazwa.Contains(FindTextBox)));
            if (FindField == "Kod państwa")
                List = new ObservableCollection<SlPanstwo>(List.Where(item => item.PaKodPanstwaUe
           != null && item.PaKodPanstwaUe.Contains(FindTextBox)));
        }
    }
}
