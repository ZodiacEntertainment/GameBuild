using UnityEngine;
using System.Collections;

public class TestPopup : MonoBehaviour {

	public void Open() {
		gameObject.SetActive(true);
	}

	public void Close() {
		gameObject.SetActive(false);
	}
}