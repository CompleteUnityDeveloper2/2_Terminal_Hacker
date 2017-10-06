using System;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    const string MENU_HINT = "You may type menu at any time.";

    // Game state variables
    enum Screen { MainMenu, WaitingForPassword, WinScreen }
    Screen currentScreen;
    int level;
    string password;

    // Game configuration data
    string[] level1Passwords = {
        "books", "aisle", "shelf", "password", "font", "borrow"
    };
    string[] level2Passwords = {
        "prisoner", "handcuffs", "holster", "uniform", "arrest"
    };
    string[] level3Passwords = {
        "starfield", "telescope", "environment", "exploration", "astronauts"
    };

    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu") // Can always go to menu
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.WaitingForPassword)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        Terminal.WriteLine(MENU_HINT);
        bool validLevelNumber = input == "1" || input == "2" || input == "3";
        if (validLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Invalid level, please try again.");
        }
    }

    void StartGame()
    {
        Terminal.ClearScreen();
        password = GenerateRandomPassword();
        AskForPassword();
    }

    void AskForPassword()
    {
        currentScreen = Screen.WaitingForPassword;
        Terminal.WriteLine(MENU_HINT);
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
    }

    string GenerateRandomPassword()
    {
        string[] passwordList = { "" };
        switch (level)
        {
            case 1:
                passwordList = level1Passwords;
                break;
            case 2:
                passwordList = level2Passwords;
                break;
            case 3:
                passwordList = level3Passwords;
                break;
            default:
                Debug.LogError("Invalid level");
                break;
        }
        int index = UnityEngine.Random.Range(0, passwordList.Length);
        return passwordList[index]; // This assumes list isn't empty
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DiplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Sorry, wrong password");
            AskForPassword();
        }
    }

    void DiplayWinScreen()
    {
        currentScreen = Screen.WinScreen;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(MENU_HINT);
    }

    // Note game assets build into this method
    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    _______
   /      //
  /      //
 /______//
(______(/
"
                );
                Terminal.WriteLine("Play again for a bigger challenge");
                break;

            case 2:
                Terminal.WriteLine("You got the prison key!");
                Terminal.WriteLine(@"
 __
/o \_______
\__/-=' = '
"
                );
                Terminal.WriteLine("Play again for a bigger challenge");
                break;

            case 3:
                Terminal.WriteLine(@"
 _ __   __ _ ___  __ _ 
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___/\__,_|
"
                );
                Terminal.WriteLine("Welcome to NASA's internal system!");
                break;

            default:
                Debug.LogError("No level reward for level " + level);
                break;
        }
    }
}