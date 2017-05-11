using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadNextScene : MonoBehaviour {

   
	public GameObject gameManager;
	public GameObject hudCanvas;

	private bool clickSoundPlaying;
	private bool soundPlayed;

	public void Start(){
		clickSoundPlaying = false;

	}
	public void ChangeToScene(int scene) {
		if (!clickSoundPlaying) {
			clickSoundPlaying = true;
			StartCoroutine (FullClickSound (scene));
		}
	}

	public IEnumerator FullClickSound(int scene){
		yield return new WaitForSeconds (1.1f);
			if (scene < SceneManager.GetActiveScene ().buildIndex) {
				Destroy (gameManager);
				UnityEngine.SceneManagement.SceneManager.LoadScene (scene);
				Destroy (hudCanvas);
				
			} else {
				UnityEngine.SceneManagement.SceneManager.LoadScene (scene);
			}
		}
	}

