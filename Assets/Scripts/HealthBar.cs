using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    private Health health;

	void Awake() {
        health = transform.parent.GetComponent<Health>();
	}
	
	void Update() {
        transform.localScale = new Vector3(health.GetHealthPercentage(), 1.0f, 1.0f);
	}
}
