using I18nConfigRessources.Models;
using I18nConfigRessources.ViewModels.Commands;
using I18nConfigRessources.Views;
using I19ConfigRessources.ViewModels.Delegates;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static I19ConfigRessources.ViewModels.Delegates.ViewModelDelegates;

namespace I18nConfigRessources.ViewModels
{
    class DonationViewModel : BaseViewModel
    {
        public ObservableCollection<Contribution> Contributions { 
            get { return contributions; }
            set { contributions = value;  OnPropertyChanged(); } 
        }

        private ObservableCollection<Contribution> contributions;

        private ConfigurationViewModel _configurationViewModel;

        public RelayCommand CmdGotoConfiguration { get; private set; }
        public RelayCommand CmdAjouterListe { get; private set;}
        public RelayCommand CmdEffacerListe { get; private set; }

        public RelayCommand CmdCheckIllegales { get; private set; }
        public AnalyseurContributions Analyseur { get; set; }

        private List<Contribution> illegales;

        public List<Contribution> Illegales
        {
            get { return illegales; }
            set { illegales = value; }
        }



        private string cheminContributionsCSV = "C:\\Users\\isaac\\OneDrive\\Documents\\college\\sujet_speciaux\\I18nConfigRessources\\I18nConfigRessources\\I18nConfigRessources\\Resources\\contributions.csv";
        public DonationViewModel(ViewModelDelegates.MessageErreur erreur, ViewModelDelegates.Question question) : base(erreur, question)
        {
            Analyseur = new AnalyseurContributions();
            //Analyseur.RechercherContributionsPossiblementIllegales();
            Contributions = new ObservableCollection<Contribution>(Analyseur.Contributions);
            //Analyseur.AjouterContributions(cheminContributionsCSV);
            Illegales = Analyseur.RechercherContributionsPossiblementIllegales();
           
            Console.WriteLine(Contributions);
            CmdGotoConfiguration = new RelayCommand(GotoConfiguration, null);
            CmdAjouterListe = new RelayCommand(AjouterListe, null);
            CmdEffacerListe = new RelayCommand(Effacerliste, null);
            CmdCheckIllegales = new RelayCommand(UpdateListe, null);
        }

        private void UpdateListe(object? obj)
        {
            try
            {
                Contributions = new ObservableCollection<Contribution>(Illegales);
            }
            catch(Exception ex)
            {
                _erreur(ex.Message);
            }
              
        
           
        }

        private void GotoConfiguration(object? obj)
        {
            Configuration configuration = new Configuration();
            var window = new Window();
            window.Content = configuration;
            window.Show();
        }

        private void CentrerSurIllegales(object? obj)
        {
            
        }

        private void AjouterListe(object? obj)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Select File";
            openFile.InitialDirectory = "C:\\Users\\isaac\\OneDrive\\Documents\\college\\sujet_speciaux\\I18nConfigRessources\\I18nConfigRessources\\I18nConfigRessources\\Resources";
            openFile.Filter = "CSV files (*.csv)|*.csv|XML files (*.xml)|*.xml";
            openFile.FilterIndex = 1;
            openFile.ShowDialog();
            try
            {
                Analyseur.AjouterContributions(openFile.FileName); //doit tester
                Contributions = new ObservableCollection<Contribution>(Analyseur.Contributions);
            }
            catch(Exception ex) 
            {
                _erreur(ex.Message);
            }
         
        }

        private void Effacerliste(object? obj)
        {
            Contributions.Clear();
        }
        //private void AjouterPersonne(object? obj)
        //{
        //    try
        //    {
        //        this.Personnes.Add(new Personne(Nom, Prenom, Telephone));
        //        InitAjoutModif();
        //    }
        //    catch (Exception ex)
        //    {
        //        _erreur(ex.Message);
        //    }
        //}

        //private void SupprimerTout(object? obj)
        //{
        //    this.Personnes.Clear();
        //    InitAjoutModif();
        //}
    }
}
