using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SnowmanController))]
public class SnowmanAI : MonoBehaviour {
    private SnowmanController snowmanController;
    private float frozenTime = 0.0f;
    private Vector2 enemyLocation = Vector2.zero;

    private enum AIStates { DECIDING, MOVING, FROZEN, ATTACKING, EXTRACTORBUILDING }
    private AIStates state = AIStates.DECIDING;

	void Start () {
        snowmanController = GetComponent<SnowmanController>();
        GameObject enemyStorage = GameObject.Find("FriendlyStorage");
        if(enemyStorage != null) enemyLocation = enemyStorage.transform.position;
	}

	void Update () {
        switch (state) {
            case AIStates.DECIDING:
                float randomNumber = Random.Range(0.0f, 1.0f);
                if (randomNumber <= 0.1f) { state = AIStates.FROZEN; frozenTime = 0.0f; }
                else if (randomNumber <= 0.3f) { state = AIStates.ATTACKING; snowmanController.MoveTo(GetLocationNear(enemyLocation)); }
                else if (randomNumber <= 0.5f) {
                    state = AIStates.EXTRACTORBUILDING;
                    Tile closestBigSnowTile = snowmanController.GetClosestBigSnowTile(transform.position);
                    if (closestBigSnowTile != null) snowmanController.BuildExtractor(closestBigSnowTile.transform.position);
                } else { state = AIStates.MOVING; snowmanController.MoveTo(snowmanController.GetClosestTile(GetLocationNear(transform.position, 7)).transform.position); }
                break;
            case AIStates.MOVING:
                if (!snowmanController.IsMoving()) state = AIStates.DECIDING;
                break;
            case AIStates.FROZEN:
                frozenTime += Time.deltaTime;
                if (frozenTime >= 2.5f) {
                    state = AIStates.DECIDING;
                    frozenTime = 0.0f;
                }
                break;
            case AIStates.ATTACKING:
                if (!snowmanController.IsMoving()) state = AIStates.FROZEN;
                break;
            case AIStates.EXTRACTORBUILDING:
                if (!snowmanController.IsMoving()) state = AIStates.DECIDING;
                break;
        }
	}

    private Vector2 GetLocationNear(Vector2 location, float within = 1.5f) {
        Vector2 near;

        near.x = Random.Range(location.x - within, location.x + within);
        near.y = Random.Range(location.y - within, location.y + within);

        return near;
    }
}