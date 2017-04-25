using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour {
    public static Selectable selected = null;

    private Vector2 originalPosition = Vector2.zero;
    private bool checking = false;

	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            originalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Vector2.Distance(originalPosition, transform.position) < 0.75f) checking = true;
        } else if (Input.GetMouseButtonUp(0) && Vector2.Distance(Input.mousePosition, Camera.main.WorldToScreenPoint(originalPosition)) < 10.0f) {
            if (checking) {
                selected = this;
                checking = false;
            } else if(selected == this) selected = null;
        }  
    }

    public void ForceUnselect() { selected = null; }

    public bool IsSelected() {
        return selected == this;
    }
}
