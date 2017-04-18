using UnityEngine;
using System.Collections;

public class CanvasControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		for(int i = 0; i < 4; i++){
			transform.GetChild (i).gameObject.SetActive(false);
		}
	}
}
