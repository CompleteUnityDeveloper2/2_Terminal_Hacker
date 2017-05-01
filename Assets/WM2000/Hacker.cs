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
		"donkey", "coal", "monkey"
	};
	string[] level2Passwords = {
		"example", "birthday", "velocity"
	};
	string[] level3Passwords = {
		"appropriate", "ambiguous", "strifled", "environment"
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
		Terminal.WriteLine ("What would you like to hack into?\n");
		Terminal.WriteLine ("Press 1 for the local library");
		Terminal.WriteLine ("Press 2 for the police station");
		Terminal.WriteLine ("Press 3 for the CIA\n");
		Terminal.WriteLine ("Enter your selection: ");
		gameState = GameState.MainMenu;
	}	

	void RunMainMenu (string input)
	{
		if (input == "1" || input == "2" || input == "3")
		{
			level = int.Parse (input);
			StartGame ();
		}
	}

	void StartGame()
	{
		Terminal.ClearScreen ();
		Terminal.WriteLine ("Welcome to level " + level);
		SetNewPassword ();
        hint = password.Shuffle();
        Terminal.WriteLine ("Enter your password (hint: " + hint + ")");
        gameState = GameState.WaitingForPassword;
	}

	void SetNewPassword()
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
		password = passwordList[index];
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
        Terminal.WriteLine("(You  type " + EXIT + " or " + MENU + " at any time)");
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
		Terminal.WriteLine ("Well done! You're an ace hacker\n");
		Terminal.WriteLine ("Type yes to hack again\n");
		gameState = GameState.AskToPlayAgain;
	}
}
