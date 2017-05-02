using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour {

    public CamMove cam;
    public Chariot chariot;
    public int level;
    GameObject gameManager;
    GameManager manager;


    void Start(){
        gameManager = GameObject.FindWithTag("GameManager");
        manager = gameManager.GetComponent<GameManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (chariot.triggered)
        {
            SceneManager.LoadScene(level);
        }
    }

}
