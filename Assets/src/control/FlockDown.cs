using UnityEngine;
using System.Collections;

public class FlockDown : IMovement {

	public void Move(GameObject entity)
    {
        Hashtable props = new Hashtable();
        props.Add("x", 0);
        props.Add("y", 0);
        props.Add("time", 2);
        props.Add("easetype", "EaseInOutSine");
        props.Add("oncomplete", "OnCompleteFlight");
        props.Add("oncompleteparams", "wrap");

        iTween.MoveTo(entity, props);
    }
}
