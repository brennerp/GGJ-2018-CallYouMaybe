using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

[RequireComponent(typeof(CanvasGroup))]
public class Choice : MonoBehaviour {

	public Text choiceText;
	private int index;

	private CanvasGroup canvasGroup;


	public void Initiate (Choice choice) {
		index = choice.index;
		canvasGroup = GetComponent<CanvasGroup> ();
		TurnOff ();
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
	}

	public void MakeChoice () {
		Game.instance.MakeChoice (index);
	}
}
