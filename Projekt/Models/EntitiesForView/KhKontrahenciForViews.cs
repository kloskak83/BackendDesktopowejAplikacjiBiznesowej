using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Models.EntitiesForView
{
    internal class KhKontrahenciForViews
    {
        public int Id { get; set; }
        public string? Symbol { get; set; }
        public string? Name { get; set; }
        public string? GrupaKontrahenta { get; set; }
        public string? Adres {  get; set; }

        //KhIdGrupaNavigation
    }
}
