using UnityEngine;
using System.Collections;

public class CamMove : MonoBehaviour{
    //Current camera speed
    public float cameraSpeed;
    //Movement direction true = right
    [Tooltip("Movement to right")]
    public bool forward = false;
    public LevelGen Generater;
    public int _countDown;

    void Start(){
        Generater = GameObject.Find("TriggerPoint").GetComponent<LevelGen>();
        StartCoroutine(CountDown());
    }

    void FixedUpdate(){
        if (forward){
            transform.Translate(new Vector3(cameraSpeed, 0, 0) * Time.deltaTime);
//            foreach (GameObject back in Generater.Stands){
//                if(back != null)
//                    back.transform.Translate(new Vector3(-cameraSpeed/4f, 0, 0) * Time.deltaTime);
//            }
//            foreach (GameObject sky in Generater.Skys){
//                if (sky != null)
//                    sky.transform.Translate(new Vector3(-cameraSpeed / 8f, 0, 0) * Time.deltaTime);
//            }
        }
    }
    public IEnumerator CountDown() {
        yield return new WaitForSeconds(_countDown);
        forward = true;

    }
}
