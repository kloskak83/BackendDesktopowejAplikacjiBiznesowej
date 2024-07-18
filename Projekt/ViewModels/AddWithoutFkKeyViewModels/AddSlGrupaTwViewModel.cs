using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Models.Entities;

namespace Projekt.ViewModels.AddViewModels
{
    internal class AddSlGrupaTwViewModel : JedenViewModel<SlGrupaTw>
    {
        public AddSlGrupaTwViewModel() : base("Grupa towarów")
        {
            item = new SlGrupaTw();
        }
        public string NazwaGrupyTowarow
        {
            get
            {
                return item.GrtNazwa;
            }
            set
            {
                if (item.GrtNazwa != value)
                {
                    item.GrtNazwa = value;
                    OnPropertyChanged(() => NazwaGrupyTowarow);
                }
            }
        }

        protected override string ValidateModel()
        {
            string errors = string.Empty;
            //Walidujemy wszystkie propertisy 
            errors += ValidateProperty(nameof(NazwaGrupyTowarow));
            return errors;
        }

        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            { //czy istnieje tez tu w osobnej metodzie
                case nameof(NazwaGrupyTowarow):
                    return NazwaGrupyTowarow.IsNullOrEmpty() ? "To pole jest wymagane" : string.Empty;
                default:
                    return string.Empty;
            };
        }
    }
}
