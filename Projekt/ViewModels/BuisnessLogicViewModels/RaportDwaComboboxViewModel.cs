using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Projekt.Helpers;
using Projekt.Models.BuisnessLogic;
using Projekt.Models.Context;
using Projekt.Models.EntitiesForView;
using Projekt.ViewModels.ShowWithoutFkKeyViewModels;

namespace Projekt.ViewModels.BuisnessLogicViewModels
{
    public class RaportDwaComboboxViewModel : WorkspaceViewModel
    {
        protected readonly ProjektDbContext _dbContext;

        #region Konstruktor
        public RaportDwaComboboxViewModel()
        {
            base.DisplayName = "Raport 2x combobox";
            _dbContext = new ProjektDbContext();
            _canExecutePokazDokumenty = false;
            PokazDokumentyCommand = new BaseCommand(() => PokazDokumenty(),()=>_canExecutePokazDokumenty);
            OpenWindowCommand = new BaseCommand(() => OpenWindow());
        }

       

        #endregion

        private bool _canExecutePokazDokumenty;

        #region Command
        public  ICommand PokazDokumentyCommand { get; set; }
        public ICommand OpenWindowCommand { get; set; }
        #endregion

        #region Propertisy
        public IEnumerable<KeyAndValue> KontrahenciComboBoxItems
        {
            get
            {               
                return new KontrahentB(_dbContext).GetKontrahentKeyAndValueItems(); 
            }
        }

        private ObservableCollection<ListDokumentsForView>? _ListaWybranychTowarow;

        public ObservableCollection<ListDokumentsForView>? ListaWybranychTowarow
        {
            get { 
                return _ListaWybranychTowarow; 
            }
            set { 
                _ListaWybranychTowarow = value;
                OnPropertyChanged(() => ListaWybranychTowarow);
            }
        }


        private ObservableCollection<KeyAndValue>? _TowaryComboBoxItems;
        public ObservableCollection<KeyAndValue>? TowaryComboBoxItems
        {
            get { return _TowaryComboBoxItems; }
            set
            {
                //Todo: poprawic zapytanie
                _TowaryComboBoxItems = value;
                OnPropertyChanged(() => TowaryComboBoxItems);
            }
        }
        private int _IdTowaru;

        public int IdTowaru
        {
            get { return _IdTowaru; }
            set { _IdTowaru = value; 
                
                OnPropertyChanged(() => IdTowaru);
                _canExecutePokazDokumenty = TowaryComboBoxItems is null ? false : true;
            }
        }

        private int _idKontrahenta;

        public int IdKontrahenta
        {
            get { return _idKontrahenta; }
            set { 
                _idKontrahenta = value;  
                OnPropertyChanged(() => IdKontrahenta);
                TowaryComboBoxItems = new TowarB(_dbContext).GetTowaryKeyAndValueItems(IdKontrahenta);                
                _canExecutePokazDokumenty = false;              
            }
        }
        #endregion

        private void PokazDokumenty()
        {
            ListaWybranychTowarow = new TowarB(_dbContext).GetTowaryByTowarIdKeyAndValueItems(IdTowaru);
        }

        private void OpenWindow()
        {
            Debug.WriteLine("Otwieram okno");
        }




    }
}
