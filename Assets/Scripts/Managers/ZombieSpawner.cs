using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

    public bool needGenerate;
    public float timeToInstantiateZombie;
    public float maxTimetoInstatiateZombie;
    public float minPositionXToInstatiate;
    public float maxPositionXToInstatiate;
    public GameObject zombie;

    void Start()
    {
        needGenerate = false;
        timeToInstantiateZombie = 0;
        maxTimetoInstatiateZombie = 10f;
        minPositionXToInstatiate = -15;
        maxPositionXToInstatiate = 15;
    }

    void InstantiateZombies()
    {
        if (needGenerate)
        {
            Instantiate(zombie, new Vector3(Random.Range(minPositionXToInstatiate, maxPositionXToInstatiate), 0, 150), transform.rotation);
            needGenerate = false;
        }
    }

    void Timer()
    {
        if (!needGenerate)
        {
            timeToInstantiateZombie += 0.1f;
        }
        if (timeToInstantiateZombie >= maxTimetoInstatiateZombie)
        {
            needGenerate = true;
            timeToInstantiateZombie = 0;
        }
    }
	
	void Update () {
        InstantiateZombies();
        Timer();
	}
}
