using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class Game : MonoBehaviour {

	public static Game instance;

	public DialogDisplay dialogDisplay;
	public ChoiceGroup choiceGroup;

	public string currentCharacterName = "First";
	public string currentSecondCharacter = "";

	private bool isOnCall;
	private bool hasMadeChoice;

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
	}

	public IEnumerator PlayStory () {
		while (CurrentStory.canContinue) {
			hasMadeChoice = false;
			string input = CurrentStory.Continue ().Trim();
			if (!CurrentStory.canContinue) {
				if (CurrentStory.currentChoices.Count > 0) {

					//Create and display choices
					while (!hasMadeChoice) {
						yield return null;
					}
				}
			}

			yield return null;
		}
			
	}

	public void MakeChoice (int index) {
		CurrentStory.ChooseChoiceIndex (index);
		hasMadeChoice = true;
	}
}
