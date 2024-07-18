using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Projekt.ViewModels
{
    //
    public class CommandViewModel:BaseViewModel
    {
        //ka...
        #region Properties
        public string  DisplayName { get; set; }
        public ICommand Command { get; set; }
        #endregion
        #region Konstruktor
        public CommandViewModel(string displayName,ICommand command)
        {
            DisplayName = displayName;  
            Command = command;
        }
        #endregion
    }
}
