using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Models.Context;
using Projekt.Models.EntitiesForView;

namespace Projekt.Models.BuisnessLogic
{
    internal class SprzedazB : DatabaseClass
    {
        public SprzedazB(ProjektDbContext dbContext) : base(dbContext)
        {
        }
        public decimal? SprzedazKontrahentaOkres(int idKontrahenta, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                    from pozycja in dbContext.DkPozycjeNaDokumencies
                    join dokument in dbContext.DokDokuments
                    on pozycja.DkpIdDokumentu equals dokument.DokId
                    join towar in dbContext.TwTowars
                    on pozycja.DkpIdTowaru equals towar.TwId
                    where
                        towar.WIdPodstDostawca == idKontrahenta && //sprawdzamy czy ta pozycja dotyczny danego towaru
                        dokument.DokDataWyst >= dataOd &&
                        dokument.DokDataWyst <= dataDo
                    select (decimal)pozycja.DkpIlosc * pozycja.TcCenaNettNaDokumencie
                ).Sum();
        }
        public IEnumerable<TwTowarForViewsListB> PobierzListeTop(int idKontrahenta, DateTime dataOd, DateTime dataDo)
        {
            return (
                     from pozycja in dbContext.DkPozycjeNaDokumencies
                     join dokument in dbContext.DokDokuments
                     on pozycja.DkpIdDokumentu equals dokument.DokId
                     join towar in dbContext.TwTowars
                     on pozycja.DkpIdTowaru equals towar.TwId
                     where
                         towar.WIdPodstDostawca == idKontrahenta && //sprawdzamy czy ta pozycja dotyczny danego towaru
                         dokument.DokDataWyst >= dataOd &&
                         dokument.DokDataWyst <= dataDo
                     select new TwTowarForViewsListB
                     {
                         Nazwa = towar.TwNazwa,
                         Symbol = towar.TwSymbol,
                         Ilosc = (float)pozycja.DkpIlosc,
                         Cena = pozycja.TcCenaNettNaDokumencie
                     } 
                ).ToList();

            // from pozycja in dbContext.DkPozycjeNaDokumencies
            // join dokument in dbContext.DokDokuments
            // on pozycja.DkpIdDokumentu equals dokument.DokId
            // join towar in dbContext.TwTowars
            // on pozycja.DkpIdTowaru equals towar.TwId
            // where
            //     towar.WIdPodstDostawca == idKontrahenta && //sprawdzamy czy ta pozycja dotyczny danego towaru
            //     dokument.DokDataWyst >= dataOd &&
            //     dokument.DokDataWyst <= dataDo
            // group pozycja by pozycja.DkpIdTowaru into grupa
            // let sumaSprzedaz = grupa.Sum(s => s.DkpIlosc * (float)s.TcCenaNettNaDokumencie)
            // orderby sumaSprzedaz descending
            //select new TwTowarForViewsListB
            //{
            //    Cena = (decimal)sumaSprzedaz,
            //} 
        }
    }
}
