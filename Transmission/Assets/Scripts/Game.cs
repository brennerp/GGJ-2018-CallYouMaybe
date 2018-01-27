using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public enum CharacterPosition {
	Left,
	Right
};

public class Game : MonoBehaviour {

	public static Game instance;

	public TextAsset testAsset;
	public bool testStory;
	public bool bindFunction;

	public DialogDisplay dialogDisplay;
	public ChoiceGroup choiceGroup;

	public string currentCharacterName = "First";
	public string currentSecondCharacter = "";

	private bool isOnCall;
	private bool hasMadeChoice;
	private bool displayCheckedOut = false;
	private bool choicesCheckedOut = false;

	public Story CurrentStory { get; private set; }

	void Awake () {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
	}

	void Start () {
		isOnCall = false;
		dialogDisplay.TurnOff ();

		if (testStory) {
			SignInStory (testAsset);
			StartStory ();
		}
	}

	public void CallCharacter (string character) {
		if (isOnCall) {
			Debug.Log ("ERROR in Game > CallCharacter: player supposed to be on call.");
		}
		currentSecondCharacter = character;
	}

	public void StartConversation () {
		string conversationFile = currentCharacterName + "_" + currentSecondCharacter + ".txt";
		TextAsset inkAsset = (TextAsset)Resources.Load (conversationFile);
		SignInStory (inkAsset);
		StartCoroutine (PlayStory());
	}

	public void SignInStory (TextAsset inkAsset) {
		CurrentStory = new Story (inkAsset.text);
		if (bindFunction) {
			BindFunction ();
		}
	}

	public void StartStory () {
		StartCoroutine (PlayStory ());
	}

	public IEnumerator PlayStory () {

		string characterSpeaking = "";
		string currentLine = "";
		CharacterPosition characterPosition = CharacterPosition.Left;

		while (CurrentStory.canContinue) {
			hasMadeChoice = false;
			string input = CurrentStory.Continue ();
			string[] divisions = input.Split (':');

			if (divisions.Length >= 2) {
				characterSpeaking = divisions [0];
			}

			currentLine = divisions [divisions.Length - 1];

			if (characterSpeaking == "" || characterSpeaking == currentCharacterName) {
				characterPosition = CharacterPosition.Left;
			} else {
				characterPosition = CharacterPosition.Right;
			}

			dialogDisplay.SetText (currentLine);

			dialogDisplay.StartFadeIn (characterPosition);

			while (!displayCheckedOut) {
				yield return null;
			}

			displayCheckedOut = false;

			if (!CurrentStory.canContinue) {
				if (CurrentStory.currentChoices.Count > 0) {

					foreach (Choice choice in CurrentStory.currentChoices) {
						choiceGroup.AddChoice (choice);
					}

					choiceGroup.FadeIn ();

					while (!choicesCheckedOut) {
						yield return null;
					}

					choicesCheckedOut = false;
				}
			}

			yield return null;
		}
			
	}

	public void MakeChoice (int index) {
		CurrentStory.ChooseChoiceIndex (index);
		hasMadeChoice = true;
	}

	public void CheckOutDisplay () {
		displayCheckedOut = true;
	}

	public void CheckOutChoices () {
		choicesCheckedOut = true;
	}

	private void BindFunction () {
		CurrentStory.BindExternalFunction ("who_is_being_called", () => {return "sarue";});
	}


}
