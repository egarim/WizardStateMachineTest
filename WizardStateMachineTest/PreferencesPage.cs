using System;
using System.Linq;

namespace WizardExample
{
    public class PreferencesPage : WizardPage
    {
        public bool ReceiveNewsletter { get; set; }
        public bool AgreeToTerms { get; set; }

        public PreferencesPage() : base(2, "Preferences")
        {
            Description = "Set your account preferences";
        }

        public override bool Validate()
        {
            // Terms must be agreed to
            IsCompleted = AgreeToTerms;
            return IsCompleted;
        }
    }
}
