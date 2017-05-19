using UnityEngine;
using System.Collections;

public class Level3 : MonoBehaviour {
    GameObject level3;
    GameManager gm;
	// Use this for initialization
	void Start () {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
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
                level3 = GameObject.FindGameObjectWithTag("level3");
                col.transform.position = level3.transform.position;
                gm.ambiencelvl2.Stop();
                gm.ambiencelvl3.Play();
            }
        }
    }
}
