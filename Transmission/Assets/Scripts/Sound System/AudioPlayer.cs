using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

	public AudioSource mainSource;
	public AudioSource loopSource;

	public bool isPlaying = false;

	public float fadeTime;

	public void PlayCharacter (string character, float time) {
		Debug.Log ("Playing with " + character);

		AudioClip newMainClip = (AudioClip)Resources.Load ("Sound/Ogg1" + character);
		AudioClip newLoopClip = (AudioClip)Resources.Load ("Sound/Ogg2" + character);

		mainSource.clip = newMainClip;
		loopSource.clip = newLoopClip;

		Play (time);
	}

	public float GetCurrentTime () {
		if (mainSource.isPlaying) {
			return mainSource.time;
		} else if (loopSource.isPlaying) {
			return mainSource.time + loopSource.time;
		} else {
			return 0f;
		}
	}

	public void Play (float time) {

		if (time > mainSource.clip.length) {
			time -= mainSource.clip.length;
			loopSource.Play ();
			loopSource.time = time;
		} else {
			mainSource.Play ();
			mainSource.time = time;
			mainSource.PlayDelayed (0f);
			loopSource.PlayDelayed (mainSource.clip.length - time);
		}

		FadeInSound ();
	}

	public void Stop () {
		if (mainSource.isPlaying) {
			mainSource.Stop ();
		}

		if (loopSource.isPlaying) {
			loopSource.Stop ();
		}

		SetVolume (0f);
	}

	private void SetVolume (float volume) {
		mainSource.volume = volume;
		loopSource.volume = volume;
	}

	public void FadeInSound () {
		StartCoroutine (FadeIn ());
	}

	private IEnumerator FadeIn () {
		
		SetVolume (0f);
		isPlaying = true;

		float i = 0f;
		while (i < fadeTime) {
			SetVolume(Mathf.Lerp (0f, 1f, i / fadeTime));
			i += Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}

		yield return null;
	}

	public void FadeOutSound () {
		StartCoroutine (FadeOut ());
	}

	private IEnumerator FadeOut () {
		float i = 0f;
		while (i < fadeTime) {
			SetVolume(Mathf.Lerp (1f, 0f, i / fadeTime));
			i += Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}

		Stop ();
		isPlaying = false;

		yield return null;
	}
}
