using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Projekt.Helpers;
using Projekt.Models.Entities;
using Projekt.ViewModels.AddViewModels;
using Projekt.ViewModels.AddWithFkKeyViewModels;
using Projekt.ViewModels.BuisnessLogicViewModels;
using Projekt.ViewModels.ChoiceWindowsViewModel;
using Projekt.ViewModels.ShowWithFkKeyViewModels;
using Projekt.ViewModels.ShowWithoutFkKeyViewModels;
using Projekt.Views;

namespace Projekt.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {

        #region CommandsMenu
        //

        //public ICommand TwTowarCmd => new BaseCommand(ShowTab<TwTowarViewModel>);
        //public ICommand TwCenaCmd => new BaseCommand(ShowTab<TwCenaViewModel>);




        #endregion
        //
        #region Commands


        private ReadOnlyCollection<CommandViewModel> _DodajZFkCommands;
        public ReadOnlyCollection<CommandViewModel> DodajZFkCommands
        {
            get
            {
                if (_DodajZFkCommands == null)
                {
                    //
                    List<CommandViewModel> cmds = ListaDodajlZFkCommands();
                    //i ...
                    _DodajZFkCommands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _DodajZFkCommands;
            }
        }
        private List<CommandViewModel> ListaDodajlZFkCommands()
        {
            Messenger.Default.Register<string>(this, open);
            return new List<CommandViewModel>
            {
                //dodac dodawanie z FK
                new CommandViewModel("Dodaj towar",new BaseCommand(ShowTab<AddTowarViewModel>)),
                new CommandViewModel("Dodaj dokument",new BaseCommand(ShowTab<AddDokumentViewModel>)),
                new CommandViewModel("Dodaj kontrahenta",new BaseCommand(ShowTab<AddKontrahentViewModel>))
               };
        }
        private void open(string name)
        {
            if (name == "KontrahenciShow") ShowTab<ChooseKontrahentViewModel>();
            if (name == "TowaryShow") ShowTab<ChooseTowarViewModel>();
        }


        #region Command WyswietlLogikeBiznesowa

        private ReadOnlyCollection<CommandViewModel> _WyswietlLogikeBiznesowaCommands;
        public ReadOnlyCollection<CommandViewModel> WyswietlLogikeBiznesowaCommands
        {
            get
            {
                if (_WyswietlLogikeBiznesowaCommands == null)
                {
                    //
                    List<CommandViewModel> cmds = ListaWyswietlLogikeBiznesowaCommands();
                    //i ...
                    _WyswietlLogikeBiznesowaCommands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _WyswietlLogikeBiznesowaCommands;
            }
        }
        private List<CommandViewModel> ListaWyswietlLogikeBiznesowaCommands()
        {
            return new List<CommandViewModel>
            {
                //tu decyduje 
                new CommandViewModel("Pierwsza logika",new BaseCommand(ShowTab<FirstBuisnessLogicViewModel>)),
                new CommandViewModel("Raport sprzedazy 1",new BaseCommand(ShowTab<RaportSprzedazyViewModel>)),
                new CommandViewModel("Raport sprzedazy 2",new BaseCommand(ShowTab<RaportSprzedazDostawcyViewModel>)),
                new CommandViewModel("Raport sprzedazy 4",new BaseCommand(ShowTab<RaportSprzedazyCzteryViewModel>)),
                new CommandViewModel("Raport 2x combobox",new BaseCommand(ShowTab<RaportDwaComboboxViewModel>)),
            };
        }


        #endregion

        private ReadOnlyCollection<CommandViewModel> _WyswietlZFkCommands;
        public ReadOnlyCollection<CommandViewModel> WyswietlZFkCommands
        {
            get
            {
                if (_WyswietlZFkCommands == null)
                {
                    //
                    List<CommandViewModel> cmds = ListaWyswietlZFkCommands();
                    //i ...
                    _WyswietlZFkCommands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _WyswietlZFkCommands;
            }
        }
        private List<CommandViewModel> ListaWyswietlZFkCommands()
        {
            return new List<CommandViewModel>
            {
                //tu decyduje 
                new CommandViewModel("Wszystkie towary",new BaseCommand(ShowTab<WszystkieTowaryViewModel>)),
                new CommandViewModel("Wszyscy kontrahenci",new BaseCommand(ShowTab<WszyscyKontrahenciViewModel>)),
                new CommandViewModel("Wszystkie ewidencje",new BaseCommand(ShowTab<WszystkieEwidencjeViewModel>)),
                new CommandViewModel("Wszystkie dokumenty",new BaseCommand(ShowTab<WszystkieDokumentyViewModel>))
            };
        }

        private ReadOnlyCollection<CommandViewModel> _WyswietlBezFkCommands;
        public ReadOnlyCollection<CommandViewModel> WyswietlBezFkCommands
        {
            get
            {
                if (_WyswietlBezFkCommands == null)
                {
                    //
                    List<CommandViewModel> cmds = ListaWyswietlBezFkCommands();
                    //i ...
                    _WyswietlBezFkCommands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _WyswietlBezFkCommands;
            }
        }
        private List<CommandViewModel> ListaWyswietlBezFkCommands()
        {          
            return new List<CommandViewModel>
            {
                //tu decyduje 
                 new CommandViewModel("Wyswietl slownik wojewodztwa",new BaseCommand(ShowTab<ShowSlWojewodztwoViewModel>)),
                new CommandViewModel("Wyswietl slownik pola własne",new BaseCommand(ShowTab<ShowSlPolaWlasnieViewModel>)),
                new CommandViewModel("Wyswietl slownik państwa",new BaseCommand(ShowTab<ShowSlPanstwoViewModel>)),
                new CommandViewModel("Wyswietl slownik magazyny",new BaseCommand(ShowTab<ShowSlMagazynViewModel>)),
                new CommandViewModel("Wyswietl slownik kategoria dokumentów",new BaseCommand(ShowTab<ShowSlKategoriaDokumentuViewModel>)),
                new CommandViewModel("Wyswietl slownik grupa towarów",new BaseCommand(ShowTab<ShowSlGrupaTwViewModel>)),
                new CommandViewModel("Wyswietl slownik grupa kontrahentów",new BaseCommand(ShowTab<ShowSlGrupaKhViewModel>)),
                new CommandViewModel("Wyswietl slownik cecha towarów",new BaseCommand(ShowTab<ShowSlCechaTwViewModel>)),
               // new CommandViewModel("TwCenaView",new BaseCommand(ShowTab<TwCenaViewModel>)),
            };
        }


        private ReadOnlyCollection<CommandViewModel> _ListSlownikowCommand;
        public ReadOnlyCollection<CommandViewModel> ListSlownikowCommand
        {
            get
            {
                if (_ListSlownikowCommand == null)
                {
                    //
                    List<CommandViewModel> cmds = CreateListSlownikowCommands();
                    //i ...
                    _ListSlownikowCommand = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _ListSlownikowCommand;
            }
        }
        private List<CommandViewModel> CreateListSlownikowCommands()
        {
            //tworze....
            return new List<CommandViewModel>
            {
                new CommandViewModel("Dodaj wojewodztwo",new BaseCommand(ShowTab<AddSlWojewodztwoViewModel>)),
                new CommandViewModel("Dodaj pole wlasne",new BaseCommand(ShowTab<AddSlPolaWlasneViewModel>)),
                new CommandViewModel("Dodaj panstwo",new BaseCommand(ShowTab<AddSlPanstwoViewModel>)),
                new CommandViewModel("Dodaj magazyn",new BaseCommand(ShowTab<AddSlMagazynViewModel>)),
                new CommandViewModel("Dodaj kategorie",new BaseCommand(ShowTab<AddSlKategoriaDokumentuViewModel>)),
                new CommandViewModel("Dodaj grupę towarów",new BaseCommand(ShowTab<AddSlGrupaTwViewModel>)),
                new CommandViewModel("Dodaj grupę kontrahentów",new BaseCommand(ShowTab<AddSlGrupaKhViewModel>)),
                new CommandViewModel("Dodaj ceche towarow",new BaseCommand(ShowTab<AddSlCechaTwViewModel>)),

            };

        }
        #endregion
        #region Workspaces
        //
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.onWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        #endregion


        #region Zakładki
        private void onWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.onWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.onWorkspaceRequestClose;
        }
        private void onWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }
        #endregion

        #region Funkcje wywolu.....
        private void ShowTab<T>() where T : WorkspaceViewModel, new()
        {
            T workspace = Workspaces.FirstOrDefault(vm => vm is T)
                as T;
            if (workspace == null)
            {
                workspace = new T();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }   

        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        #endregion




    }
}
