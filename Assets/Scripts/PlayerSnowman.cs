using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SnowmanController))]
public class PlayerSnowman : MonoBehaviour {
    public Light selectedLight;

    private SnowmanController snowmanController;
    private Selectable selectable;

	void Awake() {
        snowmanController = GetComponent<SnowmanController>();
        selectable = GetComponent<Selectable>();
	}
	
	void Update() {
        if (selectable.IsSelected()) {
            if (Input.GetMouseButtonDown(1)) snowmanController.MoveTo(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            selectedLight.enabled = true;
        } else selectedLight.enabled = false;
	}
}
