using I18nConfigRessources.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static I19ConfigRessources.ViewModels.Delegates.ViewModelDelegates;

namespace I18nConfigRessources.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _viewModelActuel;
        private AccueilViewModel _accueilViewModel;
        private PersonneViewModel _personneViewModel;

        public MainViewModel(MessageErreur erreur, Question question) : base(erreur, question)
        {
            _accueilViewModel = new AccueilViewModel(erreur, question);
            _personneViewModel = new PersonneViewModel(erreur, question);
            _viewModelActuel = _personneViewModel;
            CmdGotoAccueil = new RelayCommand(GotoAccueil, null);
            CmdGotoPersonne = new RelayCommand(GotoPersonne, null);
            CmdChangerLangue = new RelayCommand(ChangerLangue, null);
        }

        private void ChangerLangue(object? obj)
        {
            I18nConfigRessources.Properties.Settings.Default.langue = obj as string;
            I18nConfigRessources.Properties.Settings.Default.Save();

            if (_question(I18nConfigRessources.Properties.traduction.msg_confirmation_redemarrage))
            {
                //System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                System.Diagnostics.Process.Start(fileName: Environment.ProcessPath);
                Application.Current.Shutdown();
            }
        }

        private void GotoAccueil(object? obj)
        {
            ViewModelActuel = _accueilViewModel;
        }

        private void GotoPersonne(object? obj)
        {
            ViewModelActuel = _personneViewModel;
        }

        public RelayCommand CmdGotoAccueil { get; private set; }

        public RelayCommand CmdGotoPersonne { get; private set; }

        public RelayCommand CmdChangerLangue { get; private set; }

        public BaseViewModel ViewModelActuel
        {
            get { return _viewModelActuel; }
            set
            {
                _viewModelActuel = value;
                OnPropertyChanged();
            }
        }
    }
}
