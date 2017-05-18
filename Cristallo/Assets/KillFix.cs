using UnityEngine;
using System.Collections;

public class KillFix : MonoBehaviour {
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
        if (col.gameObject.tag == "Player")
        {
            PlayerStats.Health += 1;
            gm.takenDamage = true;
            gm.fallen = true;
            gm.checkPlayerLife();
            this.gameObject.SetActive(false);
        }
    }
}
