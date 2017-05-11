using UnityEngine;
using System.Collections;

public class bounceScript : MonoBehaviour {
    private AudioSource bounce;
	// Use this for initialization
	void Start () {
        AudioSource[] audios = GetComponents<AudioSource>();
        bounce = audios[0];
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            bounce.Play();
        }
    }
}
