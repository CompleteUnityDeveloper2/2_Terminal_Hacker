using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Code to be moved elsewhere and taken for granted
public static class StringExtension
{
	public static string Shuffle(this string str) // Note use of this
	{
		char[] array = str.ToCharArray();
		System.Random rng = new System.Random();
		int n = array.Length;
		while (n > 1)
		{
			n--;
			int k = rng.Next(n + 1);
			var value = array[k];
			array[k] = array[n];
			array[n] = value;
		}
		return new string(array);
	}
}

public class Hacker : MonoBehaviour {

	enum GameState 
	{
		MainMenu,
		WaitingForPassword,
		AskToPlayAgain
	}

	int level;
	string[] level1Passwords = {
		"donkey", "coal", "monkey"
	};
	string[] level2Passwords = {
		"example", "birthday", "velocity"
	};
	string[] level3Passwords = {
		"appropriate", "ambiguous", "strifled", "environment"
	};
	string password;

	GameState gameState;

	// Use this for initialization
	void Start () {
		ShowMainMenu ();
	}
		
	void Update()
	{
		
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
		string hint = password.Shuffle ();
		Terminal.WriteLine ("Enter the password (hint " + hint + "):");
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
	
		int index = UnityEngine.Random.Range(0,passwordList.Length);
		password = passwordList[index];
	}


	void OnUserInput(string input)
	{
		if (input == "exit")
		{
			Terminal.Exit ();
		}
		else if (gameState == GameState.MainMenu)
		{
			RunMainMenu (input);
		}
		else if (gameState == GameState.WaitingForPassword)
		{
			CheckPassword (input);
		}
		else if (gameState == GameState.AskToPlayAgain)
		{
			if (input == "yes")
			{
				ShowMainMenu ();
			}
		}

	}

	void CheckPassword(string input)
	{
		if (input == password)
		{
			AskToPlayAgain ();
		}
		else
		{
			Terminal.WriteLine ("Incorrect password, try again");
		}
	}

	void AskToPlayAgain()
	{
		Terminal.ClearScreen ();
		Terminal.WriteLine ("Well done! You're an ace hacker\n");
		Terminal.WriteLine ("Hack again? (yes / exit)");
		gameState = GameState.AskToPlayAgain;
	}

}
