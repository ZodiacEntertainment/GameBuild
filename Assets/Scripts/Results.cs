using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Results : MonoBehaviour {

    public GameManager manager;
    public int numPlayers;
    //score is a number from 1 to 4 denoting which character was closest to the chariot;
    public int[] scores;
    public GameObject[] places;


	// Use this for initialization
	void Start () {
        numPlayers = manager.DetermineNumOfPlayers();

        /* scores = new int[numPlayers];

         for(int i = 0; i < numPlayers-1; i++)
         {
             scores[i] = 0;
         }

         for(int i = 0; i < numPlayers - 1; i++){
             Player p = players[i];
             if(p.score > scores[i])
             {
                 for(int x = numPlayers - 1; x > i; x--)
                 {
                     scores[x] = scores[x - 1];
                     playerPositions[x] = playerPositions[x - 1];

                 }
                 scores[i] = p.score;
                 playerPositions[i] = p;
             }
         }*/

        scores = manager.score;
        places = new GameObject[manager.DetermineNumOfPlayers()];
	}
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < numPlayers - 1; i++)
        {
            places[i].GetComponent<Text>().text = "Player " + scores[i];
        }
    }
}
