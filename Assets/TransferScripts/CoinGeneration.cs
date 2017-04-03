using UnityEngine;
using System.Collections;

public class CoinGeneration : MonoBehaviour {
    // The coin prefab.
    public GameObject coinPrefab;
    public GameObject[] spawnPoints;
    private GameObject go;
    private int spawn;

    // Use this for initialization
    void Start ()
    {
        spawn = Random.Range(1, 4); // Pick a spawn point between 1-3.
        Debug.Log("Your number is " + spawn);

        switch (spawn)
        {
            case 1:
                go = Instantiate(coinPrefab, Vector3.zero, Quaternion.identity) as GameObject;
                go.transform.position = spawnPoints[spawn].transform.position;
                break;
            case 2:
                go = Instantiate(coinPrefab, Vector3.zero, Quaternion.identity) as GameObject;
                go.transform.position = spawnPoints[spawn].transform.position;
                break;
            case 3:
                go = Instantiate(coinPrefab, Vector3.zero, Quaternion.identity) as GameObject;
                go.transform.position = spawnPoints[spawn].transform.position;
                break;
            default:
                break;
            
        }

	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
