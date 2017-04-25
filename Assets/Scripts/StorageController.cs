using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageController : MonoBehaviour {
    public GameObject snowmanPrefab, explosionPrefab, snowmanList;
    public GameManager gameManager;

    private Health health;
    private int snowballs = 60;

    void Start() {
        health = GetComponent<Health>();
        InvokeRepeating("GenerateIncome", 1.0f, 1.0f);
        if (tag.Equals("Enemy")) InvokeRepeating("BuildSnowman", 5.0f, 7.5f);
    }

    void Update() {
        if (health.IsDead()) { snowballs = 0; Explode(); }
        if (gameManager != null) gameManager.snowballs = snowballs;
    }

    private void GenerateIncome() {
        snowballs += tag.Equals("Friendly") ? GameManager.friendlyIncome : GameManager.enemyIncome;
    }

    public void AddSnowballs(int amount) {
        snowballs += amount;
    }

    public bool RemoveSnowballs(int amount) {
        if (snowballs >= amount) { snowballs -= amount; return true; }
        return false;
    }

    public void BuildSnowman() {
        if (snowballs >= 25) {
            snowballs -= 25;
            Instantiate(snowmanPrefab, transform.position, Quaternion.identity).transform.SetParent(snowmanList.transform);
        } else if(gameManager != null) Debug.Log("Insufficient Snowballs");
    }

    public void Explode() {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
