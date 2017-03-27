using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour {

    public CamMove cam;

    void OnTriggerEnter2D(Collider2D other)
    {
        cam.cameraSpeed = 0;
        SceneManager.LoadScene(1);
    }

}
