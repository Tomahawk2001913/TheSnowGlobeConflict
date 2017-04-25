using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    private int type = 0;
    public bool randomize = false;

    private TileMap parent;
    private SpriteRenderer spriteRenderer;

	void Start () {
        parent = transform.parent.GetComponent<TileMap>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (randomize) {
            float random = Random.Range(0.0f, 1.0f);
            if (random <= 0.2) ChangeType(1);
            else if (random >= 0.9f) ChangeType(2);
        } else ChangeType(0);
	}

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject go = collision.gameObject;
        Health health = go.GetComponent<Health>();
        if (health != null && health.GetHealth() < health.maxHealth && type > 0) {
            health.Heal(health.maxHealth);
            if (type == 1) ChangeType(0);
        }
    }

    public GameObject GetClosestObject(GameObject list) {
        if (list.transform.childCount <= 0) return null;
        float closestDistance = Vector2.Distance(transform.position, list.transform.GetChild(0).position);
        GameObject closestObject = list.transform.GetChild(0).gameObject;

        foreach(Transform current in list.transform) {
            float testDistance = Vector2.Distance(transform.position, current.position);
            if (testDistance < closestDistance) {
                closestDistance = testDistance;
                closestObject = current.gameObject;
            }
        }

        return closestObject;
    }

    public void ChangeType(int type) {
        this.type = type;
        TileMap.TileType tt = parent.types[type];
        spriteRenderer.sprite = tt.sprite == null ? spriteRenderer.sprite : tt.sprite;
        name += " : " + tt.name;
    }

    public int GetTileType() {
        return type;
    }
}
