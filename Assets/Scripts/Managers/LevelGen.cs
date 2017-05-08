using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class LevelGen : MonoBehaviour {

    public GameObject[] tiles;
    [HideInInspector]
    public GameObject[] selectTiles;
    public GameObject startLine;
    [HideInInspector]
    public List<GameObject> Tiles = new List<GameObject>();
    GameObject tileTempCurr;
    public float backOffSet;
    public GameObject _bound;
    public float boundOffSet;
    public int extendLength;
	//Dont touch
    int Round = 1;

    // Use this for initialization
    void Start () {
        //start line
        selectTiles = new GameObject[extendLength];
        tileTempCurr = Instantiate(startLine, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        Tiles.Add(tileTempCurr);
        for (int i = 0; i < extendLength; i++){
            System.Random rnd = new System.Random();
            int r = rnd.Next(0, tiles.Length);
            selectTiles[i] = tiles[r];
        }
        ExtendLevel();
    }

    //collision check for 2D project   //  Bound offset control
    public void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Bound") {
			for (int i = 0; i < extendLength; i++) {
                System.Random rnd = new System.Random();
				int r = rnd.Next(0, tiles.Length- i);
				r += i;
                selectTiles[i] = tiles[r];
            }
            _bound = other.gameObject;
            _bound.transform.position = new Vector3(_bound.transform.position.x + 15f, _bound.transform.position.y, 0);
//			if(Tiles.Count < 10){
//				ExtendLevel();
//			}
			ExtendLevel();
            ReduceLevel();
        }
    }

    public void ExtendLevel(){
		for (int j = 0; j < extendLength; j++){
            tileTempCurr = Instantiate(selectTiles[j], new Vector3(tileTempCurr.transform.position.x + backOffSet, 0, 0), Quaternion.identity) as GameObject;
            Tiles.Add(tileTempCurr);
        }
        Round++;
    }

    public void ReduceLevel() {
		if(Round > 3)
       	for (int r = 0; r < extendLength; r++) {
            if(r != extendLength-1){
                Tiles[0].GetComponent<TileRemove>().Remove();
                Tiles.Remove(Tiles[0]);
            }
        }
    }
}
