﻿using UnityEngine;
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
    int Round = 2;

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
            for (int i = 0; i < 2; i++) {
                System.Random rnd = new System.Random();
                int r = rnd.Next(0, tiles.Length);
                selectTiles[i] = tiles[r];
            }
            _bound = other.gameObject;
            _bound.transform.position = new Vector3(_bound.transform.position.x + 14.75f, _bound.transform.position.y, 0);
            ExtendLevel();
            ReduceLevel();
        }
    }

    public void ExtendLevel(){
        for (int j = 0; j < selectTiles.Length; j++){
            backTempCurr = Instantiate(back, new Vector3(backTempCurr.transform.position.x + backOffSet, 0, 1), Quaternion.identity) as GameObject;
            Stands.Add(backTempCurr);
            skyTempCurr = Instantiate(sky, new Vector3(skyTempCurr.transform.position.x + backOffSet, 0, 2), Quaternion.identity) as GameObject;
            Skys.Add(skyTempCurr);
            if (j != selectTiles.Length - 1)
            {
                tileTempCurr = Instantiate(selectTiles[j], new Vector3(tileTempCurr.transform.position.x + backOffSet, 0, 0), Quaternion.identity) as GameObject;
                Tiles.Add(tileTempCurr);
            }
            else{
                if (Round % 2 == 0){
                    tileTempCurr = Instantiate(selectTiles[j], new Vector3(tileTempCurr.transform.position.x + backOffSet, 0, 0), Quaternion.identity) as GameObject;
                    Tiles.Add(tileTempCurr);
                }
            }
        }
        Round++;
    }

    public void ReduceLevel() {
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
