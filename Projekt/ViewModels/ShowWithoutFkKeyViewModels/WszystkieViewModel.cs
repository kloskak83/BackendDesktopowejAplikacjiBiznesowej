using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Projekt.Helpers;
using Projekt.Models.Context;
using Projekt.ViewModels.ShowWithoutFkKeyViewModels;

namespace Projekt.ViewModels
{
    //To jest klasa z ktorej beda dziedziczyc wszystkie viewModele "typu wszystkie"
    abstract public class WszystkieViewModel<T> : WorkspaceViewModel
    {
        #region DB
        protected readonly ProjektDbContext _dbContext;
        #endregion
        #region Command
        private BaseCommand _LoadCommand;

        private BaseCommand _SortCommand;
        private BaseCommand _FindCommand;

        public string SortField { get; set; }
        public List<string> SortComboboxItems
        {
            get
            {
                return getComboboxSortList();
            }
        }
        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                {
                    _SortCommand = new BaseCommand(() => sort());
                }
                return _SortCommand;
            }
        }
        public string FindField { get; set; }
        public string FindTextBox { get; set; }
        public List<string> FindComboboxItems
        {
            get
            {
                return getComboboxFindList();
            }
        }

        public abstract void sort();
        public abstract List<String> getComboboxSortList();

        public abstract void find();
        public abstract List<String> getComboboxFindList();


        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null)
                {
                    _FindCommand = new BaseCommand(() => find());
                }
                return _FindCommand;
            }
        }




        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                    _LoadCommand = new BaseCommand(() => load()); ;
                return _LoadCommand;
            }
        }
        #endregion
        #region Kolekcja
        
        private ObservableCollection<T> _list;
        public ObservableCollection<T> List
        {
            get
            {
                if (_list == null)
                    load();
                return _list;
            }
            set
            {
                _list = value;
                OnPropertyChanged(() => List);
            }

        }
        #endregion
        public WszystkieViewModel(string displayName)
        {
            base.DisplayName = displayName;//to jest ustawienie nazwy zkładki
            _dbContext = new ProjektDbContext();
        }
        //pri konwerten ma zwracan napis dodac metode i komende modyfikuj
        public bool CzyDoWybraniaModelu { get; set; }

        public abstract void load();
    }
}

