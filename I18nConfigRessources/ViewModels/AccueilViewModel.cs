using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static I19ConfigRessources.ViewModels.Delegates.ViewModelDelegates;

namespace I18nConfigRessources.ViewModels
{
    public class AccueilViewModel : BaseViewModel
    {
        public AccueilViewModel(MessageErreur erreur, Question question) : base(erreur, question) { }
    }
}
