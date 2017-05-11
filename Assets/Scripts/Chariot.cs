using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Chariot : MonoBehaviour {

	public float Speed;
	public float time;
	public bool canMove;
	public GameObject[] players;
	bool showFirstTime = true;

    void Start()
    {	
		players = GameObject.FindGameObjectsWithTag ("Character");
		canMove = false;
    }

	// Update is called once per frame
	void Update () {
		
		foreach (GameObject p in players) {
			if (p.GetComponent<ZodiacCharacter> ().coinLevel == 6 && showFirstTime) {
				canMove = true;
				showFirstTime = false;
				StartCoroutine (Appear ());
			}
		}
		if (canMove) {
			transform.Translate (-Speed * Time.deltaTime, 0, 0);
		}

	}

	public IEnumerator Appear(){
		yield return new WaitForSeconds (time);
		canMove = false;
		Debug.Log ("WOah there");
	}
}
    