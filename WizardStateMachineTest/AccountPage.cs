using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace WizardExample
{

    public class AccountPage : WizardPage
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public AccountPage() : base(1, "Account Setup")
        {
            Description = "Create your account credentials";
        }

        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Username) ||
                string.IsNullOrWhiteSpace(Password) ||
                string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                return false;
            }

            if (Password != ConfirmPassword)
            {
                return false;
            }

            // Password must be at least 8 characters
            IsCompleted = Password.Length >= 8;
            return IsCompleted;
        }
    }
}
