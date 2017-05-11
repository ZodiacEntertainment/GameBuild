using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

    public float delay = 5f;
    
	// Use this for initialization
	void OnEnable () {
        Destroy(gameObject.transform.parent.gameObject, delay);
	}
}
