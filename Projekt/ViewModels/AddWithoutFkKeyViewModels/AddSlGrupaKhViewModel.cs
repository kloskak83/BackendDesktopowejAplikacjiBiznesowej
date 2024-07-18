using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Models.Entities;

namespace Projekt.ViewModels.AddViewModels
{
    internal class AddSlGrupaKhViewModel : JedenViewModel<SlGrupaKh>
    {
        public AddSlGrupaKhViewModel() : base("Grupa kontrahentów")
        {
            item = new SlGrupaKh();
        }
        public string NazwaGrupyKontrahentow
        {
            get
            {
                return item.GrkNazwa;
            }
            set
            {
                if (item.GrkNazwa != value)
                {
                    item.GrkNazwa = value;
                    OnPropertyChanged(() => NazwaGrupyKontrahentow);
                }
            }
        }

        public int MyProperty { get; set; }
        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            { //czy istnieje tez tu w osobnej metodzie
                case nameof(NazwaGrupyKontrahentow) :
                    return NazwaGrupyKontrahentow.IsNullOrEmpty() ? "To pole jest wymagane" : string.Empty;
                default:
                    return string.Empty;                    
            };
        }

        protected override string ValidateModel()
        {
            string errors = string.Empty;
            //Walidujemy wszystkie propertisy 
            errors += ValidateProperty(nameof(NazwaGrupyKontrahentow));
            return errors;
        }


    }
}
