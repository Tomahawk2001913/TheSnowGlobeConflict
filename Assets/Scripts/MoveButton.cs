using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour {
    public GameObject clickedLabel;
    public bool onlyMobile = false;

    private Selectable wasSelected = null;
    private bool checking = false, checkingUp = false;

    void Start() {
        if (onlyMobile && Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.IPhonePlayer && Application.platform != RuntimePlatform.WebGLPlayer) gameObject.SetActive(false);
    }

    void Update() {
        if (wasSelected != null) {
            Selectable.selected = wasSelected;
        }

        if(checking && Input.GetMouseButtonDown(0)) {
            Selectable selected = Selectable.selected;
            if (selected != null) {
                SnowmanController sc = selected.GetComponent<SnowmanController>();
                if (sc != null) sc.MoveTo(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            checking = false;
            checkingUp = true;
            clickedLabel.SetActive(false);
        }

        if(checkingUp && Input.GetMouseButtonUp(0)) {
            checkingUp = false;
            wasSelected = null;
        }
    }

    public void Clicked() {
        checking = true;
        clickedLabel.SetActive(true);
        wasSelected = Selectable.selected;
    }
}
