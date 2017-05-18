using UnityEngine;
using System.Collections;

public class LevelChange : MonoBehaviour {
    GameObject level2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                level2 = GameObject.FindGameObjectWithTag("level2");
                col.transform.position = level2.transform.position;
            }
        }
    }
}
