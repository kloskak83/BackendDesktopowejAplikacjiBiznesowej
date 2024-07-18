using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Models.Context;

namespace Projekt.Models.BuisnessLogic
{
    internal class LiczbaTowarowB : DatabaseClass
    {
        public LiczbaTowarowB(ProjektDbContext dbContext) : base(dbContext)
        {
        }
        public float? ListaTowaroWBazie()
        {
            //Dodać logikę 
            //return default;
            return 100;
        }
    }
}
