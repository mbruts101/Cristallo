using UnityEngine;
using System.Collections;

public class ActiveSpawn : MonoBehaviour {
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.tag = "SpawnPoint";
        }
    }
}
