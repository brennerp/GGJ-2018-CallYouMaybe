﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPanel : MonoBehaviour {

	public Character currentCharacter;
	public string characterName;

	public void FillCharacter (string character) {
		Clear ();
		characterName = character;
		//Debug.Log ("Looking for " + character);
		currentCharacter = Instantiate(Resources.Load ("Prefabs/Characters/" + character) , transform) as Character;
		//Debug.Log ("Found " + currentCharacter.name);
	}

	public void Clear () {
		characterName = "";
		if (currentCharacter != null) {
			Destroy (currentCharacter.gameObject);
		}
	}

	public void Talk () {
		if (currentCharacter == null) {
			Debug.Log ("Character is null!");
			return;
		}

		currentCharacter.animator.SetBool ("Talking", true);
	}

	public void ShutUp () {
		if (currentCharacter == null) {
			Debug.Log ("Character is null!");
			return;
		}

		currentCharacter.animator.SetBool ("Talking", false);
	}

}
