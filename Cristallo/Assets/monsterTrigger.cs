using UnityEngine;
using System.Collections;

public class monsterTrigger : MonoBehaviour
{
	private int t;
	public int speed;
	// Use this for initialization
	void Start () 
	{
		t = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.Translate(Vector3.right * speed * Time.deltaTime);
		if (t % 150 == 0) 
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
