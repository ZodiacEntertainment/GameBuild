using UnityEngine;
using System.Collections;

public class FallCatch : MonoBehaviour {
	public Transform respawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerExit2D (Collider2D other){
		if (other.tag == "Character") {
			other.gameObject.transform.position = respawn.position;
		}
	}
}
