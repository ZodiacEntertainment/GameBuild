using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class LevelGen : MonoBehaviour {

    public GameObject[] tiles;
    public GameObject back;
    public GameObject sky;
    [HideInInspector]
    public GameObject[] selectTiles;
    public GameObject startLine;
    public GameObject startBack;
    [HideInInspector]
    public List<GameObject> Tiles = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> Stands = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> Skys = new List<GameObject>();
    GameObject backTempCurr;
    GameObject tileTempCurr;
    GameObject skyTempCurr;
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
        backTempCurr = Instantiate(startBack, new Vector3(0, 0, 1), Quaternion.identity) as GameObject;
        Stands.Add(backTempCurr);
        skyTempCurr = Instantiate(sky, new Vector3(0, 0, 2), Quaternion.identity) as GameObject;
        Skys.Add(skyTempCurr);
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
            backTempCurr = Instantiate(back, new Vector3(backTempCurr.transform.position.x + backOffSet, 0, 1), Quaternion.identity) as GameObject;
            Stands.Add(backTempCurr);
            skyTempCurr = Instantiate(sky, new Vector3(skyTempCurr.transform.position.x + backOffSet, 0, 2), Quaternion.identity) as GameObject;
            Skys.Add(skyTempCurr);
            tileTempCurr = Instantiate(selectTiles[j], new Vector3(tileTempCurr.transform.position.x + backOffSet, 0, 0), Quaternion.identity) as GameObject;
            Tiles.Add(tileTempCurr);
            if (Round % 4 == 0){
				backTempCurr = Instantiate(back, new Vector3(backTempCurr.transform.position.x + backOffSet, 0, 1), Quaternion.identity) as GameObject;
				Stands.Add(backTempCurr);
				Round++;
            }
        }
        Round++;
    }

    public void ReduceLevel() {
		if(Round > 3)
       	for (int r = 0; r < extendLength; r++) {
            Stands[0].GetComponent<TileRemove>().Remove();
            Stands.Remove(Stands[0]);
            if(r != extendLength-1){
                Tiles[0].GetComponent<TileRemove>().Remove();
                Tiles.Remove(Tiles[0]);
                Skys[0].GetComponent<TileRemove>().Remove();
                Skys.Remove(Skys[0]);
            }
        }
    }
}
