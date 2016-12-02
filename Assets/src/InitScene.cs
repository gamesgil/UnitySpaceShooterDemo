using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScene : MonoBehaviour {
    private ParallaxManager parallaxBg;
    private GameManager gm;

    // Use this for initialization
    void Start()
    {
        gm = new GameManager();

        parallaxBg = new ParallaxManager(GameObject.Find("bg"));

        ParallaxLayer nearLayer = new ParallaxLayer(parallaxBg.GetContainer());
        ParallaxLayer farLayer = new ParallaxLayer(parallaxBg.GetContainer());

        nearLayer.Speed = 0.05f;
        farLayer.Speed = 0.01f;

        GameObject star;
        Material mat;
        Color color;

        for (int i = 0; i < 10; i++)
        {
            star = GameObject.Instantiate(Resources.Load("prefabs/star-1")) as GameObject;
            star.transform.position = new Vector3(Random.Range(-Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize * Camera.main.aspect), Random.Range(-Camera.main.orthographicSize, Camera.main.orthographicSize), 0);

            mat = star.GetComponent<Renderer>().material;
            color = new Color(mat.color.r, mat.color.g, mat.color.b, mat.color.a / 2);
            mat.color = color;

            nearLayer.AddElement(star);
        }

        for (int i = 0; i < 30; i++)
        {
            star = GameObject.Instantiate(Resources.Load("prefabs/star-2")) as GameObject;
            star.transform.position = new Vector3(Random.Range(-Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize * Camera.main.aspect), Random.Range(-Camera.main.orthographicSize, Camera.main.orthographicSize), 0);

            mat = star.GetComponent<Renderer>().material;
            color = new Color(mat.color.r, mat.color.g, mat.color.b, mat.color.a / 4);
            mat.color = color;

            farLayer.AddElement(star);
        }

        parallaxBg.Add(nearLayer);
        parallaxBg.Add(farLayer);

        GameObject.Find("enemy controller").GetComponent<EnemyController>().SetLayout(gm.GetLayout());
    }
	
	// Update is called once per frame
	void Update () {
        parallaxBg.Update();
    }

    public void Destroy()
    {
        parallaxBg.Destroy();
    }

    
}
