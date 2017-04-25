using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {
    public AudioClip sound;
    public bool destroyAfterPlay = false;

    private new AudioSource audio;
	
	void Start () {
        audio = GetComponent<AudioSource>();
        audio.clip = sound;
        audio.loop = false;
        if (destroyAfterPlay) audio.Play();
	}

    void Update() {
        if (destroyAfterPlay && !audio.isPlaying) Destroy(gameObject);
    }

	public void PlaySound() {
        audio.Play();
    }
}
