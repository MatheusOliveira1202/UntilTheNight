using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {

    public GameObject car;
    public bool needGenerate;

    void spawnCar()
    {
        if (GameObject.FindGameObjectsWithTag("car").Length < 1)
        {
            if (needGenerate)
            {
                Instantiate(car, new Vector3(0, 7, -15), transform.rotation);
                needGenerate = false;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Instantiate(car, new Vector3(0, 7, -15), transform.rotation);
            }
        }
        print(GameObject.FindGameObjectsWithTag("car").Length);
    }

	void Start () {
        needGenerate = true;
	}
	
	void Update () {
        spawnCar();
	}
}
