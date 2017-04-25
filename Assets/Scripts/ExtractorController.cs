using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractorController : MonoBehaviour {
    public GameObject explosionPrefab;

    private Health health;

    void Start() {
        health = GetComponent<Health>();

        if(tag.Equals("Friendly")) {
            GameManager.friendlyIncome++;
        } else if(tag.Equals("Enemy")) {
            GameManager.enemyIncome++;
        } else Debug.LogError("Strange Tag");
    }

    void Update() {
        if(health.IsDead()) {
            Explode();
        }
    }

    private void Explode() {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnDestroy() {
        if(tag.Equals("Friendly")) {
            GameManager.friendlyIncome--;
        } else if(tag.Equals("Enemy")) {
            GameManager.enemyIncome--;
        } else Debug.LogError("Strange Tag");
    }
}