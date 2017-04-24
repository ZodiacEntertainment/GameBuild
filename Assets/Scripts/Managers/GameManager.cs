using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject alexis;
	public GameObject flub;

	public GameObject p1;
	public GameObject p2;
	public GameObject p3;
	public GameObject p4;

	public GameObject p1HUD;
	public GameObject p2HUD;
	public GameObject p3HUD;
	public GameObject p4HUD;

	//char select points
	public Transform h1;
	public Transform h2;
	public Transform h3;
	public Transform h4;

	//game spawn points
	public Transform SP1;
	public Transform SP2;
	public Transform SP3;
	public Transform SP4;

	public int[] MostDamageTaken = new int[]{0,0,0,0};
	public int[] MostTimesInFirst = new int[]{0,0,0,0};
	public int[] MostDamageGiven = new int[]{0,0,0,0};
	public int[] MostCoins = new int[]{0,0,0,0};
	public int[] statRef;

	bool gameStarted = false;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
	}
	public void Update(){
		if (SceneManager.GetActiveScene ().name == "Mode1" && !gameStarted)
			CreateGame ();
	}

	public void StatUpdate(string player, string stat){
		//assign stat to ref
		DetermineStat(stat);
		//Increment stat
		switch(player){
		case "p1":
			statRef [0]++;
			break;
		case "p2":
			statRef [1]++;
			break;
		case "p3":
			statRef [2]++;
			break;
		case "p4":
			statRef [3]++;
			break;
		}
		//assign ref to stat
		switch(stat){
		case "MDT":
			MostDamageTaken = statRef;
			break;
		case "MTIF":
			MostTimesInFirst = statRef;
			break;
		case "MDG":
			MostDamageGiven = statRef;
			break;
		case "MC":
			MostCoins = statRef;
			break;
		default :
			break;
		}
	}
	public int[] Results(string stat){
		DetermineStat (stat);
		int[] result = new int[2];
		int top = 0;
		int playerNum = 0;
		for (int i = 0; i < 4; i++)
			if (statRef [i] > top)
				top = statRef [i];
		for (int i = 0; i < 4; i++)
			if (top == statRef [i])
				playerNum = i + 1;
		result [0] = playerNum;
		result [1] = top;
		return result;
	}
	public void DetermineStat(string stat){
		switch(stat){
		case "MDT":
			statRef = MostDamageTaken;
			break;
		case "MTIF":
			statRef = MostTimesInFirst;
			break;
		case "MDG":
			statRef = MostDamageGiven;
			break;
		case "MC":
			statRef = MostCoins;
			break;
		default :
			Debug.Log ("Check stat name");
			break;
		}
	}
	public int DetermineNumOfPlayers(){
		int players = 0;
		if (p1 != null) {
			players++;
			if (p2 != null) {
				players++;
				if (p3 != null) {
					players++;
					if (p4 != null) {
						players++;
					}
				}
			}
		}
		else
			Debug.Log ("Zero players found");

		return players;
	}
	public void CreateGame(){
		//spawn character for game
		for(int i = 1; i <= DetermineNumOfPlayers(); i++){
			switch (i) {
			case 1:
				//p1.transform.position = SP1.position;
				p1HUD.SetActive (true);
				//p1.GetComponent<CharacterMovement>().grounded = false;
				break;
			case 2:
				//p2.transform.position = SP2.position;
				p2HUD.SetActive (true);
				//p2.GetComponent<CharacterMovement>().grounded = false;
				break;
			case 3:
				p3.transform.position = SP3.position;
				p3HUD.SetActive (true);
				p3.GetComponent<CharacterMovement>().grounded = false;
				break;
			case 4:
				p4.transform.position = SP4.position;
				p4HUD.SetActive (true);
				p4.GetComponent<CharacterMovement>().grounded = false;
				break;
			}
		}
	}
	public void AssignCharacter(int player, string name){
		//alexis
		if (name == "Alexis") {
			switch(player){
			case 1:
				if (p1 == null) {
					p1 = Instantiate (alexis, h1.position, Quaternion.identity) as GameObject;
					p1.transform.SetParent (this.transform, true);
					p1.GetComponent<Alexis> ().controller = "p1";
					p1.GetComponent<CharacterMovement>().controller = "p1";
					p1.GetComponent<Alexis> ().manager = this;
					p1HUD.GetComponent<UIManager> ().character = p1;
				}
				break;
			case 2:
				if (p2 == null) {
					p2 = Instantiate (alexis, h2.position, Quaternion.identity) as GameObject;
					p2.transform.SetParent (this.transform, true);
					p2.GetComponent<Alexis> ().controller = "p2";
					p2.GetComponent<CharacterMovement>().controller = "p2";
					p2.GetComponent<Alexis> ().manager = this;
					p2HUD.GetComponent<UIManager> ().character = p2;
				}
				break;
			case 3:
				if (p3 == null) {
					p3 = Instantiate (alexis, h3.position, Quaternion.identity) as GameObject;
					p3.transform.SetParent (this.transform, true);
					p3.GetComponent<Alexis> ().controller = "p3";
					p3.GetComponent<CharacterMovement>().controller = "p3";
					p3.GetComponent<Alexis> ().manager = this;
					p3HUD.GetComponent<UIManager> ().character = p3;
				}
				break;
			case 4:
				if (p4 == null) {
					p4 = Instantiate (alexis, h4.position, Quaternion.identity) as GameObject;
					p4.transform.SetParent (this.transform, true);
					p4.GetComponent<Alexis> ().controller = "p4";
					p4.GetComponent<CharacterMovement>().controller = "p4";
					p4.GetComponent<Alexis> ().manager = this;
					p4HUD.GetComponent<UIManager> ().character = p4;
				}
				break;
			}
		}
		//flub
		if (name == "Flub") {
			switch(player){
			case 1:
				p1 = Instantiate (flub, transform.position, Quaternion.identity) as GameObject;
				p1.GetComponent<Flub> ().controller = "p1";
				p1HUD.GetComponent<UIManager>().character = p1;
				break;
			case 2:
				p2 = Instantiate (flub, transform.position, Quaternion.identity) as GameObject;
				p2.GetComponent<Flub> ().controller = "p2";
				p2HUD.GetComponent<UIManager> ().character = p2;
				break;
			case 3:
				p3 = Instantiate (flub, transform.position, Quaternion.identity) as GameObject;
				p3.GetComponent<Flub> ().controller = "p3";
				p3HUD.GetComponent<UIManager>().character = p3;
				break;
			case 4:
				p4 = Instantiate (flub, transform.position, Quaternion.identity) as GameObject;
				p4.GetComponent<Flub> ().controller = "p4";
				p4HUD.GetComponent<UIManager>().character = p3;
				break;
			}
		}
	}
}
