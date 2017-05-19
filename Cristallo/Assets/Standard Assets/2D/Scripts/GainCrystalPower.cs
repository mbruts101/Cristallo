using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    public Sprite greenSprite;
    public Sprite purpleSprite;
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
            //Taking a Power
            if (NearCrystal == true && active == true && PlayerStats.HasPower == false)
            {
                SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
                sr.sprite = empty;
                collection.Play();

                if (cm.NearCrystal == true)
                {
                    if (cm.red == true)
                    {
                        PlayerStats.HasRed = true;
                        print("got double jump");
                        cm.red = false;
                        cm.ColorManager.Add("red");
                    }
                    else if (cm.yellow == true)
                    {
                        PlayerStats.HasYellow = true;
                        cm.yellow = false;
                    }
                    else if (cm.orange == true)
                    {
                        PlayerStats.HasOrange = true;
                        cm.orange = false;
                    }
                    else if (cm.green == true)
                    {
                        PlayerStats.HasGreen = true;
                        print("Got Shrink");
                        cm.green = false;
                        cm.ColorManager.Add("green");
                    }
                    else if (cm.blue == true)
                    {
                        PlayerStats.HasBlue = true;
                        cm.blue = false;
                    }
                    else if (cm.purple == true)
                    {
                        PlayerStats.HasPurple = true;
                        print("has gravity shift");
                        cm.purple = false;
                        cm.ColorManager.Add("purple");
                    }
                    active = false; red = false; orange = false; yellow = false; blue = false; green = false; purple = false;
                    PlayerStats.HasPower = true;
                    print(cm.ColorManager[0]);
                }
            }
            //Returning Power to Empty Crystal
            else if (NearCrystal == true && active == false && !PlayerStats.IsSmall)
            {
                returning = true;
                if (PlayerStats.HasPower == true)
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
                    else if (PlayerStats.HasYellow && returning)
                    {
                        PlayerStats.HasYellow = false;
                        yellow = true;
                        returning = false;
                    }
                    else if (PlayerStats.HasOrange && returning)
                    {
                        PlayerStats.HasOrange = false;
                        orange = true;
                        returning = false;
                    }
                    else if (PlayerStats.HasGreen && returning && PlayerStats.IsSmall == false)
                    {
                        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
                        PlayerStats.HasGreen = false;
                        green = true;
                        sr.sprite = greenSprite;
                        returning = false;
                    }
                    else if (PlayerStats.HasBlue && returning)
                    {
                        PlayerStats.HasBlue = false;
                        blue = true;
                        returning = false;
                    }
                    else if (PlayerStats.HasPurple && returning)
                    {
                        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
                        PlayerStats.HasPurple = false;
                        purple = true;
                        sr.sprite = purpleSprite;
                        returning = false;
                    }
                    PlayerStats.HasPower = false;
                    active = true;
                }
            }
            //Swapping Powers
            else if(NearCrystal == true && active == true && PlayerStats.HasPower == true && !PlayerStats.IsSmall)
            {
                collection.Play();
                if (cm.red)
                {
                    cm.ColorManager.Add("red");
                    PlayerStats.HasRed = true;
                    red = false;
                    cm.red = false;
                }
                else if (cm.purple)
                {
                    cm.ColorManager.Add("purple");
                    PlayerStats.HasPurple = true;
                    purple = false;
                    cm.purple = false;
                }
                else if (cm.green)
                {
                    cm.ColorManager.Add("green");
                    PlayerStats.HasGreen = true;
                    green = false;
                    cm.green = false;
                }
                SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
                print(cm.ColorManager[0]);
                print(cm.ColorManager[1]);
                switch (cm.ColorManager[0])
                {
                    case "red":
                        sr.sprite = redSprite;
                        red = true;
                        PlayerStats.HasRed = false;
                        break;
                    case "green":
                        sr.sprite = greenSprite;
                        green = true;
                        PlayerStats.HasGreen = false;
                        break;
                    case "purple":
                        sr.sprite = purpleSprite;
                        PlayerStats.HasPurple = false;
                        purple = true;
                        break;

                }
                cm.ColorManager[0] = cm.ColorManager[1];
                cm.ColorManager.RemoveAt(1);

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
    
