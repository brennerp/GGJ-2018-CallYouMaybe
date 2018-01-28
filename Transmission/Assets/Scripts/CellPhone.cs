using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellPhone : MonoBehaviour {

	private Dictionary<string, string> personalContacts = new Dictionary<string, string> () {
		{ "OldLady", "Raissa, Rodrigo, Sarue"},
		{ "Raissa", "Rodrigo, Sarue"}
	};

	private List<CellContact> currentContacts = new List<CellContact>();
	private bool contactChosen = false;

	public float fadeTime = 0.25f;
	public CanvasGroup screenGroup;
	public CellContact contactPrefab;

	void Start () {
		screenGroup.interactable = false;
		screenGroup.alpha = 1.0f;
	}

	public void AddContactsOfPerson (string person) {
		if (!personalContacts.ContainsKey (person)) {
			Debug.Log ("ERROR in CellPhone: There is no contact list for requested person: " + person);
			return;
		}

		Debug.Log ("FOUND CONTACT LIST OF PERSON!");
		string[] contacts = personalContacts [person].Split (',');

		foreach (string contact in contacts) {
			AddContact (contact);
		}

		FadeIn ();
	}

	public void AddContact (string contact) {
		CellContact newContact = (CellContact)Instantiate (contactPrefab, screenGroup.transform);
		newContact.contactName.text = contact.Trim();
		newContact.button.onClick.AddListener (() => this.ChooseContact(contact.Trim()));
		currentContacts.Add (newContact);
	}

	public void ChooseContact (string contact) {
		screenGroup.interactable = false;
		FadeOut ();
	}

	public void FadeIn () {
		StartCoroutine (FadeInScreen (fadeTime));
	}

	public IEnumerator FadeInScreen (float time) {
		float i = 0f;
		while (i < time) {
			screenGroup.alpha = Mathf.Lerp (screenGroup.alpha, 1f, i);
			i += Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}

		screenGroup.alpha = 1f;
		screenGroup.interactable = true;
	}

	public void FadeOut () {
		StartCoroutine (FadeOutScreen (fadeTime));
	}

	public IEnumerator FadeOutScreen (float time) {
		float i = 0f;
		screenGroup.interactable = false;

		while (i < time) {
			screenGroup.alpha = Mathf.Lerp (screenGroup.alpha, 1f, i);
			i += Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}

		screenGroup.alpha = 0f;

	}
}
