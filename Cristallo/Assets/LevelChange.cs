using UnityEngine;
using System.Collections;

public class LevelChange : MonoBehaviour {
    GameObject level2;
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
        if(col.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                level2 = GameObject.FindGameObjectWithTag("level2");
                col.transform.position = level2.transform.position;
                gm.ambience.Stop();
                gm.ambiencelvl2.Play();
            }
        }
    }
}
