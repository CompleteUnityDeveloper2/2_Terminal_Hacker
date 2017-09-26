# `Terminal.OnUserInput(string)`
WM2000 asset pack v.1

## Description
`OnUserInput` is called whenever the user hits return after having typed character(s).

Note that in the editor the Game window must be focused for characters to register.

## Example Code

	using UnityEngine;
	using System.Collections;

	public class ExampleClass : MonoBehaviour
	{
		void OnUserInput(string input)
		{
			Terminal.WriteLine("The user typed " + input);
		}
	}

Part of the [Complete Unity Developer 2.0](https://www.udemy.com/unitycourse2) online tutorial series.

GameDev.tv by Ben Tristem
