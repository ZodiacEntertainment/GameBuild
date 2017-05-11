using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class LevelTrigger : MonoBehaviour {
	
    public int level;
    public GameObject[] players;
    public GameObject managerObj;
    public GameManager manager;

    void Awake(){
        managerObj = GameObject.FindGameObjectWithTag("GameManager") as GameObject;
        manager = managerObj.GetComponent<GameManager>();
        players = GameObject.FindGameObjectsWithTag("Character");
    }

    void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Character") {
            if (other.GetComponent<ZodiacCharacter>().coinLevel == other.GetComponent<ZodiacCharacter>().coinMax)
            {
                manager.score[0] = determinePlayerNum(other.gameObject);

                if (manager.DetermineNumOfPlayers() > 1)
                {

                    Array.Sort(players, delegate (GameObject X, GameObject Y) { return X.transform.position.x.CompareTo(Y.transform.position.x); });
                    for(int select = 1; select < players.Length; select++)
                    {
                        if (players[select] != null) manager.score[select] = determinePlayerNum(players[select-1]);
                    }
                }
                SceneManager.LoadScene(level);
            }      
		}
    }

    int determinePlayerNum(GameObject player)
    {
        if (player == manager.p1) return 1;
        if (player == manager.p2) return 2;
        if (player == manager.p3) return 3;
        if (player == manager.p4) return 4;
        else return 0;
    }
}

