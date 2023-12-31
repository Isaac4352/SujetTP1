﻿using I18nConfigRessources.Models;
using I18nConfigRessources.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using static I19ConfigRessources.ViewModels.Delegates.ViewModelDelegates;

namespace I18nConfigRessources.ViewModels
{
    public class PersonneViewModel : BaseViewModel
    {
        private Personne? _personneSelectionnee = null;
        private string _nom;
        private string _prenom;
        private string _telephone;
        private bool _modeAjout;

        public PersonneViewModel(MessageErreur erreur, Question question) : base(erreur, question)
        {
            this.Personnes = new ObservableCollection<Personne>();

            string csv = I18nConfigRessources.Properties.AutresRessources.contacts;
            string[] lignes = csv.Split("\n");
            foreach (string ligne in lignes)
            {
                string[] champs = ligne.Split(';');
                this.Personnes.Add(new Personne(champs[0].Trim(), champs[1].Trim(), champs[2].Trim()));
            }

            Nom = string.Empty;
            Prenom = string.Empty;
            Telephone = string.Empty;
            ModeAjout = true;

            CmdAjouterPersonne = new RelayCommand(AjouterPersonne, null);
            CmdModifierPersonne = new RelayCommand(ModifierPersonne, null);
            CmdAnnuler = new RelayCommand(Annuler, null);
            CmdSupprimerPersonne = new RelayCommand(SupprimerPersonne, null);
            CmdSupprimerTout = new RelayCommand(SupprimerTout, null);
        }

        private void AjouterPersonne(object? obj)
        {
            try
            {
                this.Personnes.Add(new Personne(Nom, Prenom, Telephone));
                InitAjoutModif();
            }
            catch (Exception ex)
            {
                _erreur(ex.Message);
            }
        }

        private void SupprimerTout(object? obj)
        {
            this.Personnes.Clear();
            InitAjoutModif();
        }

        private void SupprimerPersonne(object? obj)
        {
            if (PersonneSelectionnee != null)
            {
                this.Personnes.Remove(PersonneSelectionnee);
            }
            InitAjoutModif();
        }

        private void ModifierPersonne(object? obj)
        {
            if (PersonneSelectionnee != null)
            {
                try
                {
                    this.PersonneSelectionnee.Nom = Nom;
                    this.PersonneSelectionnee.Prenom = Prenom;
                    this.PersonneSelectionnee.Telephone = Telephone;
                    InitAjoutModif();
                }
                catch (Exception ex)
                {
                    _erreur(ex.Message);
                }
            }
        }

        private void Annuler(object? obj)
        {
            InitAjoutModif();
        }

        private void InitAjoutModif()
        {
            Nom = string.Empty;
            Prenom = string.Empty;
            Telephone = string.Empty;
            ModeAjout = true;
        }

        public RelayCommand CmdAjouterPersonne { get; private set; }

        public RelayCommand CmdModifierPersonne { get; private set; }

        public RelayCommand CmdAnnuler { get; private set; }

        public RelayCommand CmdSupprimerPersonne { get; private set; }

        public RelayCommand CmdSupprimerTout { get; private set; }

        public ObservableCollection<Personne> Personnes { get; set; }

        public Personne? PersonneSelectionnee
        {
            get { return _personneSelectionnee; }
            set
            {
                if (value != null)
                {
                    _personneSelectionnee = value;
                    Nom = _personneSelectionnee.Nom;
                    Prenom = _personneSelectionnee.Prenom;
                    Telephone = _personneSelectionnee.Telephone;
                    ModeAjout = false;
                    OnPropertyChanged();
                }
            }
        }

        public string Nom
        {
            get { return _nom; }
            set
            {
                _nom = value;
                OnPropertyChanged();
            }
        }

        public string Prenom
        {
            get { return _prenom; }
            set
            {
                _prenom = value;
                OnPropertyChanged();
            }
        }

        public string Telephone
        {
            get { return _telephone; }
            set
            {
                _telephone = value;
                OnPropertyChanged();
            }
        }

        public bool ModeAjout
        {
            get { return _modeAjout; }
            set
            {
                _modeAjout = value;
                OnPropertyChanged();
            }
        }
    }
}
