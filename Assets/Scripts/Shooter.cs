using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    public GameObject bulletPrefab;
    public float bulletSpeed = 7.5f, shootDelay = 1.25f;

    private float lastShot = 0.0f;

    public bool ShootAt(Vector2 target) {
        if(Time.time - lastShot >= shootDelay) {
            lastShot = Time.time;
            Vector2 direction = -((Vector2) transform.position - target);
            direction.Normalize();
            GameObject bullet = Instantiate(bulletPrefab, transform.position + (Vector3) direction * 0.5f, Quaternion.identity);
            Rigidbody2D brb = bullet.GetComponent<Rigidbody2D>();
            brb.velocity = direction * bulletSpeed;
            bullet.tag = tag;
            return true;
        }

        return false;
    }
}
