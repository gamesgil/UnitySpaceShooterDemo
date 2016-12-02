using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level {
    private int id;
    private int progressId;
    private List<string> layout;
    
    public Level(int id)
    {
        this.id = id;
        progressId = 0;
        layout = new List<string>() { "   aaa   ", "  aaaaa " };
    }

    public List<string> GetLayout()
    {
        return layout;
    }

    public int GetId()
    {
        return id;
    }
}
