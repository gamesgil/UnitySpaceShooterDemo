using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager {
    private Levels levels;
    private int curLevelId;

	// Use this for initialization
	public GameManager() {
        curLevelId = 0;

        levels = JsonUtility.FromJson<Levels>(Resources.Load("data/level_data").ToString());
	}
	
    public List<string> GetLayout()
    {
        List<string> result = GetLevel(curLevelId).layout;

        return result;
    }

	private LevelData GetLevel(int id)
    {
        LevelData result = levels.levels[curLevelId];

        return result;
    }
}
