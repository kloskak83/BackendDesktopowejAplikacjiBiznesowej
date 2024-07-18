using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Models.Entities;

namespace Projekt.ViewModels.ShowWithoutFkKeyViewModels
{
    class ShowSlCechaTwViewModel : WszystkieViewModel<SlCechaTw>
    {
        public ShowSlCechaTwViewModel() : base("Cecha towarów")
        {
        }

        public override void load()
        {
            List = new ObservableCollection<SlCechaTw>(_dbContext.SlCechaTws);
        }
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Nazwa"};
        }
        public override void sort()
        {

            if (SortField == "Nazwa")
                List = new ObservableCollection<SlCechaTw>(List.OrderBy(item => item.CtwNazwa));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa"};
        }
        public override void find()
        {
            load();
            if (FindField == "Nazwa")
                List = new ObservableCollection<SlCechaTw>(List.Where(item => item.CtwNazwa
           != null && item.CtwNazwa.Contains(FindTextBox)));
        }
    }
}
