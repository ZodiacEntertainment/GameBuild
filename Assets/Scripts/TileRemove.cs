using UnityEngine;
using System.Collections;

public class TileRemove : MonoBehaviour {
    LevelGen gen;
    public bool isTile;

    public void Start() {
        gen = GameObject.Find("Main Camera").GetComponent<LevelGen>();
    }

    public void OnDestroy() {
        if(isTile)
            gen.RemoveTile(this.gameObject);
        else
            gen.RemoveBack(this.gameObject);
    }
}
