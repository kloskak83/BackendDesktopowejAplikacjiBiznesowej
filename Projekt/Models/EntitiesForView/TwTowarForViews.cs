using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Models.EntitiesForView
{
    public class TwTowarForViews
    {
        public string? Symbol { get; set; }

        public string? Nazwa { get; set; }

        public string? Opis { get; set; }
        //Pole zamienic na grupe

        public string? GrupaTowaru { get; set; }
        //public int? TwIdGrupa { get; set; }
        //Pole zamienic na dostawce
        public string? PodstawowyDostawca { get; set; }
        //public int? WIdPodstDostawca { get; set; }
    }
}
