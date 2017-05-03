using UnityEngine;
using System.Collections;

public class StartMove : MonoBehaviour {
	public RaceStart RS;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (RS.started) {
			transform.Translate (new Vector3 (speed, 0, 0) * Time.deltaTime);
		}
	}
}
