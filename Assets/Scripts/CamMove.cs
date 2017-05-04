using UnityEngine;
using System.Collections;

public class CamMove : MonoBehaviour{
    //Current camera speed
    public float cameraSpeed;
    //Movement direction true = right
    [Tooltip("Movement to right")]
	public RaceStart RS;

    void Start(){
		
    }

    void Update(){
        if (RS.started){
            transform.Translate(new Vector3(cameraSpeed, 0, 0) * Time.deltaTime);
        }
    }
}
