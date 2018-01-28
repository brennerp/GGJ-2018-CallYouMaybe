using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;

	public AudioPlayer [] audioPlayers;

	private int currentIndex = 0;
	private string currentCharacter = "";
	private bool firstTime = true;

	void Awake () {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (this.gameObject);
		}
	}

	public void PlayAudioForCharacter (string character) {
		if (currentCharacter == character) {
			return;
		}

		float playbackTime = 0f;

		if (audioPlayers [currentIndex].isPlaying) {
			playbackTime = audioPlayers [currentIndex].GetCurrentTime ();
			audioPlayers [currentIndex].FadeOutSound ();
		}

		if (!firstTime) {
			IncremenetIndex ();
		} else {
			firstTime = false;
		}

		currentCharacter = character;
		audioPlayers [currentIndex].PlayCharacter (character, playbackTime);
	}

	public void Stop () {
		foreach (AudioPlayer ap in audioPlayers) {
			ap.Stop ();
		}
	}

	private void IncremenetIndex () {
		currentIndex++;
		if (currentIndex >= audioPlayers.Length) {
			currentIndex = 0;
		}
	}
}
