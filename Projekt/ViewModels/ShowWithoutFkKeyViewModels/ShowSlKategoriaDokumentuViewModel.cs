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
    class ShowSlKategoriaDokumentuViewModel : WszystkieViewModel<SlKategoriaDokumentu>
    {
        public ShowSlKategoriaDokumentuViewModel() : base("Kategoria dokumentu")
        {
        }
        public override void load()
        {
            List = new ObservableCollection<SlKategoriaDokumentu>(_dbContext.SlKategoriaDokumentus);
        }
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Nazwa", "Opis"};
        }
        public override void sort()
        {

            if (SortField == "Nazwa")
                List = new ObservableCollection<SlKategoriaDokumentu>(List.OrderBy(item => item.KdNazwa));
            if (SortField == "Opis")
                List = new ObservableCollection<SlKategoriaDokumentu>(List.OrderBy(item => item.KdOpis));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa", "Opis" };
        }
        public override void find()
        {
            load();
            if (FindField == "Nazwa")
                List = new ObservableCollection<SlKategoriaDokumentu>(List.Where(item => item.KdNazwa
           != null && item.KdNazwa.Contains(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<SlKategoriaDokumentu>(List.Where(item => item.KdOpis 
                != null && item.KdOpis.Contains(FindTextBox)));
        }

    }
}
