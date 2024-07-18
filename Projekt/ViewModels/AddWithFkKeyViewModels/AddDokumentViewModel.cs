using GalaSoft.MvvmLight.Messaging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Projekt.Helpers;
using Projekt.Models.Entities;
using Projekt.Models.EntitiesForView;
using Projekt.ViewModels.AddViewModels;
using Projekt.Views.AddViews;

namespace Projekt.ViewModels.AddWithFkKeyViewModels
{
    internal class AddDokumentViewModel : JedenViewModel<DokDokument>
    {
        //WybranyKontrahent - string z danymi kontrahenta
        public AddDokumentViewModel() : base("Dodaj dokument")
        {
            
            item = new DokDokument();
            DateTime dzisiaj = DateTime.Now;
            item.DokDataWyst = dzisiaj;
           
            Messenger.Default.Register<KhKontrahenciForViews>(this, getWybranyKontrahent);
            Messenger.Default.Register<TwTowarForViewsAddFaktura>(this, getWybranyTowar);
            Towary = new ObservableCollection<TwTowarForViewsAddFaktura>();
            {
                //{
                //    new TwTowarForViewsAddFaktura()
                //    {
                //        Id = 1,
                //        Symbol = "Test",
                //        Nazwa = "nazwa testowa",
                //        Cena = 3,
                //        Ilosc = 1
                //    }
                //};
            }
            DeleteTowarCommand = new BaseCommand(() => DeleteTowar());

           // UpDateSelectedTowarCommand = new BaseCommand(() => UpdateListyZTowarami());

        }





        private BaseCommand _showKontrahenciCommand;

        public ICommand ShowKontrahenciCommand
        {
            get
            {
                if (_showKontrahenciCommand == null) _showKontrahenciCommand =
                        new BaseCommand(() => Messenger.Default.Send("KontrahenciShow"));

                return _showKontrahenciCommand;
            }

        }

        public ICommand DeleteTowarCommand { get; set; }

        public ICommand UpDateSelectedTowarCommand { get; set; }

        private BaseCommand _showTowaryCommand;

        public ICommand ShowTowaryCommand
        {
            get
            {
                if (_showTowaryCommand == null) _showTowaryCommand =
                        new BaseCommand(() => Messenger.Default.Send("TowaryShow"));

                return _showTowaryCommand;
            }

        }

        private void getWybranyTowar(TwTowarForViewsAddFaktura towar)
        {
            //To sie dodaje do listy na widoku
            Towary.Add(towar);
            
            ////To sie dodaje do listy na items
            //item.DkPozycjeNaDokumencies.Add(new DkPozycjeNaDokumencie()
            //{
            //    DkpIdTowaru = towar.Id,
            //    DkpIdDokumentu = item.DokId,
            //    DkpIlosc = towar.Ilosc,
            //    TcCenaNettNaDokumencie = towar.Cena,
                
            //});

        }

        private void getWybranyKontrahent(KhKontrahenciForViews kontrahent)
        {
            WybranyKontrahent = kontrahent.Symbol + " " + kontrahent.Name + "\n" + kontrahent.Adres;
            item.DokOdbiorcaId = kontrahent.Id;
        }
        #region Walidacja danych        
        protected override string ValidateProperty(string propertyName)
        {
           switch(propertyName)
            {
                //Walidujemy interesujące nas proprerty (tutaj WybranyKontrahent)
                case nameof(WybranyKontrahent) :
                    return WybranyKontrahent.IsNullOrEmpty() ? "Nie wybrano kontrahenta\n" : string.Empty;
                case nameof(NumerDokumentu):
                    return NumerDokumentu.IsNullOrEmpty() ? "Nie podano nr dokumentu\n" : string.Empty;
                case nameof(Towary):
                    return Towary.IsNullOrEmpty() ? "Nie wybrano towaru\n" : string.Empty;
                case nameof(DataDokumentu):
                    return DataDokumentu == default(DateTime) ? "Nie podano daty\n" : string.Empty;
                case nameof(RodzajDokumentu):
                    return RodzajDokumentu == 0 ? "Nie wybrano rodzaju dokumentu\n" : string.Empty;
                case nameof(Magazyn):
                    return Magazyn == 0 ? "Nie wybrano magazynu\n" : string.Empty;
                default: 
                    return string.Empty;
            }
        }
        protected override string ValidateModel()
        {
            string errors = string.Empty;
            errors += ValidateProperty(nameof(WybranyKontrahent));
            errors += ValidateProperty(nameof(NumerDokumentu));
            errors += ValidateProperty(nameof(Towary));
            errors += ValidateProperty(nameof(DataDokumentu));
            errors += ValidateProperty(nameof(RodzajDokumentu));
            errors += ValidateProperty(nameof(Magazyn));            
            return errors;
        }

        public override void Save()
        {
            foreach (var towar in Towary)
            {
                item.DkPozycjeNaDokumencies.Add(new DkPozycjeNaDokumencie()
                {
                    DkpIdTowaru = towar.Id,
                    DkpIdDokumentu = item.DokId,
                    DkpIlosc = towar.Ilosc,
                    TcCenaNettNaDokumencie = towar.Cena
                });
            }
            base.Save();
        }

        private void DeleteTowar()
        {
            Towary.Remove(Towar);
        }


        #endregion

        #region PropertisyDlaWidoku

        public ObservableCollection<TwTowarForViewsAddFaktura> Towary { get; set; }

        private string _wybranyKontrahent;

        public string WybranyKontrahent
        {
            get { return _wybranyKontrahent; }
            set
            {
                if (_wybranyKontrahent != value)
                {
                    _wybranyKontrahent = value;
                    OnPropertyChanged(() => WybranyKontrahent);
                }
            }
        }

        public DateTime DataDokumentu
        {
            get
            {
                return item.DokDataWyst;
            }
            set
            {
                if (item.DokDataWyst != value)
                {
                    item.DokDataWyst = value;
                    OnPropertyChanged(() => DataDokumentu);
                }
            }
        }

        //public int? IdSposobuPlatnosci
        //{
        //    get
        //    {
        //        return item.IdSposobuPlatnosci;
        //    }
        //    set
        //    {
        //        if (item.IdSposobuPlatnosci != value)
        //        {
        //            item.IdSposobuPlatnosci = value;
        //            OnPropertyChanged(() => IdSposobuPlatnosci);
        //        }
        //    }
        //}
        public int RodzajDokumentu
        {
            get
            {
                return item.DokKategoriaDokumentuId;
            }
            set
            {
                if(item.DokKategoriaDokumentuId != value)
                {
                    item.DokKategoriaDokumentuId = value;
                    OnPropertyChanged(()=>  RodzajDokumentu);
                }
            }
        }

        public IEnumerable<KeyAndValue> RodzajDokumentuComboBoxItems
        {
            get
            {
                return
                    (
                        from rodzajDokumentu in _dbContext.SlKategoriaDokumentus
                        select new KeyAndValue
                        {
                            Key=rodzajDokumentu.KdId,
                            Value=rodzajDokumentu.KdNazwa
                        }
                    ).ToList();
            }
        }

        public string NumerDokumentu
        {
            get 
            { 
                return item.DokTytul; 
            }
            set 
            { 
                if( item.DokTytul != value)
                {
                    item.DokTytul = value;
                    OnPropertyChanged(()=>  NumerDokumentu);
                }
            }
        }

        public int Magazyn
        {
            get
            {
                return item.DokMagId;
            }
            set
            {
                if (item.DokMagId != value)
                {
                    item.DokMagId = value;
                    OnPropertyChanged(() => Magazyn);
                }
            }
        }

        public IEnumerable<KeyAndValue> MagazynComboBoxItems
        {
            get
            {
                return
                    (
                        from magazyn in _dbContext.SlMagazyns
                        select new KeyAndValue
                        {
                            Key = magazyn.MagId,
                            Value = magazyn.MagNazwa
                        }
                    ).ToList();
            }
        }



        #endregion

        #region Propertisy i pola

        private TwTowarForViewsAddFaktura _towar;
        public TwTowarForViewsAddFaktura Towar 
        { 
            get { return _towar; } 
            set { _towar = value; 
                OnPropertyChanged(() => Towar); 
               }
        }


        #endregion
    }
}
