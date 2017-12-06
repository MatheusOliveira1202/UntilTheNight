using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSpawner : MonoBehaviour {

    public GameObject road;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            for(int i = 0; i < 20; i++)
            {
                Instantiate(road, new Vector3(0, -2, (i * 12)), transform.rotation);
            }
        }
		
	}
}
