using UnityEngine;
using System.Collections;

public class GainCrystalPower : MonoBehaviour {
    CrystalManager cm; 
    public bool NearCrystal;
    public bool active = true;
	// Use this for initialization
	void Start () {
       cm = GameObject.FindGameObjectWithTag("CrystalManager").GetComponent<CrystalManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (NearCrystal == true && active == false)
            {
                active = false;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            print("colliding with crystal");
            NearCrystal = true;
            cm.NearCrystal = true;
            switch (this.gameObject.tag)
            {
                case "RedCrystal":
                    cm.red = true;
                    break;
                case "BlueCrystal":
                    cm.blue = true;
                    break;
                case "YellowCrystal":
                    cm.yellow = true;
                    break;
                case "OrangeCrystal":
                    cm.orange = true;
                    break;
                case "GreenCyrstal":
                    cm.green = true;
                    break;
                case "PurpleCrystal":
                    cm.purple = true;
                    break;
            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            NearCrystal = false;
            print("the power fades");
            cm.NearCrystal = false;
            switch (this.gameObject.tag)
            {
                case "RedCrystal":
                    cm.red = false;
                    break;
                case "BlueCrystal":
                    cm.blue = false;
                    break;
                case "YellowCrystal":
                    cm.yellow = false;
                    break;
                case "OrangeCrystal":
                    cm.orange = false;
                    break;
                case "GreenCyrstal":
                    cm.green = false;
                    break;
                case "PurpleCrystal":
                    cm.purple = false;
                    break;
            }
        }
    }
    
}
