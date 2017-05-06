using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour {
	
    public int level;
	public GameManager manager;

    void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Character") {
			if (other.GetComponent<ZodiacCharacter> ().coins == other.GetComponent<ZodiacCharacter> ().coinMax)
				SceneManager.LoadScene (level);
		}
    }
}

