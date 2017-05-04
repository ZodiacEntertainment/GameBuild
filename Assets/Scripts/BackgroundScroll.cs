using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {
    public Renderer rend;
    public float scrollSpeed;
	public RaceStart RS;
	public float offset;
    
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
	}

    // Update is called once per frame
    void Update()
    {
		if (RS.started) {
			offset = Time.time * scrollSpeed;
			rend.material.SetTextureOffset ("_MainTex", new Vector2 (offset, 0));
		}
    }
}
