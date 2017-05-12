using UnityEngine;
using System.Collections;

public class monsterTrigger : MonoBehaviour
{
	private int t;
	public int distance;
	public int speed;
	public int c;
	// Use this for initialization
	GameManager gm;
	void Start () 
	{
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		t = 0;
		distance = distance + 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.Translate(Vector3.right * speed * Time.deltaTime);
		if ((t - c) % distance == 0) 
		{
			speed = -speed;
		}
		t++;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			gm.takenDamage = true;
			gm.fallen = true;
			gm.checkPlayerLife();
		}
	}
}
