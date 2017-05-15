using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CrystalManager : MonoBehaviour {
    public bool NearCrystal;
    public bool active;
    public bool red;
    public bool orange;
    public bool yellow;
    public bool green;
    public bool blue;
    public bool purple;
    public List<string> ColorManager;
    // Use this for initialization
    void Start () {
        ColorManager = new List<string>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
