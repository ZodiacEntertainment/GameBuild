using UnityEngine;
using System.Collections;

public class CharacterSelectButton : MonoBehaviour {
	public string CharName;
	public GameManager manager;

	//assign player 1 only
	public void OnClick(){
		manager.AssignCharacter (1, CharName);
		//Debug.Log ("Character Selected");
	}
	//assign all
	public void Update (){
		if(Input.GetAxis("p1Jump") > 0.5f){
			manager.AssignCharacter (1, CharName);
		}
		if(Input.GetAxis("p2Jump") > 0.5f){
			manager.AssignCharacter (2, CharName);
		}
		if(Input.GetAxis("p3Jump") > 0.5f){
			manager.AssignCharacter (3, CharName);
		}
		if(Input.GetAxis("p4Jump") > 0.5f){
			manager.AssignCharacter (4, CharName);
		}
	}
}
