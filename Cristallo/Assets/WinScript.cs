using UnityEngine;
using System.Collections;

public class WinScript : MonoBehaviour {
    GameObject endzone;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                endzone = GameObject.FindGameObjectWithTag("endzone");
                col.transform.position = endzone.transform.position;
            }
        }
    }
}
