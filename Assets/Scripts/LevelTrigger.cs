using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour {
	
    public int level;

    public GameObject managerObj;
    public GameManager manager;

    void Awake()
    {
        managerObj = GameObject.FindGameObjectWithTag("GameManager") as GameObject;
        manager = managerObj.GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Character") {
            if (other.GetComponent<ZodiacCharacter>().coins == other.GetComponent<ZodiacCharacter>().coinMax)
                manager.getScore();
				SceneManager.LoadScene (level);
		}
    }
}

