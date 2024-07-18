using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Projekt.Helpers;
using Projekt.Models.BuisnessLogic;
using Projekt.Models.Context;
using Projekt.Models.Entities;
using Projekt.Models.EntitiesForView;
using Projekt.ViewModels.AddViewModels;
using Projekt.ViewModels.ModalWindowsViewModel;
using Projekt.Views.AddViews;

namespace Projekt.ViewModels.AddWithFkKeyViewModels
{
    internal class AddTowarViewModel : JedenViewModel<TwTowar>
    {
        GenerowanieCennikaB generowanieCennikaB;
        public AddTowarViewModel() : base("Dodaj towar")
        {
            item = new TwTowar();
            CennikTabelaWDB = new TwCena();
            Cennik = new ObservableCollection<CennikForViews>();
            generowanieCennikaB = new GenerowanieCennikaB(_dbContext);
            generowanieCennikaB.PolaczTabele(Cennik, CennikTabelaWDB);

            Messenger.Default.Register<KhKontrahenciForViews>(this, getWybranyKontrahent);
            Messenger.Default.Register<MessageWithModel<ObservableCollection<CennikForViews>>>(this, item => ReceivePozycjaFaktury(item));
            KalkulujCenyCommand = new BaseCommand(() => KalkulujCeny());
            
        }

        #region Commands

        public ICommand KalkulujCenyCommand { get; set; }

        private BaseCommand _showKontrahenciCommand;

        public ICommand ShowKontrahenciCommand
        {
            get {
                if (_showKontrahenciCommand == null) _showKontrahenciCommand = 
                        new BaseCommand(() => Messenger.Default.Send("KontrahenciShow"));                
                return _showKontrahenciCommand; 
            }            
        }
        #endregion
        private void getWybranyKontrahent(KhKontrahenciForViews kontrahent)
        {
            KontrahentNazwa = kontrahent.Symbol + " " + kontrahent.Name + " " + kontrahent.Adres;
            WIdPodstDostawca = kontrahent.Id;
        }

        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            { //czy istnieje tez tu w osobnej metodzie
                case nameof(Symbol):
                    return Symbol.IsNullOrEmpty() ? "Pole symbol jest wymagane\n" : string.Empty;
                case nameof(Nazwa):
                    return Nazwa.IsNullOrEmpty() ? "Pole nazwa jest wymagane\n" : string.Empty;
                case nameof(KontrahentNazwa):
                    return KontrahentNazwa.IsNullOrEmpty() ? "Pole dostawca jest wymagane\n" : string.Empty;
                case nameof(GrupaTowarow):
                    return GrupaTowarow == 0 ? "Pole grupa towarów\n" : string.Empty;
                default:
                    return string.Empty;
            };
        }

        protected override string ValidateModel()
        {
            string errors = string.Empty;
            //Walidujemy wszystkie propertisy 
            errors += ValidateProperty(nameof(Symbol));
            errors += ValidateProperty(nameof(Nazwa));
            errors += ValidateProperty(nameof(KontrahentNazwa));
            errors += ValidateProperty(nameof(GrupaTowarow));
            return errors;
        }

        #region PropertisyDlaWidoku

        private string _kontrahentNazwa;

        public string KontrahentNazwa
        {
            get { return _kontrahentNazwa; }
            set
            {
                if (_kontrahentNazwa != value)
                {
                    _kontrahentNazwa = value;
                    OnPropertyChanged(() => KontrahentNazwa);                    
                }
            }
        }
        public TwCena CennikTabelaWDB { get; set; }
        public int WIdPodstDostawca
        {
            get
            {
                return item.WIdPodstDostawca;
            }
            set
            {
                if(item.WIdPodstDostawca != value)
                {
                    item.WIdPodstDostawca = value;
                    OnPropertyChanged(()=> WIdPodstDostawca);                    
                }
            }
        }

        public string Symbol
        {
            get
            {
                return item.TwSymbol;
            }
            set
            {
                if (item.TwSymbol != value)
                {
                    item.TwSymbol = value;
                    OnPropertyChanged(() => Symbol);
                }
            }
        }
        public string Nazwa
        {
            get
            {
                return item.TwNazwa;
            }
            set
            {
                if (item.TwNazwa != value)
                {
                    item.TwNazwa = value;
                    OnPropertyChanged(() => Nazwa);
                }
            }
        }
      
        public decimal CenaZakupu
        {
            get { return item.TwCenaZakupu; }
            set
            {
                if (item.TwCenaZakupu != value)
                {
                    item.TwCenaZakupu = value;
                    OnPropertyChanged(() => CenaZakupu);
                }
            }
        }


        public int GrupaTowarow
        {
            get 
            { 
                return item.TwIdGrupa; 
            }
            set 
            { 
                if(item.TwIdGrupa != value)
                {
                    item.TwIdGrupa = value;
                    OnPropertyChanged(()=>  GrupaTowarow);
                }
            }
        }
        private ObservableCollection<CennikForViews> _cennik;
        public ObservableCollection<CennikForViews> Cennik
        {
            get
            {
                return _cennik;
            }
            set
            {
                if (_cennik != value)
                {
                    _cennik = value;
                    OnPropertyChanged(() => Cennik);
                }
            }
        }




        public IEnumerable<KeyAndValue> GrupaTowarowComboBoxItems
        {
            get
            {
                return
                (
                        from grupaTowarow in _dbContext.SlGrupaTws
                        select new KeyAndValue
                        {
                            Key=grupaTowarow.GrtId,
                            Value=grupaTowarow.GrtNazwa
                        }
                ).ToList();
            }
        }
        
        private void KalkulujCeny()
        {
            WindowManager.OpenModalWindow(new KalkulacjaCenViewModel(this, Cennik));
        }

        private void ReceivePozycjaFaktury(MessageWithModel<ObservableCollection<CennikForViews>> message)
        {
            if (message.Receipent == this)
            {
                //Aktualizacja widoku zawarosci cennika
                //Czy musze ponownie wygenerowac Cennik?
                // generowanieCennikaB.PolaczTabele(Cennik, CennikTabelaWDB);
                CollectionViewSource.GetDefaultView(Cennik).Refresh();
                //if (PozycjeFaktury.Contains(message.Model))
                //{
                //    ObservableCollection<PozycjaFaktury> temp = PozycjeFaktury;
                //    PozycjeFaktury = new();
                //    PozycjeFaktury = temp;
                //}
                //else
                //{
                //    PozycjeFaktury.Add(message.Model);
                //}
            }
        }

        public override void Save()
        {
           // PozycjeFaktury.ToList().ForEach(x => item.PozycjaFakturies.Add(x));
            base.Save();
        }

        #endregion
    }
}
