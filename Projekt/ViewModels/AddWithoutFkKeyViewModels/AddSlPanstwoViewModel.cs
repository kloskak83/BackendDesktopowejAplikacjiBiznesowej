using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Models.Entities;

namespace Projekt.ViewModels.AddViewModels
{
    class AddSlPanstwoViewModel : JedenViewModel<SlPanstwo>
    {
        public AddSlPanstwoViewModel() : base("Dodaj panstwo")
        {
            item = new SlPanstwo();
        }
        public string NazwaPanstwa
        {
            get
            {
                return item.PaNazwa;
            }
            set
            {
                if (item.PaNazwa != value)
                {
                    item.PaNazwa = value;
                    OnPropertyChanged(() => NazwaPanstwa);
                }
            }
        }
        public string? KodPanstwaUe
        {
            get
            {
                return item.PaKodPanstwaUe;
            }
            set
            {
                if (item.PaKodPanstwaUe != value)
                {
                    item.PaKodPanstwaUe = value;
                    OnPropertyChanged(() => KodPanstwaUe);
                }
            }
        }
        protected override string ValidateModel()
        {
            string errors = string.Empty;
            //Walidujemy wszystkie propertisy 
            errors += ValidateProperty(nameof(NazwaPanstwa));
            return errors;
        }
        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            { //czy istnieje tez tu w osobnej metodzie
                case nameof(NazwaPanstwa):
                    return NazwaPanstwa.IsNullOrEmpty() ? "To pole jest wymagane" : string.Empty;
                default:
                    return string.Empty;
            };
        }
    }
}
