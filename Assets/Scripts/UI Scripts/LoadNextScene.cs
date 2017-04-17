using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadNextScene : MonoBehaviour {

    public int scene;

    void TaskOnClick()
    {
        ChangeToScene(scene);
    }

	public void ChangeToScene(int s) {
        UnityEngine.SceneManagement.SceneManager.LoadScene(s);
        Debug.Log("It's been clicked, son.");
	}
}
