using UnityEngine;
using System.Collections;

public class switchScript : MonoBehaviour {
	public GameObject o;
	public Sprite s;
	public Sprite s1;
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
			SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>(); 
			sr.sprite = s1;
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
