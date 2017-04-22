using UnityEngine;
using System.Collections;

public class crystalTrigger : MonoBehaviour 
{
	public Collider2D collider1;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other == collider1)
		{
			print ("HEY");
		}
	}
}
