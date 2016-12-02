using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour  {
    public delegate void Timer();
    public Timer OnTimer;
    private float startTime;
    private float duration;

    public void SetTimer(float time, Timer onTimer)
    {
        OnTimer = onTimer;
        startTime = Time.time;
        duration = time;
    }

    public void RemoveTimer()
    {
        OnTimer = null;
    }

	// Use this for initialization
	void Start () {
	    
	}

    // Update is called once per frame
    void Update() {
        if (OnTimer != null)
        {
            if (Time.time - startTime >= duration)
            {
                MonoBehaviour.print("TIME");
                OnTimer();
            }
        }
        
	}
}
