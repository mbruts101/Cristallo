using UnityEngine;
using System.Collections;

public class platform : MonoBehaviour {
	public int speed;
	public int t;
	public int c;
	public int distance;
	// Use this for initialization
	void Start () 
	{
		t = 0;
		distance = distance + 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.Translate(Vector3.right * speed * Time.deltaTime);
		if ((t - c) % distance == 0) 
		{
			speed = -speed;
		}
		t++;
	}
}
