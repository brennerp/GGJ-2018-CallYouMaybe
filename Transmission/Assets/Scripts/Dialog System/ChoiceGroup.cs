using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class ChoiceGroup : MonoBehaviour {

	private List<ChoiceButton> currentChoices = new List<ChoiceButton> ();
	private int choicesCheckedOut = 0;
	private bool choiceMade = false;

	public float fadeTime;
	public ChoiceButton choicePrefab;

	//First we add each choice to the ChoiceGroup
	public void AddChoice (Choice choice) {
		ChoiceButton newChoice = (ChoiceButton)Instantiate (choicePrefab, transform);
		newChoice.Initiate (choice);
		newChoice.SetChoiceGroup (this);
		currentChoices.Add (newChoice);
	}

	//Then we Fade In
	public void FadeIn () {
		StartCoroutine (FadeInChoices ());
	}

	private IEnumerator FadeInChoices () {
		foreach (ChoiceButton cb in currentChoices) {
			cb.StartFadeIn (fadeTime);
			yield return null;
		}
	}

	//We wait for a choice to be made and then we fade out 
	public void MakeChoice (int index) {
		if (!choiceMade) {
			Game.instance.MakeChoice (index);
			choiceMade = true;
			foreach (ChoiceButton cb in currentChoices) {
				cb.canvasGroup.interactable = false;
			}
			FadeOut ();
		}
	}

	public void FadeOut () {
		StartCoroutine (FadeOutChoices ());
	}

	private IEnumerator FadeOutChoices () {
		foreach (ChoiceButton cb in currentChoices) {
			cb.StartFadeOut (fadeTime);
			yield return null;
		}

		while (choicesCheckedOut < currentChoices.Count) {
			yield return null;
		}

		choicesCheckedOut = 0;
		choiceMade = false;

		foreach (ChoiceButton cb in currentChoices) {
			Destroy (cb.gameObject);
			yield return null;
		}

		currentChoices.Clear ();
		Game.instance.CheckOutChoices ();
	}

	//We receive warning when a choice has faded out completely
	public void CheckOutChoice () {
		choicesCheckedOut++;
	}
}
