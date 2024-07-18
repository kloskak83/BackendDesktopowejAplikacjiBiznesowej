using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Models.Context;
using Projekt.Models.EntitiesForView;

namespace Projekt.Models.BuisnessLogic
{
    public class KontrahentB : DatabaseClass
    {
        public KontrahentB(ProjektDbContext dbContext) : base(dbContext)
        {

        }
        public IEnumerable<KeyAndValue> GetKontrahentKeyAndValueItems()
        {
            return (
                from kontrahent in dbContext.KhKontrahents
                select new KeyAndValue
                {
                    Key = kontrahent.KhId,
                    Value = kontrahent.KhNazwa != null ? kontrahent.KhNazwa : kontrahent.KhImie + " " + kontrahent.KhNazwisko
                }
                ).ToList();
        }
    }
}
