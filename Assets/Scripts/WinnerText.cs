using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class WinnerText : MonoBehaviour {
    public GameManager gameManager;

    private Text text;

	void Start() {
        text = GetComponent<Text>();
        text.text = gameManager.GetWinner() == "Friendly" ? "Congratulations, you have conquered the evil snowmen." : (gameManager.GetWinner() == "Enemy" ? "You were conquered by the evil snowmen.\nHow predictable..." : text.text);
	}
}
