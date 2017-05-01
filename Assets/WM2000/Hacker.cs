using System;
using UnityEngine;

public class Hacker : MonoBehaviour {

    enum GameState
    {
        MainMenu,
        WaitingForPassword,
        WinScreen
    }

    const string MENU = "menu";
    const string NEW_HINT = "hint";

    string[] level1Passwords = {
        "books", "isle", "shelf", "password", "font", "borrow"
	};
	string[] level2Passwords = {
		"prisoner", "handcuffs", "holster", "uniform", "arrest"
	};
	string[] level3Passwords = {
		"starfield", "telescope", "environment", "exploration", "astronauts"
	};

    int level;
    string password;
    string hint;
	GameState gameState;

	// Use this for initialization
	void Start () {
		ShowMainMenu ();
	}

	void ShowMainMenu ()
	{
		Terminal.ClearScreen ();
		Terminal.WriteLine("What would you like to hack into?\n");
		Terminal.WriteLine("Press 1 for the local library");
		Terminal.WriteLine("Press 2 for the police station");
		Terminal.WriteLine("Press 3 for NASA\n");
		Terminal.WriteLine("Enter your selection: ");
		gameState = GameState.MainMenu;
	}

    void OnUserInput(string input)
    {
        if (input == MENU)
        {
            ShowMainMenu();
        }
        else if (gameState == GameState.WaitingForPassword && input == NEW_HINT)
        {
            AskForPassword(true);
        }
        else if (gameState == GameState.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (gameState == GameState.WaitingForPassword)
        {
            CheckPassword(input);
        }
        // Consider an easter-egg as a challenge
    }

    void RunMainMenu (string input)
	{
        Terminal.WriteLine("(You may type " + MENU + " at any time)");
        if (input == "1")
		{
            level = 1;
			StartGame();
		}
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
            StartGame();
        }
    }

	void StartGame()
    {
        Terminal.ClearScreen();
        password = GenerateRandomPassword();
        AskForPassword(true);
    }

    private void AskForPassword(bool generateNewHint)
    {
        if (generateNewHint)
        {
            GenerateNewHint();
        }
        Terminal.WriteLine("Type menu, or " + NEW_HINT + " to change hint");
        Terminal.WriteLine("Enter your password, hint: " + hint);
        gameState = GameState.WaitingForPassword;
    }

    private void GenerateNewHint()
    {
        hint = password.Anagram();
        while (hint == password);
    }

    string GenerateRandomPassword()
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
            AskForPassword(false);
		}
	}

    // Update CheckPassword's Invoke on rename
	void DiplayWinScreen()
	{
        gameState = GameState.WinScreen;
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
        Terminal.WriteLine("\nType menu to return to main menu");
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