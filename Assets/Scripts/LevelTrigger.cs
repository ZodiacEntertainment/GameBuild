using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour {

    public CamMove cam;
	public int level;

    void OnTriggerEnter2D(Collider2D other)
    {
        cam.cameraSpeed = 0;
		SceneManager.LoadScene(level);
    }

}
