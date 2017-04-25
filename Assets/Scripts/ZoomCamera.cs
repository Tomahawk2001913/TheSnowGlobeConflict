using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ZoomCamera : MonoBehaviour {
    public float referenceSize = 1.3f;

    private new Camera camera;

    void Awake() {
        camera = GetComponent<Camera>();
    }

    public void SetZoom(float zoom) {
        camera.orthographicSize = referenceSize * zoom;
    }
}
