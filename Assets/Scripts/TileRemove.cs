using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileRemove : MonoBehaviour {

    public void Remove() {
        Destroy(this.gameObject, 0.5f);
    }
}
