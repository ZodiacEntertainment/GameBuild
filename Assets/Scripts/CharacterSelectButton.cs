using UnityEngine;
using System.Collections;

public class CharacterSelectButton : MonoBehaviour {
	public string CharName;
	public GameManager manager;

	public void OnClick(){
		manager.AssignCharacter (1, CharName);
		Debug.Log ("Character Selected");
	}
}
