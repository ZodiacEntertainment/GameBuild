using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grenade : MonoBehaviour {

	Vector2 move = new Vector2(0,0);
	public float HSpeed;
	public float launchForce;
	public GameObject explosion;
	public GameObject owner;
	public float life;

	// Use this for initialization
	void Start () {
		StartCoroutine (LifeSpan());
		//Destroy (this.gameObject, 3f);
		GetComponent<Rigidbody2D>().AddForce(new Vector2(0, launchForce));
	}
	
	// Update is called once per frame
	void Update () {
		move = new Vector2 (HSpeed, 0f);
		transform.Translate (move * Time.deltaTime);
	}

	public IEnumerator LifeSpan(){
		yield return new WaitForSeconds (life);
		SpawnExplosion ();
	}
	public void SpawnExplosion(){
		Destroy (gameObject);
		GameObject temp;
		temp = Instantiate(explosion,transform.position,Quaternion.identity) as GameObject;
		temp.GetComponent<Explosion> ().owner = owner;
	}
	public void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Character") {
			if (other.gameObject.GetInstanceID() != owner.gameObject.GetInstanceID())
				SpawnExplosion ();
		}
	}
}
