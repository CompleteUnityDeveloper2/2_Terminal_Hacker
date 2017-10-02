using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    int level;
    string password;

	// Use this for initialization
	void Start () {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input) {
<<<<<<< HEAD
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
        else
        {
            Terminal.WriteLine("I'm not sure how to respond!");
        }
    }

    void StartGame()
    {
        Terminal.ClearScreen();
        if (level == 1)
        {
            password = "table";
        }
        else if (level == 2)
        {
            password = "dinosaur";
        }
        else if (level == 3)
        {
            password = "combobulation";
        }
        AskForPassword();
    }

    void AskForPassword()
    {
        Terminal.WriteLine("Enter your password: ");
        print(password);
=======
        print(input);
>>>>>>> patch
    }
}
