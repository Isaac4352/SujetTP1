using I19ConfigRessources.ViewModels.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static I19ConfigRessources.ViewModels.Delegates.ViewModelDelegates;

namespace I18nConfigRessources.ViewModels
{
    class DonationViewModel : BaseViewModel
    {
        public DonationViewModel(ViewModelDelegates.MessageErreur erreur, ViewModelDelegates.Question question) : base(erreur, question)
        {
        }
    }
}
