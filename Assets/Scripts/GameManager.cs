using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject tiles, friendlySnowmen, enemySnowmen, friendlyStorage, enemyStorage;
    public GameObject[] gameOverToggle;
    public int snowballs = 50;
    public bool gameOver = false;

    private bool toggled = false;

    public static int friendlyIncome = 0, enemyIncome = 0;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) ChangeScene(0);
        if (friendlySnowmen == null && enemySnowmen == null) return;
        if ((friendlySnowmen.transform.childCount == 0 && friendlyStorage == null) ||
            (enemySnowmen.transform.childCount == 0 && enemyStorage == null)) gameOver = true;
        if (gameOver && !toggled) {
            foreach(GameObject go in gameOverToggle) {
                go.SetActive(!go.activeSelf);
            }
            toggled = true;
        }
    }

    public string GetWinner() {
        if (gameOver) {
            if (friendlySnowmen.transform.childCount == 0 && friendlyStorage == null) {
                return "Enemy";
            } else if (enemySnowmen.transform.childCount == 0 && enemyStorage == null) {
                return "Friendly";
            } else return "None";
        }

        return null;
    }

    public void AttemptToBuildExtractor(Vector2 position, bool friendly = true) {
        float closestDistance = Vector2.Distance(position, tiles.transform.GetChild(0).position);
        Tile closestTile = tiles.transform.GetChild(0).GetComponent<Tile>();
        if (closestTile == null) Debug.LogError("Tile list error while attempting to build extractor.");

        foreach(Transform tile in tiles.transform) {
            Tile t = tile.GetComponent<Tile>();
            float distance = Vector2.Distance(position, tile.position);
            if (t != null && distance < closestDistance) {
                closestTile = t;
                closestDistance = distance;
            }
        }

        if (closestTile.GetTileType() == 2) {
            GameObject cgo = closestTile.GetClosestObject(friendlySnowmen);
            if(cgo != null) cgo.GetComponent<SnowmanController>().BuildExtractor(closestTile.transform.position);
        }
    }

    public void ChangeScene(int index) {
        SceneManager.LoadSceneAsync(index);
        snowballs = 50;
    }

    public void Quit() {
        Application.Quit();
    }
}
