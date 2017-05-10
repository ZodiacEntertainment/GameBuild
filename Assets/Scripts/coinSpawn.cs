using UnityEngine;
using System.Collections;

public class coinSpawn : MonoBehaviour {
    public GameObject[] coins;
	// Use this for initialization
	void Start () {
        int rand = Random.Range(0, coins.Length);
        Instantiate(coins[rand], transform.position, transform.rotation);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
