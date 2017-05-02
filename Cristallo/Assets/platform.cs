using UnityEngine;
using System.Collections;

public class platform : MonoBehaviour {
	public int speed;
	public int t;
	public int c;
	public int distance;
	public bool up;
	public bool waitForTrigger;
	// Use this for initialization
	void Start () 
	{
		t = 0;
		distance = distance + 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!waitForTrigger)
		{
			if (up) {
				this.transform.Translate (Vector3.up * speed * Time.deltaTime);
			} else {
				this.transform.Translate (Vector3.right * speed * Time.deltaTime);
			}
			if ((t - c) % distance == 0) 
			{
				speed = -speed;
			}
			t++;
		}
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		waitForTrigger = false;
	}
}
