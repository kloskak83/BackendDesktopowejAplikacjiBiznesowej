using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Projekt.Models.EntitiesForView;

namespace Projekt.ViewModels.ShowWithFkKeyViewModels
{
    internal class WszyscyKontrahenciViewModel : WszystkieViewModel<KhKontrahenciForViews>
    {
        public WszyscyKontrahenciViewModel() : base("Wszyscy kontrahenci")
        {
        }

        public override void load()
        {
            List = new ObservableCollection<KhKontrahenciForViews>(
                from khKontrahent in _dbContext.KhKontrahents
                select new KhKontrahenciForViews
                {
                    Symbol = khKontrahent.KhSymbol,
                    Name=khKontrahent.KhIdAdresuNavigation.AdrNazwa,
                    GrupaKontrahenta = khKontrahent.KhIdGrupaNavigation.GrkNazwa,
                    Adres = khKontrahent.KhIdAdresuNavigation.AdrMiejscowosc
                }                
                );
        }

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Name", "Adres", "Symbol" };
        }
        public override void sort()
        {

            if (SortField == "Name")
                List = new ObservableCollection<KhKontrahenciForViews>(List.OrderBy(item => item.Name));
            if (SortField == "Adres")
                List = new ObservableCollection<KhKontrahenciForViews>(List.OrderBy(item => item.Adres));
            if (SortField == "Symbol")
                List = new ObservableCollection<KhKontrahenciForViews>(List.OrderBy(item => item.Symbol));

        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Symbol", "Adres" };
        }
        public override void find()
        {
            load();
            if (FindField == "Symbol")
                List = new ObservableCollection<KhKontrahenciForViews>(List.Where(item => item.Symbol
           != null && item.Symbol.StartsWith(FindTextBox)));
            if (FindField == "Adres")
                List = new ObservableCollection<KhKontrahenciForViews>(List.Where(item => item.Adres != null && item.Adres.StartsWith(FindTextBox)));
        }

    }
}
