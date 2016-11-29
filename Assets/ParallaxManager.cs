using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParallaxManager {
    private GameObject container;
    private List<ParallaxLayer> layers;

	public ParallaxManager(GameObject parent)
    {
        container = new GameObject();

        container.transform.SetParent(parent.transform);

        layers = new List<ParallaxLayer>();
    }

    public void Destroy()
    {
       while(layers.Count > 0)
        {
            layers[0].Destroy();
            layers.RemoveAt(0);
        }
    }
	
    public void Add(ParallaxLayer layer)
    {
        layers.Add(layer);
    }

	// Update is called once per frame
	public void Update ()
    {
	    for (int i = 0; i < layers.Count; i++)
        {
            layers[i].Update();
        }
	}

    public GameObject GetContainer()
    {
        return container;
    }
}
