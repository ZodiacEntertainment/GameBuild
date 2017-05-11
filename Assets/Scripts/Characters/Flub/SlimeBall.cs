using UnityEngine;
using System.Collections;

public class SlimeBall : MonoBehaviour {

	Vector2 move = new Vector2(0,0);
	public float HSpeed;
	public float launchForce;
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
		Destroy (this.gameObject);
	}
	public void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Character") {
			if (other.gameObject.GetInstanceID () != owner.gameObject.GetInstanceID ())
			if (!other.GetComponent<ZodiacCharacter> ().isStunned && other.GetComponent<ZodiacCharacter> ().isInvincible == false) {
					other.GetComponent<ZodiacCharacter> ().TakeDamage (owner.GetComponent<Flub> ().spDamage);
					Destroy (this.gameObject);
				}
		}
		if(other.gameObject.layer == 9)
			Destroy (this.gameObject);
	}
}
