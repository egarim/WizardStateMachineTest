using System;
using System.Linq;

namespace WizardExample
{
    public class SummaryPage : WizardPage
    {
        public SummaryPage() : base(3, "Summary")
        {
            Description = "Review your information before completing registration";
            // Summary page is always completed
            IsCompleted = true;
        }
    }
}
