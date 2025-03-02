# WizardStateMachineTest

## Overview
WizardStateMachineTest is a .NET 9 library that demonstrates the implementation of a robust wizard interface using the state machine design pattern. This library provides a flexible framework for creating multi-step user registration flows with validation between steps.

## Features
- **State Machine Architecture:** Manages wizard page transitions with proper validation
- **Event-Based Navigation:** Uses events to control navigation between wizard pages
- **Validation Framework:** Validates data before allowing progression to the next step
- **Unit Test Suite:** Comprehensive test coverage demonstrating functionality

## Architecture
The library implements the State Machine pattern to manage transitions between wizard pages. Each page represents a state in the wizard flow, with validation rules controlling the transitions between states.

### Core Components
| Component | Description |
|-----------|-------------|
| WizardStateMachineBase | Abstract base class managing page transitions and state |
| WizardPage | Base class for all wizard pages with validation support |
| StateTransitionEventArgs | Event arguments for page transitions |

### User Registration Flow
| Page | Purpose |
|------|---------|
| UserInfoPage | Collects basic user information (name, email) |
| AccountPage | Manages username and password creation |
| PreferencesPage | Handles user preferences and terms agreement |
| SummaryPage | Displays a summary of all entered information |

## Usage Examples

### Creating a Wizard
```csharp
// Initialize a new user registration wizard
var wizard = new UserRegistrationWizard();

// Navigate through pages
wizard.MoveNext(); // Move to the next page
wizard.MovePrevious(); // Move to the previous page

// Access page properties
wizard.UserInfoPage.FirstName = "John";
wizard.UserInfoPage.LastName = "Doe";
wizard.UserInfoPage.Email = "john.doe@example.com";

// Complete the registration
if (wizard.RegisterUser())
{
    Console.WriteLine("Registration successful!");
}
```

### Custom Page Validation
```csharp
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
```

## Getting Started

### Prerequisites
- .NET 9 SDK
- Visual Studio 2022 or later

### Installation
1. Clone the repository:
   ```
   git clone https://github.com/yourusername/WizardStateMachineTest.git
   ```
2. Open the solution in Visual Studio
3. Build the solution:
   ```
   dotnet build
   ```

### Running Tests
```
dotnet test
```

## Extending the Framework
To create your own wizard implementation:

1. Create custom page classes inheriting from `WizardPage`
2. Implement the `Validate()` method for each page
3. Create a wizard class that inherits from `WizardStateMachineBase`
4. Initialize your pages in the constructor and add them to the base collection
5. Subscribe to the `StateTransition` event to implement validation logic

## License
This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments
- State Machine Design Pattern
- .NET Framework Documentation