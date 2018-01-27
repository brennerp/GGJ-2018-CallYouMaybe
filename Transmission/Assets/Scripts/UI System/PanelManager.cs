using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour {

	public bool startAllHidden;
	public GameObject [] panels;

	private int currentPanelIndex = 0;

	void Start () {
		HideAllPanels ();
		if (!startAllHidden) {
			ShowPanel (0);
		}
	}

	public void ShowPanel (int index) {
		panels [index].SetActive (true);
	}

	public void HidePanel (int index) {
		panels [index].SetActive (false);
	}

	public void ShowAllPanels () {
		foreach (GameObject panel in panels) {
			panel.SetActive (true);
		}
	}

	public void HideAllPanels () {
		foreach (GameObject panel in panels) {
			panel.SetActive (false);
		}
	}
}
