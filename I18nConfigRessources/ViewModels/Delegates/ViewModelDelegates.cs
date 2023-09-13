using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I19ConfigRessources.ViewModels.Delegates
{
    public class ViewModelDelegates
    {
        public delegate void MessageErreur(string msgErreur);
        public delegate bool Question(string question);
    }
}
