
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Models.EntitiesForView;

namespace Projekt.ViewModels.ShowWithFkKeyViewModels
{
    internal class WszystkieDokumentyViewModel : WszystkieViewModel<DokDokumentForViews>
    {
        public WszystkieDokumentyViewModel() : base("Wszystkie dokumenty")
        {
        }

        public override void load()
        {
            List = new ObservableCollection<DokDokumentForViews>(
        from dokDokumenty in _dbContext.DokDokuments
        select new DokDokumentForViews
        {
            RodzajDokumentu = dokDokumenty.DokKategoriaDokumentu.KdNazwa, 
            NrDokumentu = dokDokumenty.DokTytul,
            Magazyn = dokDokumenty.DokMag.MagNazwa,
            DataDokumentu = dokDokumenty.DokDataWyst
        }

    );
        }

        public override void find()
        {
            load();
           // if (FindField == "Symbol")
           //     List = new ObservableCollection<TwTowarForViews>(List.Where(item => item.Symbol
           //!= null && item.Symbol.Contains(FindTextBox)));
           // if (FindField == "Nazwa")
           //     List = new ObservableCollection<TwTowarForViews>(List.Where(item => item.Nazwa
           //!= null && item.Nazwa.Contains(FindTextBox)));
        }

        public override List<string> getComboboxSortList()
        {
            //Poprawic liste
            return new List<string> { "Symbol", "Nazwa", "Grupa", "Dostawca", "Opis" };
        }

        public override List<string> getComboboxFindList()
        {
            //Poprawic liste
            return new List<string> { "Symbol", "Nazwa", "Grupa", "Dostawca", "Opis" };
        }

        public override void sort()
        {
            //if (SortField == "Symbol")
            //    List = new ObservableCollection<TwTowarForViews>(List.OrderBy(item => item.Symbol));
            //if (SortField == "Nazwa")
            //    List = new ObservableCollection<TwTowarForViews>(List.OrderBy(item => item.Nazwa));
        }
    }
}
