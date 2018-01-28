using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterManager : MonoBehaviour {

	public Animator animator;

	public CharacterPanel currentCharacterPanel;
	public CharacterPanel secondCharacterPanel;

	public CellPhone phone;
	private string currentPhoneOwner = "";

	public void TurnPhoneOn () {
		phone.AddContactsOfPerson (currentPhoneOwner);
		SoundManager.instance.PlayAudioForCharacter (currentPhoneOwner);
	}

	public void SetMainCharacter (string character) {
		currentPhoneOwner = character;
		currentCharacterPanel.FillCharacter (character);
	}

	public void SetSecondCharacter (string character) {
		secondCharacterPanel.FillCharacter (character);
		SoundManager.instance.PlayAudioForCharacter (character);
	}

	public void MakeSecondMain () {
		SetMainCharacter (secondCharacterPanel.characterName);
	}

	public void EraseSecondCharacter () {
		secondCharacterPanel.Clear ();
	}

	public void MakeAllTalk () {
		currentCharacterPanel.Talk ();
		secondCharacterPanel.Talk ();
	}

	public void MakeCharacterTalk (CharacterPosition pos) {
		if (pos == CharacterPosition.None) {
			return;
		} else if (pos == CharacterPosition.Left) {
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

	public void EnterConversation () {
		animator.SetTrigger ("Enter Conversation");
	}

	public void SucceedConversation () {
		animator.SetTrigger ("Success");
	}

	public void FailConversation () {
		animator.SetTrigger ("Failure");
	}

	public void StartCutscene () {
		animator.SetTrigger ("Cutscene");
	}

	public void NextAction () {
		Game.instance.NextAction ();
	}
}
