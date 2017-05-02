using UnityEngine;
using System.Collections;

public class collectable : MonoBehaviour {
	public GameObject g;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		Destroy (g);
	}
}
