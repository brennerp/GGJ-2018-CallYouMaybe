using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class Game : MonoBehaviour {

	public string currentCharacterName = "First";
	public string currentSecondCharacter = "";

	private bool isOnCall;

	public Story CurrentStory { get; private set; }


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
			
			string input = CurrentStory.Continue ().Trim();
			if (!CurrentStory.canContinue) {
				if (CurrentStory.currentChoices.Count > 0) {
					
				}
			}

			yield return null;
		}
			
	}
}
