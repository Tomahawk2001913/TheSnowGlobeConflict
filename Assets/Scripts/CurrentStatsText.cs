using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentStatsText : MonoBehaviour {
    public GameObject friendlySnowmen;
    public GameManager gameManager;

    private Text text;

    void Awake() {
        text = GetComponent<Text>();
    }

	void Update() {
        text.text = "CURRENT SNOWBALLS: " + gameManager.snowballs + "\nCURRENT INCOME: " + GameManager.friendlyIncome + "\nCURRENT SNOWMEN: " + friendlySnowmen.transform.childCount;
	}
}