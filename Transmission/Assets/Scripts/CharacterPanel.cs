using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPanel : MonoBehaviour {

	private Animator currentCharacter;

	public void FillCharacter (string character) {
		Clear ();
		currentCharacter = (Animator)Resources.Load ("Prefabs/Characters/" + character);
		currentCharacter.transform.parent = transform;
	}

	public void Clear () {
		if (currentCharacter == null) {
			Debug.Log ("Character is null!");
			return;
		}

		Destroy (currentCharacter.gameObject);
	}

	public void Talk () {
		if (currentCharacter == null) {
			Debug.Log ("Character is null!");
			return;
		}

		currentCharacter.SetBool ("Talking", true);
	}

	public void ShutUp () {
		if (currentCharacter == null) {
			Debug.Log ("Character is null!");
			return;
		}

		currentCharacter.SetBool ("Talking", false);
	}

}
