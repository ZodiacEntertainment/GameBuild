using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Results : MonoBehaviour {

    public GameObject managerObj;
    public GameManager manager;
    public int numPlayers;
    //score is a number from 1 to 4 denoting which character was closest to the chariot;
    public int[] scores;
    public GameObject[] places;
    public PlayerStats[] statPanes;

    public Image loserText;
    public Image winner;

    void Awake() {
        managerObj = GameObject.FindGameObjectWithTag("GameManager") as GameObject;
        manager = managerObj.GetComponent<GameManager>();
    }

	// Use this for initialization
	void Start () {
        numPlayers = GameObject.FindGameObjectsWithTag("Character").Length;

        string[] statTypes = new string [4] {"MDG", "MC", "MTIF", "MDT"};
        Vector3[] vectors = new Vector3[] { places[0].transform.position, places[1].transform.position, places[2].transform.position, places[3].transform.position };

        //statLists: a list that holds the lists of values for each stat. first array is stat, second array is player.
        int[][] statLists = new int[][] { manager.MostDamageGiven, manager.MostCoins, manager.MostTimesInFirst, manager.MostDamageTaken };

        scores = manager.score;
        winner.GetComponent<Image>().sprite = manager.profiles[scores[0]-1];

        //deactive unneeded graphics
        for(int i = 3; i >= numPlayers; i--)
        {
            places[i].SetActive(false);
            statPanes[i].setActive(false);
        }

        loserText.transform.position = new Vector3(loserText.transform.position.x, vectors[numPlayers - 1].y, vectors[numPlayers - 1].z);

        //run through players in order of the position they came in, setting their number at that position and displaying their stats
        for (int i = 0; i < numPlayers; i++)
        {
            //sets player number at place i. scores[i] is the player number
            places[scores[i] - 1].GetComponentInChildren<Text>().text = "Player " + (scores[i]).ToString();
            places[scores[i] - 1].transform.position = vectors[i];

            //runs through and displays stats
            for(int s = 0; s < 4; s++)
            {
                statPanes[scores[i]-1].setStat(statTypes[s], statLists[s][scores[i] - 1]);
            }
            
        }

      /*  //find the player with the top score for each stat and change that stats icon color in their panel
        for (int i = 0; i < 4; i++)
        {
            int[] topStat = manager.Results(statTypes[i]);
            statPanes[topStat[0] - 1].setTopStat(statTypes[i]);
        }*/
    }
}
