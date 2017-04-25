using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLocationClamp : MonoBehaviour {
    public float maxTravel = 7.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 clamped = Vector2.ClampMagnitude(transform.position, maxTravel);
        clamped.z = transform.position.z;
        transform.position = clamped;
	}
}
