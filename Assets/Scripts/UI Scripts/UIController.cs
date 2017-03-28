﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {
	[SerializeField] private TestPopup TestPopup;

	void Start() {
		TestPopup.Close();
	}

	public void OnOpenSettings() {
		TestPopup.Open();

	}
}