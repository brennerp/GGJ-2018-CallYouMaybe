using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

[RequireComponent(typeof(CanvasGroup))]
public class ChoiceButton : MonoBehaviour {

	public Text choiceLine;
	public CanvasGroup canvasGroup;

	private int index; 
	private ChoiceGroup choiceGroup;

	public void Initiate (Choice choice) {
		Debug.Log ("Initiating choice index " + choice.index);
		SetIndex (choice.index);
		SetText (choice.text);
		TurnOff ();
	}

	private void SetIndex (int i) {
		index = i;
	}

	private void SetText (string text) {
		choiceLine.text = text;
	}

	public void SetChoiceGroup (ChoiceGroup cg) {
		choiceGroup = cg;
	}

	public void StartFadeIn (float time) {
		StartCoroutine (FadeIn(time));
	}

	public void StartFadeOut (float time) {
		StartCoroutine (FadeOut (time));
	}

	public void TurnOff () {
		canvasGroup.alpha = 0f;
		canvasGroup.interactable = false;
	}

	public void TurnOn () {
		canvasGroup.alpha = 1f;
		canvasGroup.interactable = true;
	}

	private IEnumerator FadeIn (float time) {
		float i = 0f;
		while (i < time) {
			canvasGroup.alpha = Mathf.Lerp (canvasGroup.alpha, 1f, i);
			i += Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}
		TurnOn ();
	}

	private IEnumerator FadeOut (float time) {
		float i = 0f;
		canvasGroup.interactable = false;
		while (i < time) {
			canvasGroup.alpha = Mathf.Lerp (canvasGroup.alpha, 0f, i);
			i += Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}

		TurnOff ();
		choiceGroup.CheckOutChoice ();
	}

	public void MakeChoice () {
		Debug.Log ("Making choice index " + index);
		choiceGroup.MakeChoice (index);
	}
}
