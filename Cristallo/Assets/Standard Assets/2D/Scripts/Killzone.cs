using UnityEngine;
using System.Collections;

public class Killzone : MonoBehaviour {
    GameManager gm;
	// Use this for initialization
	void Start () {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            gm.takenDamage = true;
            gm.fallen = true;
            gm.checkPlayerLife();
        }
    }
}
