using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RaceStart : MonoBehaviour {
	public bool started;
	public float countDownTime;
	float counter;
	public Text text;
    public GameObject barriers;

	// Use this for initialization
	void Start () {
		//StartCoroutine(CountDown());
		counter = countDownTime;

	}
	
	// Update is called once per frame
	void Update () {
		counter -= Time.deltaTime;
        if(counter <= 4 && counter > 3){
            text.text = "3";
        }else if(counter <= 3 && counter > 2){
            text.text = "2";
        }else if(counter <= 2 && counter > 1){
            text.text = "1";
        } else if(counter < 1 && counter > 0){
            barriers.SetActive(false);
            started = true;
            text.text = "GO!";
        }else{
            text.text = null;
        }
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
	//public void OnGUI(){
	//	if (counter > 0) {
	//		GUILayout.Label ("Start " + Mathf.RoundToInt(counter));
	//	}
	//}
}
