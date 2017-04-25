using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour {

	Vector2 move = new Vector2(0,0);
	public float HSpeed;
	public float launchForce;
	public GameObject explosion;
	public GameObject owner;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 3f);
		GetComponent<Rigidbody2D>().AddForce(new Vector2(0, launchForce));
	}
	
	// Update is called once per frame
	void Update () {
		move = new Vector2 (HSpeed, 0f);
		transform.Translate (move * Time.deltaTime);
	}
	public void OnDestroy(){
		GameObject temp;
		temp = Instantiate(explosion,transform.position,Quaternion.identity) as GameObject;
		temp.GetComponent<Explosion> ().owner = owner;
	}
}
