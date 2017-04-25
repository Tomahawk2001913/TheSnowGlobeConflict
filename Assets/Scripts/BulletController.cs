using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    public GameObject explosionPrefab, soundPrefab;
    public float maxLife = 10.0f, damage = 10.0f;

    private float life = 0.0f;

    void Update() {
        life += Time.deltaTime;
        if (life >= maxLife) Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        string oppositeTag = tag.Equals("Friendly") ? "Enemy" : "Friendly";

        if(collision.gameObject.tag.Equals(oppositeTag)) {
            Health hitHealth = collision.gameObject.GetComponent<Health>();
            if(hitHealth != null) {
                hitHealth.Damage(damage);
            }
        }

        Explode();
    }

    private void Explode() {
        Instantiate(soundPrefab, transform.position, Quaternion.identity);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
