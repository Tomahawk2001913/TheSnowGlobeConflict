using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildExtractor : MonoBehaviour {
    public GameManager gameManager;
    public GameObject selectingText;
    private bool selecting = false;
	
	void Update() {
        if (selecting && Input.GetMouseButtonDown(0)) {
            gameManager.AttemptToBuildExtractor(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            selecting = false;
            selectingText.SetActive(false);
        }
	}

    public void StartSelecting() {
        selecting = true;
        selectingText.SetActive(true);
    }
}
