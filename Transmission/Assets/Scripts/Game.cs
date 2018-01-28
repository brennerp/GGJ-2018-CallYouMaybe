using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Ink.Runtime;


public enum CharacterPosition {
	Left,
	Right,
	None
};

public class Game : MonoBehaviour {

	public static Game instance;

	public TextAsset testAsset;

	public bool testStory;
	public bool bindFunction;
	public bool startWithCutscene;

	public CharacterManager characterManager;

	public DialogDisplay dialogDisplay;
	public ChoiceGroup choiceGroup;

	public string currentMainCharacter = "First";
	public string currentSecondCharacter = "";

	private bool isOnCall;
	private bool hasMadeChoice;
	private bool nextAction = false;
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
			StartCoroutine (PlayStory ());
		} else if (startWithCutscene) {
			characterManager.StartCutscene ();
			StartConversation ();
		}
	}

	public void CallCharacter (string character) {
		if (isOnCall) {
			Debug.Log ("ERROR in Game > CallCharacter: player supposed to be on call.");
		}

		currentSecondCharacter = character;
		StartConversation ();
	}

	public void StartConversation () {
		string conversationFile = "En_";

		if (startWithCutscene) {
			conversationFile += "OpeningScene";
		} else {
			conversationFile += currentMainCharacter;
		}
		Debug.Log ("Opening " + conversationFile);
		TextAsset inkAsset = (TextAsset)Resources.Load ("Ink/" + conversationFile);
		SignInStory (inkAsset);
		StartCoroutine (PlayStory());
	}

	public void SignInStory (TextAsset inkAsset) {
		CurrentStory = new Story (inkAsset.text);
		if (bindFunction) {
			BindFunction ();
		}
	}

	public IEnumerator PlayStory () {

		characterManager.SetMainCharacter (currentMainCharacter);
		characterManager.SetSecondCharacter (currentSecondCharacter);

		if (!startWithCutscene) {
			characterManager.EnterConversation ();
			while (!nextAction) {
				yield return null;
			}

			nextAction = false;
		}

		string characterSpeaking = "";
		string currentLine = "";

		bool forceEnd = false;

		bool success = false;
		bool failure = false;

		CharacterPosition characterPosition = CharacterPosition.Left;

		while (CurrentStory.canContinue && !forceEnd) {
			hasMadeChoice = false;
			string input = CurrentStory.Continue ();

			if (!input.IsBlank ()) {
				string[] divisions = input.Split (':');

				if (divisions.Length >= 2) {
					string nextCharacter = divisions [0].Trim();
					if (nextCharacter == "Granny") {
						nextCharacter = "OldLady";
					}

					if (nextCharacter != characterSpeaking) {
						characterManager.MakeCharacterShutUp (characterPosition);
						characterSpeaking = nextCharacter;
					}

				}

				currentLine = divisions [divisions.Length - 1];

				if (characterSpeaking == currentSecondCharacter) {
					characterPosition = CharacterPosition.Right;
				} else if (characterSpeaking == currentMainCharacter){
					characterPosition = CharacterPosition.Left;
				} else {
					characterPosition = CharacterPosition.None;
				}

				characterManager.MakeCharacterTalk (characterPosition);

				dialogDisplay.SetText (currentLine);
				dialogDisplay.StartFadeIn (characterPosition);

				while (!displayCheckedOut) {
					yield return null;
				}

				displayCheckedOut = false;

			}

			List<string> tags = CurrentStory.currentTags;
			foreach (string tag in tags) {
				if (tag.Contains("Success")) {
					Debug.Log ("SUCCESS BABY");
					success = true;
					forceEnd = true;
					break;
				} else if (tag.Contains("Failure")) {
					failure = true;
					forceEnd = true;
					break;
				}
			}

			if (!CurrentStory.canContinue && !forceEnd) {

				characterManager.MakeCharacterShutUp (characterPosition);

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

		characterManager.MakeAllShutUp ();

		if (success) {
			Debug.Log ("AAAAAAA");




			characterManager.SucceedConversation ();

			while (!nextAction) {
				yield return null;
			}

			nextAction = false;

			if (startWithCutscene) {
				startWithCutscene = false;
				characterManager.EraseSecondCharacter ();
			} else {
				currentMainCharacter = currentSecondCharacter;
			}

			currentSecondCharacter = "";

		} else if (failure) {
			characterManager.FailConversation ();

			while (!nextAction) {
				yield return null;
			}

			nextAction = false;

			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		} else {
			currentSecondCharacter = "";
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
		CurrentStory.BindExternalFunction ("who_is_being_called", () => {return currentSecondCharacter;});
	}

	public void NextAction () {
		nextAction = true;
	}


}
