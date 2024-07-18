using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Models.Entities;

namespace Projekt.ViewModels.AddViewModels
{
    internal class AddSlCechaTwViewModel : JedenViewModel<SlCechaTw>
    {
        public AddSlCechaTwViewModel() : base("Cecha towarów")
        {
            item = new SlCechaTw();
        }
        public string NazwaCechyTowaru
        {
            get
            {
                return item.CtwNazwa;
            }
            set
            {
                if (item.CtwNazwa != value)
                {
                    item.CtwNazwa = value;
                    OnPropertyChanged(() => NazwaCechyTowaru);
                }
            }
        }

        protected override string ValidateModel()
        {
            string errors = string.Empty;
            //Walidujemy wszystkie propertisy 
            errors += ValidateProperty(nameof(NazwaCechyTowaru));
            return errors;
        }

        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            { //czy istnieje tez tu w osobnej metodzie
                case nameof(NazwaCechyTowaru) :
                    return NazwaCechyTowaru.IsNullOrEmpty() ? "To pole jest wymagane" : string.Empty;
                default:
                    return string.Empty;
            };
        }
    }

    
}
