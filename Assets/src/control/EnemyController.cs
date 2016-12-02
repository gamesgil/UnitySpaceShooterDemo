using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {
    private List<GameObject> enemies;

    // Use this for initialization
    void Start () {
        enemies = new List<GameObject>();

        GameObject.Find("game timer").GetComponent<GameTimer>().SetTimer(1, Shoot);
    }
	
    public void Shoot()
    {
        GameObject.Find("game timer").GetComponent<GameTimer>().RemoveTimer();

        int rand = Random.Range(0, GameObject.Find("enemies").transform.childCount - 1);
        GameObject.Find("enemies").transform.GetChild(rand).gameObject.GetComponent<Enemy>().Shoot();


    }

	// Update is called once per frame
	void Update () {
	
	}

    public void SetLayout(List<string> layout)
    {
        GameObject enemy = null;
        int baseY = (int)Camera.main.orthographicSize;
        int baseX = -(int)(baseY * Camera.main.aspect);

        for (int y = 0; y < layout.Count; y++)
        {
            for (int x = 0; x < layout[y].Length; x++)
            {
                switch (layout[y][x])
                {
                    case 'a':
                        enemy = Instantiate(Resources.Load("prefabs/enemy-a")) as GameObject;
                        break;

                    case 'b':
                        enemy = Instantiate(Resources.Load("prefabs/enemy-b")) as GameObject;
                        break;
                }
                
                if (enemy)
                {
                    enemy.transform.position = new Vector3(baseX + enemy.GetComponent<Renderer>().bounds.size.x * x, baseY - enemy.GetComponent<Renderer>().bounds.size.y * y, 0);
                    enemy.transform.parent = GameObject.Find("enemies").transform;
                }

                enemy = null;
            }
        }
    }

    public GameObject PickRandomEnemy()
    {
        GameObject result = null;

        if (enemies.Count > 0)
        {
            result = enemies[Random.Range(0, enemies.Count - 1)];
        }

        return result;
    }

    private void AddEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }


}
