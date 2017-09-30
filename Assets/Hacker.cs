using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

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
        if (input == "1")
        {
            Terminal.WriteLine("You chose option 1");
        }
        else if (input == "2")
        {
            Terminal.WriteLine("You chose option 2");
        }
        else if (input == "3")
        {
            Terminal.WriteLine("You chose option 3");
        }
        else
        {
            Terminal.WriteLine("I'm not sure how to respond!");
        }
    }
}
