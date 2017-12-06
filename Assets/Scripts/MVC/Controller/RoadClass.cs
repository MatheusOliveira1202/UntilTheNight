using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadClass : MonoBehaviour {

    public string _name;
    public string _id;
    public float _speedX;
    public float _speedY;
    public float _width;
    public float _height;

    void movement()
    {
        transform.position += new Vector3(0, 0, -1);
    }

    // Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        movement();	
	}
}
