using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieClass : MonoBehaviour {

    public float speedZ;

    // Use this for initialization
    void Start()
    {
        speedZ = 1;
    }

    void Movimentation()
    {
        transform.position -= new Vector3(0, 0, speedZ);
        //GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -50));
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "car")
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        Movimentation();
	}
}
