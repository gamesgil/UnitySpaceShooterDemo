using UnityEngine;
using System.Collections.Generic;

public class Ship : MonoBehaviour {
    private float acceleration = -0.5f;
    private float xMove = 0;
    private int direction = 0;
    private List<GameObject> shots = new List<GameObject>();
    private float lastShotTime = -1;

	// Use this for initialization
	void Start () {
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(xMove * direction, 0, 0);

        if (direction != 0)
        {
            xMove += acceleration;

            if (xMove <= 0)
            {
                direction = 0;
                xMove = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("right"))
        {
            direction = 1;
            xMove = 5;
        }
        else if (Input.GetKey("left"))
        {
            direction = -1;
            xMove = 5;
        }
        
        if (Input.GetKeyUp("space") && Time.time - lastShotTime > 1)
        {
            lastShotTime = Time.time;

            GameObject shot = Instantiate(Resources.Load("prefabs/shot"), new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), new Quaternion()) as GameObject;

            shot.tag = "Player";
            shots.Add(shot);
        }
        
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //if (collider.tag == "Player")
        {
            GameObject.Destroy(gameObject);
            GameObject.Destroy(collider.gameObject);
        }
    }
}
