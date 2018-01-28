using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterManager : MonoBehaviour {

	public Animator animator;

	public CharacterPanel currentCharacterPanel;
	public CharacterPanel secondCharacterPanel;

	public CellPhone phone;

	public void TransitionCharacters () {
		CharacterPanel temp = currentCharacterPanel;
		currentCharacterPanel = secondCharacterPanel;
		secondCharacterPanel = temp;

		currentCharacterPanel.gameObject.name = "Panel - Current Character";
		secondCharacterPanel.gameObject.name = "Panel - Second Character";
	}

	public void SetMainCharacter (string character) {
		currentCharacterPanel.FillCharacter (character);
	}

	public void SetSecondCharacter (string character) {
		secondCharacterPanel.FillCharacter (character);
	}

	public void MakeAllTalk () {
		currentCharacterPanel.Talk ();
		secondCharacterPanel.Talk ();
	}

	public void MakeCharacterTalk (CharacterPosition pos) {
		MakeAllShutUp ();
		if (pos == CharacterPosition.Left) {
			currentCharacterPanel.Talk ();
		} else {
			secondCharacterPanel.Talk ();
		}
	}

	public void MakeAllShutUp () {
		currentCharacterPanel.ShutUp ();
		secondCharacterPanel.ShutUp ();
	}

	public void MakeCharacterShutUp (CharacterPosition pos) {
		if (pos == CharacterPosition.Left) {
			currentCharacterPanel.ShutUp ();
		} else {
			secondCharacterPanel.ShutUp ();
		}
	}

	public void EnterConversationWith (string character) {
		SetSecondCharacter (character);
		animator.SetTrigger ("Enter Conversation");
	}

	public void SucceedConversation () {
		animator.SetTrigger ("Success");
	}

	public void FailConversation () {
		animator.SetTrigger ("Failure");
	}
}
