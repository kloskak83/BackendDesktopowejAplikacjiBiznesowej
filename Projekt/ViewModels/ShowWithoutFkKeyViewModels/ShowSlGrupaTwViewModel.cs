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
    class ShowSlGrupaTwViewModel : WszystkieViewModel<SlGrupaTw>
    {
        public ShowSlGrupaTwViewModel() : base("Grupa towarow")
        {
        }
        public override void load()
        {
            List = new ObservableCollection<SlGrupaTw>(_dbContext.SlGrupaTws);
        }
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Nazwa"};
        }
        public override void sort()
        {

            if (SortField == "Nazwa")
                List = new ObservableCollection<SlGrupaTw>(List.OrderBy(item => item.GrtNazwa));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa" };
        }
        public override void find()
        {
            load();
            if (FindField == "Nazwa")
                List = new ObservableCollection<SlGrupaTw>(List.Where(item => item.GrtNazwa
           != null && item.GrtNazwa.Contains(FindTextBox)));
        }

    }
}
