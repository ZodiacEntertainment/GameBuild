using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public GameObject p1;
	public GameObject p2;
	public GameObject p3;
	public GameObject p4;

	public GameObject hud;
	GameObject HUDtemp;

	public int[] MostAttacks = new int[4];
	public int[] MostTimesInFirst = new int[4];
	public int[] statRef;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
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
		case "Attacks":
			MostAttacks = statRef;
			break;
		case "MTIF":
			MostTimesInFirst = statRef;
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
		case "Attacks":
			statRef = MostAttacks;
			break;
		case "MTIF":
			statRef = MostTimesInFirst;
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
		//spawn huds for players
		GameObject Canvas = GameObject.Find("HUD Canvas");
		for(int i = 0; i < DetermineNumOfPlayers();i++)
			HUDtemp = Instantiate(hud) as GameObject;
		HUDtemp.transform.parent = Canvas.transform;
	}
}
