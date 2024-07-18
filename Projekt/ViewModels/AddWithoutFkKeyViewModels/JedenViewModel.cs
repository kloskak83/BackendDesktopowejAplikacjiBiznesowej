using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Projekt.Helpers;
using Projekt.Models.Context;
using Projekt.ViewModels.ShowWithoutFkKeyViewModels;

namespace Projekt.ViewModels.AddViewModels
{
    public abstract class JedenViewModel<T> : WorkspaceViewModel, IDataErrorInfo
    {
        #region DB

        protected ProjektDbContext _dbContext;
        //Poiwnien byc properties ale z lenistwa jest pole
        protected T item;
        #endregion

        #region Commands
        //_ oznacze ze bedzie properties
        private BaseCommand _SaveAndCloseCommand;
        //podpina komende ktora wywola funkcje!!!
        public ICommand SaveAndCloseCommand
        {
            get
            {
                if (_SaveAndCloseCommand == null)
                    _SaveAndCloseCommand = new BaseCommand(SaveAndClose);
                return _SaveAndCloseCommand;
            }
        }
        public JedenViewModel(string displayName)
        {
            base.DisplayName = displayName;//to jest ustawienie nazwy zkładki
            _dbContext = new ProjektDbContext();
        }


        public string Error => string.Empty;
        //wywolany w momencie wypelnienia 
        public string this[string columnName] => ValidateProperty(columnName);
        
        #endregion


        /// <summary>
        /// Waliduje property
        /// </summary>
        /// <param name="propertyName">Nazwa property </param>
        /// <returns>Zwraca tekst bledu lub <see cref="string.Empty"></see></returns>
        protected abstract string ValidateProperty(string propertyName);
        protected abstract string ValidateModel();


        #region Pomocniczy
        //Funkcja zapisuje do bazydanych
        public virtual void Save()
        {           
            _dbContext.Add(item);
            _dbContext.SaveChanges();
        }

        private void SaveAndClose()
        {
            string errors = ValidateModel();
            if (!errors.IsNullOrEmpty())
            {
                MessageBox.Show(App.Current.MainWindow, errors, "Blad");
                return;
            }

            try
            {
                Save();
                OnRequestClose();
            }
            catch (DbUpdateConcurrencyException)
            {
                MessageBox.Show(App.Current.MainWindow, "Wykryto konkurencyjny zapis do DB", "Blad");
            }
            catch (DbUpdateException)
            {
                MessageBox.Show(App.Current.MainWindow, "Blad zapisu do bazy ", "Blad");
            }
           

        }
        #endregion
    }
}
