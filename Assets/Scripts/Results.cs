using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Results : MonoBehaviour {

    public GameManager manager;
    public int numPlayers;
    //score is a number from 1 to 4 denoting which character was closest to the chariot;
    public int[] scores;
    public GameObject[] places = new GameObject[4];


	// Use this for initialization
	void Start () {
        numPlayers = manager.DetermineNumOfPlayers();
        Debug.Log("Number of Players is " + numPlayers);

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
        
        if(numPlayers < 4)
        {
            for(int i = numPlayers - 1; i < 4; i++)
            {
            }
        }
	}
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < numPlayers - 1; i++)
        {
            places[i].GetComponent<Text>().text = "Player " + scores[i];
        }
    }
}
