using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Models.Entities;

namespace Projekt.ViewModels.AddViewModels
{
    internal class AddSlWojewodztwoViewModel : JedenViewModel<SlWojewodztwo>
    {
        public AddSlWojewodztwoViewModel() : base("Dodaj wojewodztwo")
        {
            item = new SlWojewodztwo();
        }       

        public string Wojewodztwo
        {
            get 
            { 
                return item.WojNazwa; 
            }
            set 
            { 
                if(item.WojNazwa != value)
                {
                    item.WojNazwa = value;
                    OnPropertyChanged(() => Wojewodztwo);
                }             
            }
        }

        protected override string ValidateModel()
        {
            string errors = string.Empty;
            //Walidujemy wszystkie propertisy 
            errors += ValidateProperty(nameof(Wojewodztwo));
            return errors;
        }

        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            { //czy istnieje tez tu w osobnej metodzie
                case nameof(Wojewodztwo):
                    return Wojewodztwo.IsNullOrEmpty() ? "To pole jest wymagane" : string.Empty;
                default:
                    return string.Empty;
            };
        }
    }
}
