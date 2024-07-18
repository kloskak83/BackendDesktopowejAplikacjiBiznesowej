using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Projekt.Models.Entities;
using Projekt.Models.EntitiesForView;
using Projekt.ViewModels.AddViewModels;

namespace Projekt.ViewModels.AddWithFkKeyViewModels
{
    internal class AddKontrahentViewModel : JedenViewModel<KhKontrahent>
    {
        public AddKontrahentViewModel() : base("Dodaj kontrahenta")
        {

            item = new KhKontrahent();
            adrEwidencja = new AdrEwidencja();            
            //adrEwidencja = item.
            item.KhIdAdresuNavigation = adrEwidencja;

            //_dbContext.

            visibilityFirma = Visibility.Visible;
            CheckFirma = true;
            visibilityOsoba = Visibility.Collapsed;
            
            // TypKontrahentaComboBoxItems 
        }

        private AdrEwidencja adrEwidencja;

        #region Propertisy widoku
        public string Symbol
        {
            get
            {
                return item.KhSymbol;
            }
            set
            {
                if (item.KhSymbol != value)
                {
                    item.KhSymbol = value;
                    OnPropertyChanged(() => Symbol);
                }
            }
        }
        public string? Nazwa
        {
            get
            {
                return item.KhNazwa;
            }
            set
            {
                if (item.KhNazwa != value)
                {
                    item.KhNazwa = value;
                    OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public string? Imie
        {
            get
            {
                return item.KhImie;
            }
            set
            {
                if (item.KhImie != value)
                {
                    item.KhImie = value;
                    OnPropertyChanged(() => Imie);
                }
            }
        }
        public string? Nazwisko
        {
            get
            {
                return item.KhNazwisko;
            }
            set
            {
                if (item.KhNazwisko != value)
                {
                    item.KhNazwisko = value;
                    OnPropertyChanged(() => Nazwisko);
                }
            }
        }

        public string? FullName
        {
            get
            {
                return item.KhFullName;
            }
            set
            {
                if (item.KhFullName != value)
                {
                    item.KhFullName = value;
                    OnPropertyChanged(() => FullName);
                }
            }
        }

        public string? Ulica
        {
            get
            {
                return item.KhIdAdresuNavigation.AdrUlica;
            }
            set
            {
                if (item.KhIdAdresuNavigation.AdrUlica != value)
                {
                    item.KhIdAdresuNavigation.AdrUlica = value;
                    OnPropertyChanged(() => Ulica);
                }
            }
        }
        public string? NrDomu
        {
            get
            {
                return item.KhIdAdresuNavigation.AdrNrDomu;
            }
            set
            {
                if (item.KhIdAdresuNavigation.AdrNrDomu != value)
                {
                    item.KhIdAdresuNavigation.AdrNrDomu = value;
                    OnPropertyChanged(() => NrDomu);
                }
            }
        }        
        
        public string? NrLokalu
        {
            get
            {
                return item.KhIdAdresuNavigation.AdrNrLokalu;
            }
            set
            {
                if (item.KhIdAdresuNavigation.AdrNrLokalu != value)
                {
                    item.KhIdAdresuNavigation.AdrNrLokalu = value;
                    OnPropertyChanged(() => NrLokalu);
                }
            }
        }
        public string? Miejscowosc
        {
            get
            {
                return item.KhIdAdresuNavigation.AdrMiejscowosc;
            }
            set
            {
                if (item.KhIdAdresuNavigation.AdrMiejscowosc != value)
                {
                    item.KhIdAdresuNavigation.AdrMiejscowosc = value;
                    OnPropertyChanged(() => Miejscowosc);
                }
            }
        }
        public string? KodPocztowy
        {
            get
            {
                return item.KhIdAdresuNavigation.AdrKod;
            }
            set
            {
                if (item.KhIdAdresuNavigation.AdrKod != value)
                {
                    item.KhIdAdresuNavigation.AdrKod = value;
                    OnPropertyChanged(() => KodPocztowy);
                }
            }
        }
        
        public int? Wojewodztwo
        {
            get
            {
                return item.KhIdAdresuNavigation.AdrIdWojewodztwo;
            }
            set
            {
                if (item.KhIdAdresuNavigation.AdrIdWojewodztwo != value)
                {
                    item.KhIdAdresuNavigation.AdrIdWojewodztwo = value;                   
                    OnPropertyChanged(() => Wojewodztwo);
                }
            }
        }

        public string? NIP
        {
            get
            {
                return item.KhNip;
            }
            set
            {
                if (item.KhNip != value)
                {
                    item.KhNip = value;
                    OnPropertyChanged(() => Wojewodztwo);
                }
            }
        }

        public string? REGON
        {
            get
            {
                return item.KhRegon;
            }
            set
            {
                if (item.KhRegon != value)
                {
                    item.KhRegon = value;                   
                    OnPropertyChanged(() => Wojewodztwo);
                }
            }
        }



        public IEnumerable<KeyAndValue> WojewodztwoComboBoxItems
        {
            get
            {
                return
                (
                        from wojewodztwa in _dbContext.SlWojewodztwos
                        select new KeyAndValue
                        {
                            Key = wojewodztwa.WojId,
                            Value = wojewodztwa.WojNazwa
                        }
                ).ToList();
            }
        }      
        public int? Panstwo
        {
            get
            {
                return item.KhIdAdresuNavigation.AdrIdPanstwo;
            }
            set
            {
                if (item.KhIdAdresuNavigation.AdrIdPanstwo != value)
                {
                    item.KhIdAdresuNavigation.AdrIdPanstwo = value;                   
                    OnPropertyChanged(() => Panstwo);
                }
            }
        }
        public IEnumerable<KeyAndValue> PanstwoComboBoxItems
        {
            get
            {
                return
                (
                        from panstwo in _dbContext.SlPanstwos
                        select new KeyAndValue
                        {
                            Key = panstwo.PaId,
                            Value = panstwo.PaNazwa
                        }
                ).ToList();
            }
        }       
        
        public int TypKontrahenta
        {
            get
            {
                return item.KhIdTypKontrahenta;
            }
            set
            {
                if (item.KhIdTypKontrahenta != value)
                {
                    item.KhIdTypKontrahenta = value;
                    ChangeVisible();
                    OnPropertyChanged(() => TypKontrahenta);
                }
            }
        }
        public IEnumerable<KeyAndValue> TypKontrahentaComboBoxItems
        {
            get
            {
                return
                (
                        from typKontrahent in _dbContext.KhTypKontrahenta
                        select new KeyAndValue
                        {
                            Key = typKontrahent.Id,
                            Value = typKontrahent.Nazwa
                        }
                ).ToList();
            }
        }

        public int GrupaKontrahenta
        {
            get
            {
                return item.KhIdGrupa;
            }
            set
            {
                if (item.KhIdGrupa != value)
                {
                    item.KhIdGrupa = value;
                    OnPropertyChanged(() => GrupaKontrahenta);
                }
            }
        }
        public IEnumerable<KeyAndValue> GrupaKontrahentaComboBoxItems
        {
            get
            {
                return
                (
                        from grupaKontrahent in _dbContext.SlGrupaKhs
                        select new KeyAndValue
                        {
                            Key = grupaKontrahent.GrkId,
                            Value = grupaKontrahent.GrkNazwa
                        }
                ).ToList();
            }
        }

        #endregion

        private Visibility visibilityFirma;
        public Visibility VisibilityFirma
        {
            get
            {
                return visibilityFirma;
            }
            set
            {
                visibilityFirma = value;
                OnPropertyChanged(() => VisibilityFirma);
            }
        }
        private Visibility visibilityOsoba;
        public Visibility VisibilityOsoba
        {
            get
            {
                return visibilityOsoba;
            }
            set
            {
                visibilityOsoba = value;
                OnPropertyChanged(() => VisibilityOsoba);
            }
        }

        #region Walidacja danych
        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                //Walidujemy interesujące nas proprerty
                case nameof(Symbol):
                    return Symbol.IsNullOrEmpty() ? "Nie podano symbolu\n" : string.Empty;
                case nameof(GrupaKontrahenta):
                    return GrupaKontrahenta == 0 ? "Nie wybrano grupy kontrahentow\n" : string.Empty;
                case nameof(TypKontrahenta):
                    return TypKontrahenta == 0 ? "Nie wybrano grupy kontrahentow\n" : string.Empty;
                case nameof(Nazwa):
                    return (Nazwa.IsNullOrEmpty() && CheckFirma) ? "Nie podano nazwy firmy\n" : string.Empty;
              

                case nameof(Imie):
                    return (Imie.IsNullOrEmpty() && !CheckFirma) ? "Nie podano imienia\n" : string.Empty;
                case nameof(Nazwisko):
                    return (Nazwisko.IsNullOrEmpty() && !CheckFirma) ? "Nie podano nazwiska\n" : string.Empty;

                default:
                    return string.Empty;
            }
        }

        protected override string ValidateModel()
        {
            string errors = string.Empty;
            errors += ValidateProperty(nameof(Symbol));
            errors += ValidateProperty(nameof(GrupaKontrahenta));
            errors += ValidateProperty(nameof(TypKontrahenta));
            errors += ValidateProperty(nameof(Nazwa));
            errors += ValidateProperty(nameof(Imie));
            errors += ValidateProperty(nameof(Nazwisko));
            return errors;
        }

        #endregion

        private bool CheckFirma;      

        private void ChangeVisible()
        {
            VisibilityFirma = (item.KhIdTypKontrahenta == 1) ? Visibility.Visible : Visibility.Collapsed;
            VisibilityOsoba = (item.KhIdTypKontrahenta == 2) ? Visibility.Visible : Visibility.Collapsed;
            CheckFirma = VisibilityFirma == Visibility.Visible ? true : false;
            //To musialem dodac zeby jeszcze raz zwalidowal mi te pola, 
            //przez to ze dodalem !CheckFirma pierwsza walidacja nie dziala poprawnie
            //ja sobie tak lubie zycie komplikować, a pozniej nie wyrabiam sie z projektami ;-)
            OnPropertyChanged(() => Nazwisko);
            OnPropertyChanged(() => Imie);
            
            Debug.WriteLine(CheckFirma);
        }


    }
}
