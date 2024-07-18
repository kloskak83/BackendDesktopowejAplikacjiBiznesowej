using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Models.Entities;

namespace Projekt.ViewModels.AddViewModels
{
    class AddSlPolaWlasneViewModel : JedenViewModel<SlPolaWlasne>
    {
        public AddSlPolaWlasneViewModel() : base("Dodaj pole własne")
        {
            item = new SlPolaWlasne();
        }
        public string PoleWlasneNazwa
        {
            get
            {
                return item.PwNazwaPola;
            }
            set
            {
                if (item.PwNazwaPola != value)
                {
                    item.PwNazwaPola = value;
                    OnPropertyChanged(() => PoleWlasneNazwa);
                }
            }
        }
        public string? PoleOpis
        {
            get
            {
                return item.PwOpisPola;
            }
            set
            {
                if (item.PwOpisPola != value)
                {
                    item.PwOpisPola = value;
                    OnPropertyChanged(() => PoleOpis);
                }
            }
        }

        protected override string ValidateModel()
        {
            string errors = string.Empty;
            //Walidujemy wszystkie propertisy 
            errors += ValidateProperty(nameof(PoleWlasneNazwa));
            return errors;
        }

        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            { //czy istnieje tez tu w osobnej metodzie
                case nameof(PoleWlasneNazwa):
                    return PoleWlasneNazwa.IsNullOrEmpty() ? "To pole jest wymagane" : string.Empty;
                default:
                    return string.Empty;
            };
        }
    }
}
