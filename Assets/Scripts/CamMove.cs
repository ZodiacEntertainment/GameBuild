using UnityEngine;
using System.Collections;

public class CamMove : MonoBehaviour{
    //Current camera speed
    public float cameraSpeed;
    //Movement direction true = right
    [Tooltip("Movement to right")]
    bool forward = false;
    public LevelGen Generater;
    public int _countDown;

    void Start(){
        Generater = GetComponent<LevelGen>();
        StartCoroutine(CountDown());
    }

    void Update(){
        if (forward){
            transform.Translate(new Vector3(cameraSpeed, 0, 0) * Time.deltaTime);
            foreach (GameObject back in Generater.BackGrounds){
                back.transform.Translate(new Vector3(-cameraSpeed, 0, 0) * Time.deltaTime);
            }
        }
    }
    public IEnumerator CountDown() {
        yield return new WaitForSeconds(_countDown);
        forward = true;

    }
}
