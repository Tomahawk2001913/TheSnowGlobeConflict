using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Timer : MonoBehaviour {
    public GameManager gameManager;
    public float time = 300;

    private Text text;

	void Awake() {
        text = GetComponent<Text>();
	}

	void Update() {
        time -= Time.deltaTime;
        if(time <= 0) {
            time = 0;
            gameManager.gameOver = true;
        }

        int seconds = (int)(time % 60);
        text.text = (int) (time / 60) + ":" + (seconds >= 10 ? seconds + "" : ("0" + seconds));
	}
}
