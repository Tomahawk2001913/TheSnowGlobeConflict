using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour {
    [System.Serializable]
    public struct TileType {
        public string name;
        public Sprite sprite;
    }

    public TileType[] types;
}
