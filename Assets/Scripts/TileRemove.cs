using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileRemove : MonoBehaviour {
    LevelGen gen;
    public bool isTile;

    public void Start() {
        gen = GameObject.Find("TriggerPoint").GetComponent<LevelGen>();
    }

    public void Remove() {
        Destroy(this.gameObject, 0.5f);
    }
}
