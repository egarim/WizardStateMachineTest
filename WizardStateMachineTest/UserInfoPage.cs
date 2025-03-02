using System;
using System.Linq;

namespace WizardExample
{
    // Real-life implementation: User Registration Wizard

    // Custom page types for our user registration
    public class UserInfoPage : WizardPage
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public UserInfoPage() : base(0, "User Information")
        {
            Description = "Please enter your personal information";
        }

        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(FirstName) ||
                string.IsNullOrWhiteSpace(LastName) ||
                string.IsNullOrWhiteSpace(Email))
            {
                return false;
            }

            // Simple email validation
            IsCompleted = Email.Contains("@") && Email.Contains(".");
            return IsCompleted;
        }
    }
}
