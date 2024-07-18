using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Helpers.Extensions;
using Projekt.Models.Context;
using Projekt.Models.EntitiesForView;

namespace Projekt.Models.BuisnessLogic
{
    public class GrupyB : DatabaseClass
    {
        public GrupyB(ProjektDbContext dbContext) : base(dbContext)
        {

        }
        public decimal? SprzedazGrupaOkres(int idGrupy, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                    from pozycja in dbContext.DkPozycjeNaDokumencies
                    join towar in dbContext.TwTowars 
                    on pozycja.DkpIdTowaru equals towar.TwId
                    join grupy in dbContext.SlGrupaTws
                    on towar.TwIdGrupa equals grupy.GrtId
                    join dokument in dbContext.DokDokuments
                    on pozycja.DkpIdDokumentu equals dokument.DokId
                    where 
                        grupy.GrtId == idGrupy &&
                        dokument.DokDataWyst >= dataOd &&
                        dokument.DokDataWyst <= dataDo
                    select (decimal)pozycja.DkpIlosc * pozycja.TcCenaNettNaDokumencie
                //from pozycja in dbContext.DkPozycjeNaDokumencies
                //join dokument in dbContext.DokDokuments
                //on pozycja.DkpIdDokumentu equals dokument.DokId
                //join towar in dbContext.TwTowars
                //on pozycja.DkpIdTowaru equals towar.TwId
                //where
                //    towar.WIdPodstDostawca == idKontrahenta && //sprawdzamy czy ta pozycja dotyczny danego towaru
                //    dokument.DokDataWyst >= dataOd &&
                //    dokument.DokDataWyst <= dataDo
                //select (decimal)pozycja.DkpIlosc * pozycja.TcCenaNettNaDokumencie
                ).Sum();
        }

        public IEnumerable<KeyAndValue> GetGrupyKeyAndValueItems()
        {
            return (
                from grupy in dbContext.SlGrupaTws
                select new KeyAndValue
                {
                    Key = grupy.GrtId,
                    Value = grupy.GrtNazwa
                }
                ).ToList();
        }
        public ObservableCollection<T>? GetWybraneTowary<T>(int idGrupy, DateTime dataOd, DateTime dataDo) 
            where T : IListB, new()
        {
            return (
                    from pozycja in dbContext.DkPozycjeNaDokumencies
                    join towar in dbContext.TwTowars
                    on pozycja.DkpIdTowaru equals towar.TwId
                    join grupy in dbContext.SlGrupaTws
                    on towar.TwIdGrupa equals grupy.GrtId
                    join dokument in dbContext.DokDokuments
                    on pozycja.DkpIdDokumentu equals dokument.DokId
                    where
                        grupy.GrtId == idGrupy &&
                        dokument.DokDataWyst >= dataOd &&
                        dokument.DokDataWyst <= dataDo
                    select new T
                    {
                        Nazwa = towar.TwNazwa,
                        Symbol = towar.TwSymbol,                        
                    }


                ).ToList()
                //Malo wydajne rozwiazanie
                .ToObservableCollection();           
        }
    }
}
