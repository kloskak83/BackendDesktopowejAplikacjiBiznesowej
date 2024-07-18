using Projekt.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Projekt.ViewModels.ShowWithoutFkKeyViewModels
{
    //to jest VM
    //każda 
    public class WorkspaceViewModel : BaseViewModel
    {
        //kaz    
        #region Pola i właściwosci
        public string DisplayName { get; set; }//to jest nazwa zakładki
        private BaseCommand _CloseCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                    _CloseCommand = new BaseCommand(OnRequestClose);//komenada...
                return _CloseCommand;
            }
        }
        #endregion
        #region RequestClose [event]
        public event EventHandler RequestClose;
        protected void OnRequestClose()
        {
            EventHandler handler = RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        #endregion

    }
}
