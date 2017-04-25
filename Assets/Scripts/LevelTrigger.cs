using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour {

    public CamMove cam;
    public Chariot chariot;
    public int level;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (chariot.triggered)
        {
            cam.cameraSpeed = 0;
            SceneManager.LoadScene(level);
        }
    }

}
