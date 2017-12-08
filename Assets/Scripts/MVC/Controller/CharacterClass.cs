using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClass : MonoBehaviour {

    public string _name;
    public string _id;
    public float _speedX;
    public float _speedY;
    public float _width;
    public float _height;
    public float speedAccelerometer;
    //value -1 to left side, value 0 to center and value 1 to right side
    public int positionInRoad;
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    // Use this for initialization
    void Start()
    {
        _speedX = 50;
        speedAccelerometer = 10;
        positionInRoad = 0;
    }

    /*void AccelerometerFunction()
    {
        Vector3 dirAccelerometer = Vector3.zero;
        dirAccelerometer.x = -Input.acceleration.y;
        dirAccelerometer.z = Input.acceleration.x;
        if (dirAccelerometer.sqrMagnitude > 1)
            dirAccelerometer.Normalize();

        dirAccelerometer *= Time.deltaTime;
        transform.Translate(dirAccelerometer * speedAccelerometer);
    }*/

    /*public void SwipeMobile()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                //swipe upwards
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    Debug.Log("up swipe");
                }
                //swipe down
                if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    Debug.Log("down swipe");
                }
                //swipe left
                if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    Debug.Log("left swipe");
                }
                //swipe right
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    Debug.Log("right swipe");
                }
            }
        }
    }*/

    public void SwipePC()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe.Normalize();

            //swipe upwards
            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                Debug.Log("up swipe");
            }
            //swipe down
            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                Debug.Log("down swipe");
            }
            //swipe left
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                if(transform.position.x >= -10 && transform.position.x <= 10)
                {
                    goToposition(new Vector3(transform.position.x - 10, transform.position.y, transform.position.z), positionInRoad, positionInRoad - 1);
                    Debug.Log("left swipe");
                }
            }
            //swipe right
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                if(transform.position.x >= -10 && transform.position.x <= 10)
                {
                    goToposition(new Vector3(transform.position.x + 10, transform.position.y, transform.position.z), positionInRoad, positionInRoad + 1);
                    Debug.Log("right swipe");
                }
            }
        }
    }



    void goToposition(Vector3 EndPosition, int actualPosition, int finalPosition)
    {
        if(this.transform.position != EndPosition)
        {
            while(/*actualPosition < finalPosition && */this.transform.position.x < EndPosition.x)
            {
                transform.position += new Vector3(0.0001f, 0, 0);
            }
            while (/*actualPosition > finalPosition && */this.transform.position.x > EndPosition.x)
            {
                transform.position -= new Vector3(0.0001f, 0, 0);
            }
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "road")
        {
            print("collision detected");
        }
    }

    void testMovement()
    {
        if (Input.GetKey("right"))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(_speedX,0,0));
        }
        if (Input.GetKey("left"))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-_speedX, 0, 0));
        }
        if (Input.GetKey("up"))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, _speedX));
        }
        if (Input.GetKey("down"))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -_speedX));
        }
    }

    void DestroyManager()
    {
        if (this.transform.position.y < -50)
        {
            Destroy(gameObject);
        }
    }

	void Update () {
        SwipePC();
        testMovement();
        DestroyManager();
	}
}
