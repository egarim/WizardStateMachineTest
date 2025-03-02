using System;
using System.Linq;

namespace WizardExample
{
    public class StateTransitionEventArgs : EventArgs
    {
        public WizardPage CurrentPage { get; }
        public WizardPage NextPage { get; }
        public bool Cancel { get; set; }

        public StateTransitionEventArgs(WizardPage currentPage, WizardPage nextPage)
        {
            CurrentPage = currentPage;
            NextPage = nextPage;
            Cancel = false;
        }
    }
}
