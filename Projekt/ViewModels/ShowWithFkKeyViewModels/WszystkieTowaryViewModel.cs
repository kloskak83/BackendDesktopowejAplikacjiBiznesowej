using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Projekt.Models.EntitiesForView;

namespace Projekt.ViewModels.ShowWithFkKeyViewModels;
internal class WszystkieTowaryViewModel : WszystkieViewModel<TwTowarForViews>
{
    public WszystkieTowaryViewModel() : base("Wszystkie towary")
    {
    }

    public override List<string> getComboboxSortList()
    {
        return new List<string> { "Symbol", "Nazwa","Grupa", "Dostawca","Opis" };
    }
    public override void sort()
    {
        if (SortField == "Symbol")
            List = new ObservableCollection<TwTowarForViews>(List.OrderBy(item => item.Symbol));
        if (SortField == "Nazwa")
            List = new ObservableCollection<TwTowarForViews>(List.OrderBy(item => item.Nazwa));
        if (SortField == "Grupa")
            List = new ObservableCollection<TwTowarForViews>(List.OrderBy(item => item.GrupaTowaru));
        if (SortField == "Dostawca")
            List = new ObservableCollection<TwTowarForViews>(List.OrderBy(item => item.PodstawowyDostawca));
        if (SortField == "Opis")
            List = new ObservableCollection<TwTowarForViews>(List.OrderBy(item => item.Opis));
    }
    public override List<string> getComboboxFindList()
    {
        return new List<string> { "Symbol", "Nazwa", "Grupa", "Dostawca", "Opis" };
    }
    public override void find()
    {
        load();
        if (FindField == "Symbol")
            List = new ObservableCollection<TwTowarForViews>(List.Where(item => item.Symbol
       != null && item.Symbol.Contains(FindTextBox)));
        if (FindField == "Nazwa")
            List = new ObservableCollection<TwTowarForViews>(List.Where(item => item.Nazwa
       != null && item.Nazwa.Contains(FindTextBox)));
        if (FindField == "Grupa")
            List = new ObservableCollection<TwTowarForViews>(List.Where(item => item.GrupaTowaru
       != null && item.GrupaTowaru.Contains(FindTextBox)));
        if (FindField == "Dostawca")
            List = new ObservableCollection<TwTowarForViews>(List.Where(item => item.PodstawowyDostawca
       != null && item.PodstawowyDostawca.Contains(FindTextBox)));
        if (FindField == "Opis")
            List = new ObservableCollection<TwTowarForViews>(List.Where(item => item.Opis
            != null && item.Opis.Contains(FindTextBox)));
    }

    public override void load()
    {
        List = new ObservableCollection<TwTowarForViews>(
                from twTowar in _dbContext.TwTowars
                select new TwTowarForViews
                {
                    Symbol = twTowar.TwSymbol,
                    Nazwa = twTowar.TwNazwa,
                    Opis = twTowar.TwOpis,
                    GrupaTowaru = twTowar.TwIdGrupaNavigation.GrtNazwa,                       
                    PodstawowyDostawca = twTowar.WIdPodstDostawcaNavigation.KhSymbol 
                    + " " + (twTowar.WIdPodstDostawcaNavigation.KhNazwa 
                    != null ? twTowar.WIdPodstDostawcaNavigation.KhNazwa : 
                    twTowar.WIdPodstDostawcaNavigation.KhImie + " " + twTowar.WIdPodstDostawcaNavigation.KhNazwisko)
                }
                
            );

//        List = new ObservableCollection<FakturaForViews>
//(
//    //dla kazdej faktury z base danych faktur
//    from faktura in _fakturyEntities.Fakturas
//        //tworzymy nowa FaktureForView
//    select new FakturaForViews
//    {
//        IdFaktury = faktura.IdFaktury,//id nowej faktury ustawiamy takie jak id faktury z bazy danych
//        Numer = faktura.Numer,
//        DataWystawienia = faktura.DataWystawienia,
//        KontrahentNazwa = faktura.IdKontrahentaNavigation.Nazwa,
//        KontrahentNIP = faktura.IdKontrahentaNavigation.Nip,
//        KontrahentAdres = faktura.IdKontrahentaNavigation.IdAdresuNavigation.Miejscowosc + " "
//        + faktura.IdKontrahentaNavigation.IdAdresuNavigation.Ulica,
//        TerminPlatnosci = faktura.TerminPlatnosci,
//        SposobPlatnosciNazwa = faktura.IdSposobuPlatnosciNavigation.Nazwa
//    }
//);
    }
}
