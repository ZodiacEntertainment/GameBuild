using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour {
    public int sceneToLoad;

    public void OnClick()
    {
        SceneManager.LoadScene(sceneToLoad);
        //Debug.Log("It's been clicked, son.");
    }

}
