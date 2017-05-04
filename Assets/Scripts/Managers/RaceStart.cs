using UnityEngine;
using System.Collections;
//using UnityEngine.UI;

public class RaceStart : MonoBehaviour {
	public bool started;
	public float countDownTime;
	float counter;
	//public Text text;

	// Use this for initialization
	void Start () {
		//StartCoroutine(CountDown());
		counter = countDownTime;

	}
	
	// Update is called once per frame
	void Update () {
		counter -= Time.deltaTime;
	}

//	public IEnumerator CountDown() {
//		if (counter > 0) {
//			yield return new WaitForSeconds (1f);
//			Debug.Log (counter);
//			counter--;
//			if (counter != 0) {
//				text.text = counter.ToString();
//				StartCoroutine (CountDown ());
//			} else {
//				text.text = "GO";
//				started = true;
//				StartCoroutine (CountDown ());
//			}
//		} else
//			Destroy (text.transform.parent.gameObject);

//	}
	public void OnGUI(){
		if (counter > 0) {
			GUILayout.Label ("Start " + counter);
		}
	}
}
