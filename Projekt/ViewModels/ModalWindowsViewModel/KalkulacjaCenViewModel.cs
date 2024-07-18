using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Projekt.Helpers;
using Projekt.Models.Entities;
using Projekt.Models.EntitiesForView;
using Projekt.ViewModels.AddViewModels;
using Projekt.Views.AddViews;

namespace Projekt.ViewModels.ModalWindowsViewModel
{
    public class KalkulacjaCenViewModel : JedenViewModel<TwCena>
    {
        #region FieldsAndProperties
        private object Receiver { get; set; }
        private ObservableCollection<CennikForViews> _cennik;
        public ObservableCollection<CennikForViews> Cennik
        {
            get => _cennik;
            set
            {
                _cennik = value;
                OnPropertyChanged(() => Cennik);                
            }
        }

        private decimal _narzut;

        public decimal Narzut
        {
            get { return _narzut; }
            set { _narzut = value; }
        }

        private CennikForViews _selectedItem;

        public CennikForViews SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; }
        }

        #endregion
        //Dwa konstruktory jeden do edycji, drugi do dodania pozycji faktury
        //public KalkulacjaCenViewModel(object receiver) : base("Kalkulacja cen")
        //{
        //    item = new();

        //    Receiver = receiver;
        //}

        public KalkulacjaCenViewModel(object receiver,ObservableCollection<CennikForViews> model) : base("Kalkulacja cen")
        {
            _cennik = model;
            Receiver = receiver;
            KalkulujCenyCommand = new BaseCommand(() => KalkulujCeny());
        }

        protected override string ValidateProperty(string propertyName)
        {
            return default;
            throw new NotImplementedException();
        }

        protected override string ValidateModel()
        {
            return default;
            throw new NotImplementedException();
        }

        public override void Save()
        {
            Messenger.Default.Send(new MessageWithModel<TwCena>(Receiver,item));
        }

        public ICommand KalkulujCenyCommand { get; set; }

        private void KalkulujCeny()
        {

        }
    }
}
