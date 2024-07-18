using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Models.Context;

namespace Projekt.Models.BuisnessLogic
{
    public class UtargB : DatabaseClass
    {
        public UtargB(ProjektDbContext dbContext) : base(dbContext)
        {
        }
        public decimal? UtargTowarOkres(int idTowaru, DateTime dataOd, DateTime dataDo)
        {
            return
                (                   
                    from pozycja in dbContext.DkPozycjeNaDokumencies
                    join dokument in dbContext.DokDokuments
                    on pozycja.DkpIdDokumentu equals dokument.DokId
                    where
                        pozycja.DkpIdTowaru == idTowaru && //sprawdzamy czy ta pozycja dotyczny danego towaru
                        dokument.DokDataWyst >= dataOd &&
                        dokument.DokDataWyst <= dataDo
                    select (decimal)pozycja.DkpIlosc * pozycja.TcCenaNettNaDokumencie
                ).Sum();

        }
    }
}
