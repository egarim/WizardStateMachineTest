using System;
using System.Linq;

// NUnit tests for our wizard implementation
namespace WizardExample.Tests
{
    [TestFixture]
    public class UserRegistrationWizardTests
    {
        [Test]
        public void WizardInitialState_FirstPageSelected()
        {
            // Arrange
            var wizard = new UserRegistrationWizard();

            // Assert
            Assert.That(wizard.CurrentPage, Is.EqualTo(wizard.UserInfoPage));
            Assert.That(wizard.IsFirstPage, Is.True);
            Assert.That(wizard.IsLastPage, Is.False);
        }

        [Test]
        public void MoveNext_EmptyUserInfo_StaysOnFirstPage()
        {
            // Arrange
            var wizard = new UserRegistrationWizard();

            // Act
            bool result = wizard.MoveNext();

            // Assert
            Assert.That(result, Is.False);
            Assert.That(wizard.CurrentPage, Is.EqualTo(wizard.UserInfoPage));
        }

        [Test]
        public void MoveNext_ValidUserInfo_MovesToAccountPage()
        {
            // Arrange
            var wizard = new UserRegistrationWizard();
            wizard.UserInfoPage.FirstName = "John";
            wizard.UserInfoPage.LastName = "Doe";
            wizard.UserInfoPage.Email = "john.doe@example.com";

            // Act
            bool result = wizard.MoveNext();

            // Assert
            Assert.That(result, Is.True);
            Assert.That(wizard.CurrentPage, Is.EqualTo(wizard.AccountPage));
        }

        [Test]
        public void MoveNext_PasswordMismatch_StaysOnAccountPage()
        {
            // Arrange
            var wizard = new UserRegistrationWizard();
            SetupValidUserInfo(wizard);
            wizard.MoveNext();

            wizard.AccountPage.Username = "johndoe";
            wizard.AccountPage.Password = "password123";
            wizard.AccountPage.ConfirmPassword = "password456"; // Mismatch

            // Act
            bool result = wizard.MoveNext();

            // Assert
            Assert.That(result, Is.False);
            Assert.That(wizard.CurrentPage, Is.EqualTo(wizard.AccountPage));
        }

        [Test]
        public void CompleteWizard_AllValid_ReachesLastPage()
        {
            // Arrange
            var wizard = new UserRegistrationWizard();
            CompleteAllPages(wizard);

            // Assert
            Assert.That(wizard.CurrentPage, Is.EqualTo(wizard.SummaryPage));
            Assert.That(wizard.IsLastPage, Is.True);
        }

        [Test]
        public void RegisterUser_AllPagesCompleted_ReturnsTrue()
        {
            // Arrange
            var wizard = new UserRegistrationWizard();
            CompleteAllPages(wizard);

            // Act
            bool result = wizard.RegisterUser();

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void MovePrevious_FromSecondPage_ReturnsToFirstPage()
        {
            // Arrange
            var wizard = new UserRegistrationWizard();
            SetupValidUserInfo(wizard);
            wizard.MoveNext();
            Assert.That(wizard.CurrentPage, Is.EqualTo(wizard.AccountPage));

            // Act
            bool result = wizard.MovePrevious();

            // Assert
            Assert.That(result, Is.True);
            Assert.That(wizard.CurrentPage, Is.EqualTo(wizard.UserInfoPage));
        }

        // Helper methods
        private void SetupValidUserInfo(UserRegistrationWizard wizard)
        {
            wizard.UserInfoPage.FirstName = "John";
            wizard.UserInfoPage.LastName = "Doe";
            wizard.UserInfoPage.Email = "john.doe@example.com";
        }

        private void SetupValidAccount(UserRegistrationWizard wizard)
        {
            wizard.AccountPage.Username = "johndoe";
            wizard.AccountPage.Password = "password123";
            wizard.AccountPage.ConfirmPassword = "password123";
        }

        private void SetupValidPreferences(UserRegistrationWizard wizard)
        {
            wizard.PreferencesPage.ReceiveNewsletter = true;
            wizard.PreferencesPage.AgreeToTerms = true;
        }

        private void CompleteAllPages(UserRegistrationWizard wizard)
        {
            // Complete user info page
            SetupValidUserInfo(wizard);
            wizard.MoveNext();

            // Complete account page
            SetupValidAccount(wizard);
            wizard.MoveNext();

            // Complete preferences page
            SetupValidPreferences(wizard);
            wizard.MoveNext();
        }
    }
}