using UnityEngine;
using System.Collections;

public class prompt : MonoBehaviour {
	public Sprite s1;
	public Sprite s2;
	private SpriteRenderer sr;
	// Use this for initialization
	void Start () 
	{
		sr = gameObject.GetComponent<SpriteRenderer>(); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		sr.sprite = s1;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		sr.sprite = s2;
	}
}
