using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

[RequireComponent(typeof(CanvasGroup))]
public class DialogDisplay : MonoBehaviour {

	public Text characterLine;
	public float fadeTime;

	public CanvasGroup canvasGroup;
	public Animator balloonAnimator;

	public void TurnOff () {
		canvasGroup.alpha = 0f;
		canvasGroup.interactable = false;
	}

	public void TurnOn () {
		canvasGroup.alpha = 1f;
		canvasGroup.interactable = true;
	}

	public void SetText (string text) {
		characterLine.text = text;
	}

	public void StartFadeIn (CharacterPosition characterPosition) {
		if (characterPosition == CharacterPosition.Right) {
			balloonAnimator.SetInteger ("Direction", 1);
		} else {
			balloonAnimator.SetInteger ("Direction", -1);
		}

		StartCoroutine (FadeIn (fadeTime));
	}

	private IEnumerator FadeIn (float time) {
		float i = 0f;
		while (i < time) {
			canvasGroup.alpha = Mathf.Lerp (canvasGroup.alpha, 1f, i / time);
			i += Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}
		TurnOn ();
	}

	public void StartFadeOut () {
		StartCoroutine (FadeOut (fadeTime));
	}

	private IEnumerator FadeOut (float time) {
		float i = 0f;
		canvasGroup.interactable = false;
		while (i < time) {
			canvasGroup.alpha = Mathf.Lerp (canvasGroup.alpha, 0f, i / time);
			i += Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}

		TurnOff ();
		Game.instance.CheckOutDisplay ();
	}
}
