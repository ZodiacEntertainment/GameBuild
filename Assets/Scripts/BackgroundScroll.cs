using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {
    public Renderer rend;
    public float scrollSpeed;
	public CamMove camRef;
    
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
	}

    // Update is called once per frame
    void Update()
    {
		if (camRef.forward) {
			float offset = Time.time * scrollSpeed;
			rend.material.SetTextureOffset ("_MainTex", new Vector2 (offset, 0));
		}
    }
}
