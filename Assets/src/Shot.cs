using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
    public int direction = 1;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 10 * direction, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y > Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }
    }
}
