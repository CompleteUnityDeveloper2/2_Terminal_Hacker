using UnityEngine;

public class MyGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Terminal.ClearScreen();
        Terminal.WriteLine("=== Welcome To GameDev.tv ===");
        ListCommands();
    }
	
    void OnUserInput(string input)
    {
        switch (input)
        {
            case "exit":
                Terminal.Exit();
                break;
            case "help":
                Terminal.WriteLine("I can be of no help");
                break;
            case "cls":
                Terminal.ClearScreen();
                break;
            default:
                Terminal.WriteLine("Try typing: help, exit");
                break;
        }
    }

    void ListCommands()
    {
        Terminal.WriteLine("Try typing: help, exit, cls");
    }
}
