using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCamera : MonoBehaviour {
    public float minDragDetectDist = 2f, speed = 0.25f;

    private bool beingDragged = false, checking = false;
    private Vector3 lastPosition = Vector2.zero;
	
	void Update () {
        if (Input.GetMouseButtonUp(0)) { beingDragged = false; checking = false; }
        if (!checking && Input.GetMouseButtonDown(0)) { lastPosition = Input.mousePosition; checking = true; return; }
        if(checking && Vector2.Distance(lastPosition, Input.mousePosition) > minDragDetectDist) { checking = false; beingDragged = true; }

        if(beingDragged) {
            transform.position += (lastPosition - Input.mousePosition) * speed;
            lastPosition = Input.mousePosition;
        }
	}
}
