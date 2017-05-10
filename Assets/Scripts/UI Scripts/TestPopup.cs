using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class TestPopup : MonoBehaviour {
    public GameObject selectedObject;
    public EventSystem eventSystem;
	public void Open() {
		gameObject.SetActive(true);
	}

	public void Close() {
        eventSystem.SetSelectedGameObject(selectedObject);
        gameObject.SetActive(false);
	}
}