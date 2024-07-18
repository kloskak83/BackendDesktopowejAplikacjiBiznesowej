using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Models.EntitiesForView
{
    class TwTowarForViewsAddFaktura 
    {
        public int Id { get; set; }
        public string Symbol { get; set; }

        public string Nazwa { get; set; }

        public float Ilosc {  get; set; }
        public decimal Cena { get; set; }

    }
}
