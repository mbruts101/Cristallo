﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    
    public GameObject playerPrefab;
    private GameObject player;
    public bool takenDamage;
    public bool fallen;
    public bool hasCheckpoint;
    private GameObject[] respawns;
    private AudioSource death;
    public AudioSource ambience;
    public AudioSource ambiencelvl2;
    public AudioSource ambiencelvl3;
    private AudioSource injury;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

	// Use this for initialization
	void Start () {
        AudioSource[] audios = GetComponents<AudioSource>();
        death = audios[0];
        ambience = audios[1];
        injury = audios[2];
        ambiencelvl2 = audios[3];
        ambiencelvl3 = audios[4];
        FindCurrentPlayerObject();
        if(PlayerStats.Health < 0 || PlayerStats.Health > 3)
        {
            PlayerStats.Health = 3;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void checkPlayerLife()
    {
        if(takenDamage)
        {
            print("Checking life");
            PlayerStats.Health--;
            if(PlayerStats.Health > 0 && fallen)
            {
                PlayerStats.HasDied = true;
                injury.Play();
                print("You have fallen");
                Respawn();
            }
            else if(PlayerStats.Health > 0)
            {
                //push player back a little
                takenDamage = false;
            }
            else if (PlayerStats.Health == 0)
            {
                PlayerStats.HasDied = true;
                death.Play();
                Destroy(player);
                Invoke("RestartGame", 6);
            }
        }
        UpdateLife();
    }
    public void Respawn()
    {
        player.transform.position = FindClosestRespawn().transform.position;
    }
    public void FindCurrentPlayerObject()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    GameObject FindClosestRespawn()
    {
        GameObject[] spawns;
        spawns = GameObject.FindGameObjectsWithTag("SpawnPoint");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = player.transform.position;
        foreach(GameObject spawn in spawns)
        {
            Vector3 difference = spawn.transform.position - position;
            float curDistance = difference.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = spawn;
                distance = curDistance;
            }
        }
        return closest;
    }
    public void RestartGame()
    {
        PlayerStats.Health = 3;
        PlayerStats.HasBlue = false;
        PlayerStats.HasRed = false;
        PlayerStats.HasGreen = false;
        PlayerStats.HasOrange = false;
        PlayerStats.HasPurple = false;
        PlayerStats.HasYellow = false;
        Application.LoadLevel(Application.loadedLevel);
    }
    public void UpdateLife()
    {
        if (PlayerStats.Health == 3)
        {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
        }
        else if (PlayerStats.Health == 2)
        {
            life3.SetActive(false);
        }
        else if (PlayerStats.Health == 1)
        {
            life2.SetActive(false);
        }
        else if (PlayerStats.Health == 0)
        {
            life1.SetActive(false);
        }
    }
}
