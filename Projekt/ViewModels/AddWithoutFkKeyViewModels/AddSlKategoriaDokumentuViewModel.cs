using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Models.Entities;

namespace Projekt.ViewModels.AddViewModels
{
    class AddSlKategoriaDokumentuViewModel : JedenViewModel<SlKategoriaDokumentu>
    {
        public AddSlKategoriaDokumentuViewModel() : base("Kategoria dokumentów")
        {
            item = new SlKategoriaDokumentu();
        }
        
        public string KatogeriaNazwa
        {
            get
            {
                return item.KdNazwa;
            }
            set
            {
                if (item.KdNazwa != value)
                {
                    item.KdNazwa = value;
                    OnPropertyChanged(() => KatogeriaNazwa);
                }
            }
        }
        public string? KatogeriaOpis
        {
            get
            {
                return item.KdOpis;
            }
            set
            {
                if (item.KdOpis != value)
                {
                    item.KdOpis = value;
                    OnPropertyChanged(() => KatogeriaOpis);
                }
            }
        }

        protected override string ValidateModel()
        {
            string errors = string.Empty;
            //Walidujemy wszystkie propertisy 
            errors += ValidateProperty(nameof(KatogeriaNazwa));
            return errors;
        }

        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            { //czy istnieje tez tu w osobnej metodzie
                case nameof(KatogeriaNazwa):
                    return KatogeriaNazwa.IsNullOrEmpty() ? "To pole jest wymagane" : string.Empty;
                default:
                    return string.Empty;
            };
        }
    }
}
