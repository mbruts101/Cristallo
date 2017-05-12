using UnityEngine;
using System.Collections;

public class closetTrigger : MonoBehaviour {
	public Camera o;
	private bool near;
	// Use this for initialization
	void Start () {
		near = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (near && (Input.GetKeyDown (KeyCode.Q))) 
		{
			Destroy (o);	
		}
	}

	void OnTriggerLeave2D(Collider2D other)
	{
		near = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		near = true;
	}
}
