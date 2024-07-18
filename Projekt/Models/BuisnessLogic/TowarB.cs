using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Projekt.Helpers.Extensions;
using Projekt.Models.Context;
using Projekt.Models.EntitiesForView;

namespace Projekt.Models.BuisnessLogic
{
    public class TowarB : DatabaseClass
    {
        public TowarB(ProjektDbContext dbContext) : base(dbContext)
        {
        }
        public IEnumerable<KeyAndValue> GetTowaryKeyAndValueItems()
        {
            return (
                from towar in dbContext.TwTowars
                select new KeyAndValue
                {
                    Key = towar.TwId,
                    Value = towar.TwSymbol + " " + towar.TwNazwa
                }
                ).ToList();
        }

        public ObservableCollection<KeyAndValue>? GetTowaryKeyAndValueItems(int? IdKontrahenta)
        {
            if(IdKontrahenta is null) return null;
            return new ObservableCollection<KeyAndValue>(
                from towar in dbContext.TwTowars
                join kontrahent in dbContext.KhKontrahents
                on towar.WIdPodstDostawca equals kontrahent.KhId
                where kontrahent.KhId == IdKontrahenta
                select new KeyAndValue
                {
                    Key = towar.TwId,
                    Value = towar.TwSymbol + " " + towar.TwNazwa
                }
                );
        }
        public ObservableCollection<ListDokumentsForView>? GetTowaryByTowarIdKeyAndValueItems(int? IdTowaru)
        {
            if (IdTowaru is null) return null;

            return new ObservableCollection<ListDokumentsForView>(
               from towar in dbContext.TwTowars
               join pozycje in dbContext.DkPozycjeNaDokumencies
               on towar.WIdPodstDostawca equals pozycje.DkpIdTowaru
               join dokument in dbContext.DokDokuments 
               on pozycje.DkpIdDokumentu equals dokument.DokId
               where pozycje.DkpIdTowaru == IdTowaru
               select new ListDokumentsForView
               {
                   NazwaDokumentu = dokument.DokTytul,
                   Nazwa = towar.TwNazwa
               }
               );
        }

    }
}
