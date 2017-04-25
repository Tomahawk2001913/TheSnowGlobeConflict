using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    public AudioClip music;

    private AudioSource source;

	void Start() {
        source = GetComponent<AudioSource>();
        source.clip = music;
        source.loop = true;
        source.Play();
	}
}
