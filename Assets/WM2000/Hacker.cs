using UnityEngine;

public class Hacker : MonoBehaviour {

	enum GameState 
	{
		MainMenu,
		WaitingForPassword,
		AskToPlayAgain
	}

    const string EXIT = "exit";
    const string MENU = "menu";

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
        if (input == EXIT)
        {
            Terminal.Exit();
        }
        else if (input == MENU)
        {
            ShowMainMenu();
        }
        else if (gameState == GameState.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (gameState == GameState.WaitingForPassword)
        {
            CheckPassword(input);
        }
        else if (gameState == GameState.AskToPlayAgain)
        {
            RespondToPlayAgain(input);
        }
        Terminal.WriteLine("P.S. Type " + EXIT + " or " + MENU + " at any time");
    }

    void RunMainMenu (string input)
	{
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
		Terminal.ClearScreen ();
		Terminal.WriteLine("Welcome to level " + level);
		password = GenerateRandomPassword();
        hint = password.Shuffle();
        Terminal.WriteLine("Enter your password (hint: " + hint + ")");
        gameState = GameState.WaitingForPassword;
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
	
		int index = Random.Range(0, passwordList.Length);
		return passwordList[index];
	}

    private void RespondToPlayAgain(string input)
    {
        if (input == "yes")
        {
            ShowMainMenu();
        }
        else
        {
            Terminal.WriteLine("Invalid input, type yes to play again");
        }
    }

    void CheckPassword(string input)
	{
		if (input == password)
		{
            DiplayWinScreen ();
        }
		else
		{
            Terminal.WriteLine ("Try again (hint: " + hint + ")");
		}
	}

    // Update CheckPassword's Invoke on rename
	void DiplayWinScreen()
	{
		Terminal.ClearScreen ();
        ShowLevelReward();
		Terminal.WriteLine ("Type yes to hack again\n");
		gameState = GameState.AskToPlayAgain;
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
        Terminal.WriteLine("Ready for an even bigger challenge?");
    }

    private static void ShowLevel3Reward()
    {
        Terminal.WriteLine(@"
 _ __   __ _ ___ __ _ 
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___/\__,_|
"
        );
        Terminal.WriteLine("Welcome to NASA's internal system!\n");
    }


}
