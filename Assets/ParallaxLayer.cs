using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParallaxLayer {
    private List<GameObject> elements = new List<GameObject>();
    public float Speed { get; set; }
    public GameObject container;

    public ParallaxLayer(GameObject container)
    {
        this.container = container;
    }

    public void Destroy()
    {
        while (elements.Count > 0)
        {
            GameObject.Destroy(elements[0]);
            elements.RemoveAt(0);
        }

        GameObject.Destroy(container);
    }

	// Update is called once per frame
	public void Update () {
        Vector3 newPos;

        foreach(GameObject obj in elements)
        {
            newPos = new Vector3(obj.transform.position.x, obj.transform.position.y - Speed, obj.transform.position.z);

            if (newPos.y < -Camera.main.orthographicSize)
            {
                newPos.y = Camera.main.orthographicSize;
            }

            obj.transform.position = newPos;
        }
	}

    public void AddElement(GameObject obj) {
        obj.transform.SetParent(container.transform);

        elements.Add(obj);
    }
}
