using UnityEngine;
using System.Collections;

public class MoveScriptTest : MonoBehaviour {

    public Vector3 relativeLocation;
    public Vector3 startPos;
    public Vector3 targetLocation;
    public float timeDelta;
    public bool displayed;
    public bool canClick;
    public void Awake()
    {
        canClick = true;
        displayed = false;
        startPos = gameObject.transform.position;
       relativeLocation = new Vector3(-800, 0, 0);
	    targetLocation = transform.position + relativeLocation;
		timeDelta = 0.05f;
    }
	public void Clicked()
	{
        if (canClick)
        {
            // Get the target position
            if (!displayed)
            {
                //startPos =- relativeLocation;
                this.StartCoroutine(SmoothMove(targetLocation, timeDelta));
                displayed = true;
            }
            else
            {
                this.StartCoroutine(SmoothMove(startPos, timeDelta));
                displayed = false;
            }
            Debug.Log(""+displayed + startPos);
		    // Start your coroutine
		
        }
        
	}

	IEnumerator SmoothMove(Vector3 target, float delta)
	{
        canClick = false;
		// Will need to perform some of this process and yield until next frames
		float closeEnough = 0.2f;
		float distance = (transform.position - target).magnitude;

		// GC will trigger unless we define this ahead of time
		WaitForEndOfFrame wait = new WaitForEndOfFrame();

		// Continue until we're there
		while(distance >= closeEnough)
		{
			// Confirm that it's moving
			Debug.Log("Executing Movement");

			// Move a bit then  wait until next  frame
			transform.position = Vector3.Slerp(transform.position, target, delta);
			yield return wait;

			// Check if we should repeat
			distance = (transform.position - target).magnitude;
		}

		// Complete the motion to prevent negligible sliding
		transform.position = target;

		// Confirm  it's ended
		Debug.Log ("Movement Complete");
        canClick = true;
	}
}