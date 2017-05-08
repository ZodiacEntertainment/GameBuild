using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour {
    public int sceneToLoad;
    public GameManager man;

    public void OnClick()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
