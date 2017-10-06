using System;
using UnityEngine;

enum Screen { MainMenu, WaitingForPassword, WinScreen } // TODO discuss
   
public class Hacker : MonoBehaviour {
    
    const string MENU_HINT = "You may type menu at any time.";

    // Game state variables
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
	void Start () {
		ShowMainMenu ();
	}

	void ShowMainMenu ()
	{
        currentScreen = Screen.MainMenu;
		Terminal.ClearScreen ();
		Terminal.WriteLine("What would you like to hack into?\n");
		Terminal.WriteLine("Press 1 for the local library");
		Terminal.WriteLine("Press 2 for the police station");
		Terminal.WriteLine("Press 3 for NASA\n");
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
        if (input == "1" || input == "2" || input == "3")
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
        password = GenerateRandomPassword(level);
        AskForPassword();
    }

    private void AskForPassword()
    {
        Terminal.WriteLine(MENU_HINT);
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        currentScreen = Screen.WaitingForPassword;
    }

    string GenerateRandomPassword(int level)
	{
		string[] passwordList = { "" };
		if (level == 1)
		{
			passwordList = level1Passwords;
		} 
		else if (level == 2)
		{
			passwordList = level2Passwords;
		}
		else if (level == 3)
		{
			passwordList = level3Passwords;
		}
	
		int index = UnityEngine.Random.Range(0, passwordList.Length);
		return passwordList[index]; // This assumes list isn't empty
	}

    void CheckPassword(string input)
	{
		if (input == password)
		{
            DiplayWinScreen ();
        }
		else
		{
            Terminal.WriteLine("Sorry, wrong password");
            AskForPassword();
		}
	}

    // Update CheckPassword's Invoke on rename
	void DiplayWinScreen()
	{
        currentScreen = Screen.WinScreen;
		Terminal.ClearScreen ();
        ShowLevelReward();
	}

    private void ShowLevelReward()
    {
        if (level == 1)
        {
            ShowLevel1Reward();
        }
        else if (level == 2)
        {
            ShowLevel2Reward();
        }
        else if (level == 3)
        {
            ShowLevel3Reward();
        }
        Terminal.WriteLine(MENU_HINT);
    }

    private static void ShowLevel1Reward()
    {
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
    }

    private static void ShowLevel2Reward()
    {
        Terminal.WriteLine("You got the prison key!");
        Terminal.WriteLine(@"
 __
/o \_______
\__/-=' = '
"
        );
        Terminal.WriteLine("Play again for a bigger challenge");
    }

    private static void ShowLevel3Reward()
    {
        Terminal.WriteLine(@"
 _ __   __ _ ___  __ _ 
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___/\__,_|
"
        );
        Terminal.WriteLine("Welcome to NASA's internal system!\n");
    }
}