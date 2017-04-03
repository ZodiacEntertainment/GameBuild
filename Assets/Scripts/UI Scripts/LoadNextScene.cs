using UnityEngine;
using System.Collections;

public class LoadNextScene : MonoBehaviour {

	public void ChangeToScene(int scene) {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
        Debug.Log("It's been clicked, son.");
	}
}
