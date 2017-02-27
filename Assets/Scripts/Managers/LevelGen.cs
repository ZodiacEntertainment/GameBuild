using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGen : MonoBehaviour {
    public GameObject[] tiles;
    public GameObject startLine;
    List<GameObject> Tiles = new List<GameObject>();
    public List<GameObject> BackGrounds = new List<GameObject>();
    GameObject last;
    public float backOffSet;
    public GameObject _bound;
    public float boundOffSet;

	// Use this for initialization
	void Start () {
        //start line
        last = Instantiate(startLine, new Vector3(0, 0, 10), Quaternion.identity) as GameObject;
        Tiles.Add(last);
        last = last.transform.GetChild(0).gameObject;
        BackGrounds.Add(last);
        ExtendLevel();
	}

    //collision check for 2D project
    public void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Bound") {
            _bound = other.gameObject;
            _bound.transform.Translate(new Vector3(_bound.transform.position.x + boundOffSet, _bound.transform.position.y, _bound.transform.position.z));
            ExtendLevel();
            ReduceLevel();
        }
    }
    //extends level by 3 tiles and removes oldest 3 tiles
    public void ExtendLevel() {
        for (int i = 1; i < tiles.Length; i++){
            last = Instantiate(tiles[i], new Vector3(last.transform.position.x + backOffSet, 0, 10), Quaternion.identity) as GameObject;
            Tiles.Add(last);
            last = last.transform.GetChild(0).gameObject;
            BackGrounds.Add(last);
        }
    }

    public void ReduceLevel() {
        for (int r = 0; r < 3; r++){
            Destroy(Tiles[2 - r].gameObject);
            Destroy(BackGrounds[2 - r].gameObject);
        }
    }

    public void RemoveBack(GameObject go) {
        BackGrounds.Remove(go);
    }
    public void RemoveTile(GameObject go){
        Tiles.Remove(go);
    }
}
