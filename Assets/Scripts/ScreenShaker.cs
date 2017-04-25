using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShaker : MonoBehaviour {
    public GameObject shake;
    public float intensity = 1.0f;

    private Vector3 originalPosition;

    void Start() {
        originalPosition = shake.transform.position;
        shake.transform.SetParent(transform);
        InvokeRepeating("RandomizePosition", 0.0f, 0.05f);
    }

	private void RandomizePosition() {
        shake.transform.position = new Vector3(Random.Range(originalPosition.x - intensity, originalPosition.x + intensity), Random.Range(originalPosition.y - intensity, originalPosition.y + intensity), originalPosition.z);
	}
}