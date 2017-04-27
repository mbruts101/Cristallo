using UnityEngine;
using System.Collections;

public class switchScript : MonoBehaviour {

	public GameObject o;
	public bool nearSwitch = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (nearSwitch && Input.GetKeyDown (KeyCode.Q))
		{
			Destroy (o);
		}
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		nearSwitch = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		nearSwitch = false;
	}
}
