using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public int damage;
	public GameObject owner;
	[SerializeField] public AudioClip boomClip;
	private AudioSource boomSource;
	public GameObject justHit;

	// Use this for initialization
	void Start () {
		boomSource = GetComponent<AudioSource>();
		boomSource.PlayOneShot(boomClip);
		Destroy (this.gameObject, 0.5f);	//Destroy delay (too short), explosion animation (too short?), and explosion sound effect (too long) all need to sync up.
	}
	public void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Character" && other.gameObject.GetInstanceID() != owner.gameObject.GetInstanceID() && justHit.GetInstanceID() != other.gameObject.GetInstanceID()) {
			other.GetComponent<ZodiacCharacter>().TakeDamage(damage);
			owner.GetComponent<Alexis> ().AttackUpdate (damage);
			justHit = other.gameObject;
		}
	}
}
