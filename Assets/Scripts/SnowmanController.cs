using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class SnowmanController : MonoBehaviour {
    public GameObject explosionPrefab, extractorPrefab;
    public float speed = 5.0f, attackRadius = 2.5f;

    private Shooter shooter;
    private Health health;
    private GameObject tileMap, targetEnemy;
    private Vector2 targetLocation;

    private bool moving = false;

    // Extractor stuff
    private StorageController sc;
    private bool placingExtractor = false;

    void Start() {
        shooter = GetComponent<Shooter>();
        health = GetComponent<Health>();
        tileMap = GameObject.Find("TileMap");
        targetLocation = transform.position;
        InvokeRepeating("CheckForEnemy", 0.0f, 0.25f);

        if (tag.Equals("Friendly")) sc = GameObject.Find("FriendlyStorage").GetComponent<StorageController>();
        else if (tag.Equals("Enemy")) sc = GameObject.Find("EnemyStorage").GetComponent<StorageController>();
        else Debug.LogError("Unknown Tag!");
    }

	void Update() {
        if (health.IsDead()) Explode();
        if (UpdatePosition() && placingExtractor) {
            if (GetClosestTile(transform.position).GetTileType() == 2 && sc.RemoveSnowballs(10)) {
                Instantiate(extractorPrefab, transform.position, Quaternion.identity);
                GetClosestTile(transform.position).ChangeType(0);
            } else Debug.Log("Unable to build extractor for reasonable reasons.");
            placingExtractor = false;
        }
        ShootEnemy();
        CheckForSmallSnow();
    }

    private bool UpdatePosition() {
        if (Vector2.Distance(transform.position, targetLocation) > 0.05f)
            transform.position = Vector2.MoveTowards(transform.position, targetLocation, speed * Time.deltaTime);
        else {
            transform.position = targetLocation;
            moving = false;
            return true;
        }
        moving = true;
        return false;
    }

    private void CheckForEnemy() {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, attackRadius, Vector2.zero);
        string oppositeTag = tag.Equals("Friendly") ? "Enemy" : "Friendly";
        foreach(RaycastHit2D hit in hits) {
            if(hit.collider.tag.Equals(oppositeTag)) {
                targetEnemy = hit.collider.gameObject;
                return;
            }
        }
        targetEnemy = null;
    }

    private void CheckForSmallSnow() {
        Tile test = GetClosestTile(transform.position);
        if(test.GetTileType() == 1) {
            test.ChangeType(0);
            if (health.GetHealthPercentage() <= 0.75f) health.Heal(health.maxHealth);
            else sc.AddSnowballs(5);
        }
    }

    private void ShootEnemy() {
        if (targetEnemy != null) if (shooter.ShootAt(targetEnemy.transform.position)) health.Damage(5);
    }

    public void MoveTo(Vector2 target) {
        targetLocation = GetClosestTile(target).transform.position;
    }

    public Tile GetClosestTile(Vector2 target) {
        Tile closestTile = tileMap.transform.GetChild(0).GetComponent<Tile>();
        float closestDistance = Vector2.Distance(target, closestTile.transform.position);

        foreach(Transform tile in tileMap.transform) {
            float testDistance = Vector2.Distance(target, tile.position);
            if(testDistance < closestDistance) {
                closestTile = tile.GetComponent<Tile>();
                closestDistance = testDistance;
            }
        }

        return closestTile;
    }

    public Tile GetClosestBigSnowTile(Vector2 target) {
        Tile closestTile = null;
        float closestDistance = -1;

        foreach (Transform tile in tileMap.transform) {
            float testDistance = Vector2.Distance(target, tile.position);
            if (closestDistance == -1 || testDistance < closestDistance) {
                Tile testTile = tile.GetComponent<Tile>();
                closestTile = testTile.GetTileType() == 2 ? testTile : closestTile;
                closestDistance = testDistance;
            }
        }

        return closestTile;
    }

    public bool IsMoving() {
        return moving;
    }

    public void BuildExtractor(Vector2 target) {
        MoveTo(target);
        placingExtractor = true;
    }

    public void Explode() {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}