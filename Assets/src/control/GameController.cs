using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    private enum STATUS { READY = 0, PLAYING, PAUSED, GAME_OVER };
    private STATUS status;

	// Use this for initialization
	void Start () {
        status = STATUS.PLAYING;
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
