using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Models.Entities;

namespace Projekt.ViewModels.AddViewModels
{
    class AddSlMagazynViewModel : JedenViewModel<SlMagazyn>
    {
        public AddSlMagazynViewModel() : base("Dodaj magazyn")
        {
            item = new SlMagazyn();
        }
        public string MagazynSymbol
        {
            get
            {
                return item.MagSymbol;
            }
            set
            {
                if (item.MagSymbol != value)
                {
                    item.MagSymbol = value;
                    OnPropertyChanged(() => MagazynSymbol);
                }
            }
        }
        public string MagazynNazwa
        {
            get
            {
                return item.MagNazwa;
            }
            set
            {
                if (item.MagNazwa != value)
                {
                    item.MagNazwa = value;
                    OnPropertyChanged(() => MagazynNazwa);
                }
            }
        }
        public string? MagazynOpis
        {
            get
            {
                return item.MagOpis;
            }
            set
            {
                if (item.MagOpis != value)
                {
                    item.MagOpis = value;
                    OnPropertyChanged(() => MagazynOpis);
                }
            }
        }
        public bool? CzyMagazynGlowny
        {
            get
            {
                return item.MagGlowny;
            }
            set
            {
                if (item.MagGlowny != value)
                {
                    item.MagGlowny = value;
                    OnPropertyChanged(() => CzyMagazynGlowny);
                }
            }
        }

        protected override string ValidateModel()
        {
            string errors = string.Empty;
            //Walidujemy wszystkie propertisy 
            errors += ValidateProperty(nameof(MagazynSymbol));
            errors += ValidateProperty(nameof(MagazynNazwa));
            return errors;
        }

        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            { //czy istnieje tez tu w osobnej metodzie
                case nameof(MagazynSymbol):
                    return MagazynSymbol.IsNullOrEmpty() ? "Pole symbol jest wymagane" : string.Empty;
                case nameof(MagazynNazwa):
                    return MagazynNazwa.IsNullOrEmpty() ? "Pole nazwa magazynu jest wymagana" : string.Empty;
                default:
                    return string.Empty;
            };
        }
    }
}
