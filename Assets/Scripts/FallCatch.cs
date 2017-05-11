using UnityEngine;
using System.Collections;

public class FallCatch : MonoBehaviour {

	public GameObject[] respawn;
	public float verticalThrust = 5f;
	public float horizontalThrust = 5f;

	public void OnTriggerExit2D (Collider2D other){
		if (other.tag == "Character") {
			Rigidbody2D body = other.GetComponent<Rigidbody2D>();
			other.gameObject.transform.position = respawn[Random.Range(0,respawn.Length)].transform.position;

			// Left Spawnpoint
			if(other.gameObject.transform.position == respawn[0].transform.position){
				body.velocity = new Vector2(-horizontalThrust, verticalThrust);
			}
			// Middle Spawnpoint
			if (other.gameObject.transform.position == respawn[1].transform.position)
			{
				body.velocity = new Vector2(0, verticalThrust);
			}
			// Right Spawnpoint
			if (other.gameObject.transform.position == respawn[2].transform.position)
			{
				body.velocity = new Vector2(horizontalThrust, verticalThrust);
			}
		}
	}
}
