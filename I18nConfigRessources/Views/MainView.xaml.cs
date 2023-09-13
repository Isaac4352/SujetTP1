using I18nConfigRessources.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace I18nConfigRessources.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel(AfficherMessageErreur, PoserQuestion);
        }


        public void AfficherMessageErreur(string msg)
        { 
            MessageBox.Show(msg, I18nConfigRessources.Properties.traduction.titre_erreur, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public bool PoserQuestion(string question)
        {
            var resultat = MessageBox.Show(question, I18nConfigRessources.Properties.traduction.titre_question, MessageBoxButton.YesNo, MessageBoxImage.Question);
            return resultat == MessageBoxResult.Yes;
        }
    }
}
