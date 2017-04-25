using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class AutoDestroyParticleSystem : MonoBehaviour {
    private new ParticleSystem particleSystem;
    private float life = 0.0f;

	void Awake() {
        particleSystem = GetComponent<ParticleSystem>();
	}

	void Update () {
        life += Time.deltaTime;
        if (life >= particleSystem.main.duration + particleSystem.main.startLifetime.constantMax) Destroy(gameObject);
	}
}