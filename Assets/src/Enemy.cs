using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	// Use this for initialization
	void Start () {
        
	}
	
    public void Shoot()
    {
        Vector3 pos = transform.position;

        GameObject shot = Instantiate(Resources.Load("prefabs/shot"), pos, new Quaternion()) as GameObject;
        shot.GetComponent<Shot>().direction = -1;
        
    }
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            GameObject.Destroy(gameObject);
            GameObject.Destroy(collider.gameObject);
        }
    }

    public void OnCompleteFlight(string param)
    {
        print("TEST: " + param);
    }
}
