using System;
using System.Linq;

namespace WizardExample
{
    // The concrete implementation of our wizard
    public class UserRegistrationWizard : WizardStateMachineBase
    {
        public UserInfoPage UserInfoPage { get; }
        public AccountPage AccountPage { get; }
        public PreferencesPage PreferencesPage { get; }
        public SummaryPage SummaryPage { get; }

        public UserRegistrationWizard() : base(new List<WizardPage>())
        {
            // Create our pages
            UserInfoPage = new UserInfoPage();
            AccountPage = new AccountPage();
            PreferencesPage = new PreferencesPage();
            SummaryPage = new SummaryPage();

            // Add pages to the base collection
            _pages.Add(UserInfoPage);
            _pages.Add(AccountPage);
            _pages.Add(PreferencesPage);
            _pages.Add(SummaryPage);

            // Make sure pages are ordered correctly
            _pages.Sort((a, b) => a.Index.CompareTo(b.Index));

            // Add validation on transitions
            StateTransition += OnValidateTransition;
        }

        private void OnValidateTransition(object sender, StateTransitionEventArgs e)
        {
            // When moving forward, validate the current page
            if (e.CurrentPage.Index < e.NextPage.Index)
            {
                if (!e.CurrentPage.Validate())
                {
                    e.Cancel = true;
                }
            }
        }

        public bool RegisterUser()
        {
            // In a real application, this would save the user to a database
            if (IsLastPage &&
                UserInfoPage.IsCompleted &&
                AccountPage.IsCompleted &&
                PreferencesPage.IsCompleted)
            {
                // Registration logic would go here
                Console.WriteLine($"User registered: {UserInfoPage.FirstName} {UserInfoPage.LastName}");
                return true;
            }
            return false;
        }
    }
}
