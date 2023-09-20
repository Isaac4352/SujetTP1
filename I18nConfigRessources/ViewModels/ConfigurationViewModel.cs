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
    class ConfigurationViewModel : BaseViewModel
    {
        public ConfigurationViewModel(ViewModelDelegates.MessageErreur erreur, ViewModelDelegates.Question question) : base(erreur, question)
        {
        }

    }
}
