using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    
    public GameObject playerPrefab;
    private GameObject player;
    public bool takenDamage;
    public bool fallen;
    public bool hasCheckpoint;
    private GameObject[] respawns;
    private AudioSource death;

	// Use this for initialization
	void Start () {
        AudioSource[] audios = GetComponents<AudioSource>();
        death = audios[0];
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
                death.Play();
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
                PlayerStats.Health = 3;
                PlayerStats.HasBlue = false;
                PlayerStats.HasRed = false;
                Application.LoadLevel(Application.loadedLevel);
            }
        }
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
}
