using UnityEngine;
using System.Collections;

public class GainCrystalPower : MonoBehaviour {
    CrystalManager cm; 
    public bool NearCrystal;
    public bool active;
    public bool returning; 
    public bool red;
    public bool orange;
    public bool yellow;
    public bool green;
    public bool blue;
    public bool purple;
	public Sprite empty;
	public Sprite redSprite;
    public AudioSource collection;
    public AudioSource depower;
    // Use this for initialization
    void Start () {
       cm = GameObject.FindGameObjectWithTag("CrystalManager").GetComponent<CrystalManager>();
        AudioSource[] audios = GetComponents<AudioSource> ();
		collection = audios [0];
		depower = audios [1];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (NearCrystal == true && active == true)
            {
				SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>(); 
				sr.sprite = empty;
                active = false; red = false; orange = false; yellow = false; blue = false; green = false; purple = false;
                collection.Play();
            }
            else if (NearCrystal == true && active == false)
            {
                returning = true;
                if (cm.hasPower == true)
                {
                    print("returning power");
                    if (PlayerStats.HasRed && returning)
                    {
                        PlayerStats.HasRed = false;
                        red = true;
                        returning = false;
						SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>(); 
						sr.sprite = redSprite;
                        depower.Play();
                    }
                    if (PlayerStats.HasYellow && returning)
                    {
                        PlayerStats.HasYellow = false;
                        yellow = true;
                        returning = false;
                    }
                    if (PlayerStats.HasOrange && returning)
                    {
                        PlayerStats.HasOrange = false;
                        orange = true;
                        returning = false;
                    }
                    if (PlayerStats.HasGreen && returning)
                    {
                        PlayerStats.HasGreen = false;
                        green = true;
                        returning = false;
                    }
                    if (PlayerStats.HasBlue && returning)
                    {
                        PlayerStats.HasBlue = false;
                        blue = true;
                        returning = false;
                    }
                    if (PlayerStats.HasPurple && returning)
                    {
                        PlayerStats.HasPurple = false;
                        purple = true;
                        returning = false;
                    }
                    active = true;
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            NearCrystal = true;
            cm.NearCrystal = true;
            if (red) {
                cm.red = true;
                }
            if (blue) {
                cm.blue = true;
                }
            if (yellow)
            {
                cm.yellow = true;
            }
            if (orange)
            {
                cm.orange = true;
            }
            if (green)
            {
                cm.green = true;
            }
            if(purple)
            {
                cm.purple = true;
            }
            }
        }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            NearCrystal = false;
            cm.NearCrystal = false;
        if (red)
        {
            cm.red = false;
        }
        if (blue)
        {
            cm.blue = false;
        }
        if (yellow)
        {
            cm.yellow = false;
        }
        if (orange)
        {
            cm.orange = false;
        }
        if (green)
        {
            cm.green = false;
        }
        if (purple)
        {
            cm.purple = false;
        }
    }
    }
}
    
