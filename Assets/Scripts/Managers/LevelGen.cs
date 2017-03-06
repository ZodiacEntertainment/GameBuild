using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class LevelGen : MonoBehaviour {

    public GameObject[] tiles;
    public GameObject[] selectTiles;
    public GameObject startLine;
    List<GameObject> Tiles = new List<GameObject>();
    public List<GameObject> BackGrounds = new List<GameObject>();
    GameObject last;
    public float backOffSet;
    public GameObject _bound;
    public float boundOffSet;
    private bool limitPlatforms = true;

    // Use this for initialization
    void Start () {
        //start line
        selectTiles = new GameObject[2];
        last = Instantiate(startLine, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        Tiles.Add(last);
        last = last.transform.GetChild(0).gameObject;
        BackGrounds.Add(last);
        ExtendLevelFirst();
	}

    //collision check for 2D project
    public void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Bound") {
            for (int i = 0; i < 2; i++) {
                System.Random rnd = new System.Random();
                int r = rnd.Next(0, tiles.Length);
                selectTiles[i] = tiles[r];
            }
            _bound = other.gameObject;
            _bound.transform.Translate(new Vector3(_bound.transform.position.x + boundOffSet, 0, 0));
            ExtendLevel();
            ReduceLevel();
        }
    }
    public void ExtendLevelFirst() {
        for (int i = 0; i < tiles.Length; i++){
            last = Instantiate(tiles[i], new Vector3(last.transform.position.x + backOffSet, 0, 0), Quaternion.identity) as GameObject;
            Tiles.Add(last);
            last = last.transform.GetChild(0).gameObject;
            BackGrounds.Add(last);
        }
    }

    public void ExtendLevel(){
        for (int j = 0; j < selectTiles.Length; j++){
            last = Instantiate(selectTiles[j], new Vector3(last.transform.position.x + backOffSet, 0, 0), Quaternion.identity) as GameObject;
            Tiles.Add(last);
            last = last.transform.GetChild(0).gameObject;
            //BackGrounds.Add(last);
        }
    }

public void ReduceLevel() {
       for (int r = 0; r < 2; r++) {
            Tiles[0].GetComponent<TileRemove>().Remove();
            //BackGrounds[0].GetComponent<TileRemove>().Remove();
        }
    }
}
