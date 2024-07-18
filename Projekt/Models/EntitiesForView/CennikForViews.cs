using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Models.EntitiesForView
{
    public class CennikForViews
    {
        public int Id { get; set; }
        public string NazwaCennika { get; set; }
        public decimal CenaNetto { get; set; }
        public decimal CenaBrutto { get; set; }

    }
}
