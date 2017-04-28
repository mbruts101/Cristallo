using UnityEngine;
using System.Collections;

public class monsterTrigger : MonoBehaviour
{
	private int t;
	public int distance;
	public int speed;
	public int c;
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

	void OnTriggerEnter2D(Collider2D other)
	{
		Destroy (other.gameObject);
	}
}
