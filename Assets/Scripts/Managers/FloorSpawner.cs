using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour {

    public bool needGenerate;
    public GameObject road;

    void InstantiateFloor()
    {
        if(GameObject.FindGameObjectWithTag("road") != null)
        {
            if (GameObject.FindGameObjectsWithTag("road")[0].transform.position.z <= -110)
            {
                needGenerate = true;
            }
        }
        if (GameObject.FindGameObjectsWithTag("road").Length > 2)
        {
            Destroy(GameObject.FindGameObjectsWithTag("road")[0]);
        }
        if(needGenerate)
        {
            Instantiate(road, new Vector3(0, -15, 100), transform.rotation);
            needGenerate = false;
        }
    }


	// Use this for initialization
	void Start () {
        needGenerate = true;
	}
	
	// Update is called once per frame
	void Update () {
        InstantiateFloor();
	}
}
