using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Models.Context;
using Projekt.Models.Entities;
using Projekt.Models.EntitiesForView;

namespace Projekt.Models.BuisnessLogic
{
    class GenerowanieCennikaB : DatabaseClass
    {
        public GenerowanieCennikaB(ProjektDbContext dbContext) : base(dbContext)
        {
        }

        public void PolaczTabele(ObservableCollection<CennikForViews> cennikForViews, TwCena twCena )
        {
            List<SlCennik> slownik = (from lista in dbContext.SlCenniks select new SlCennik 
            { 
                SlCId=lista.SlCId,
                SlCNazwa=lista.SlCNazwa
            
            }).ToList();

            cennikForViews.Clear(); 
            cennikForViews.Add(new CennikForViews() { NazwaCennika = slownik[0].SlCNazwa, CenaNetto = twCena.TcCenaNetto1, CenaBrutto = twCena.TcCenaBrutto1 });
            cennikForViews.Add(new CennikForViews() { NazwaCennika = slownik[1].SlCNazwa, CenaNetto = twCena.TcCenaNetto2, CenaBrutto = twCena.TcCenaBrutto2 });
            cennikForViews.Add(new CennikForViews() { NazwaCennika = slownik[2].SlCNazwa, CenaNetto = twCena.TcCenaNetto3, CenaBrutto = twCena.TcCenaBrutto3 });
            cennikForViews.Add(new CennikForViews() { NazwaCennika = slownik[3].SlCNazwa, CenaNetto = twCena.TcCenaNetto4, CenaBrutto = twCena.TcCenaBrutto4 });
        }
    }
}
