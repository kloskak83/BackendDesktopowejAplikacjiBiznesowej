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
    class ShowSlGrupaKhViewModel : WszystkieViewModel<SlGrupaKh>
    {
        public ShowSlGrupaKhViewModel() : base("Grupa kontrahentow")
        {
        }

        public override void load()
        {
            List = new ObservableCollection<SlGrupaKh>(_dbContext.SlGrupaKhs);
        }
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Nazwa"};
        }
        public override void sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<SlGrupaKh>(List.OrderBy(item => item.GrkNazwa));          
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa"};
        }
        public override void find()
        {
            load();
            if (FindField == "Nazwa")
                List = new ObservableCollection<SlGrupaKh>(List.Where(item => item.GrkNazwa
           != null && item.GrkNazwa.Contains(FindTextBox)));
        }
    }
}
