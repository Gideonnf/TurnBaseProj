using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [Tooltip("Starting Position of the map")]
    public Transform startingPosition;
    [Tooltip("Tile prefab to instantiate")]
    public GameObject tilePrefab;
    [Header("Settings for the map array")]
    [Tooltip("Width of the map")]
    public int mapWidth;
    [Tooltip("Height of the map")]
    public int mapHeight;
    [Tooltip("Size of the tile")]
    public int tileSize;

    [System.NonSerialized]
    public List<GameObject> ListOfTiles = new List<GameObject>();

    public static TileGenerator instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        InitMap();
    }

    void InitMap()
    {
        // Loop through based on how big the map is set to be
        for (int w = 0; w < mapWidth; ++w)
        {
            for (int h = 0; h < mapHeight; ++h)
            {
                // Instantiate a new map tile
                //TODO: use object pooler for things like this
                GameObject newTile = Instantiate(tilePrefab, this.transform);

                // Set the position as it iterates
                Vector3 newPosition = startingPosition.position;

                newPosition.x += h * tileSize;
                newPosition.z += w * tileSize;

                newTile.transform.position = newPosition;

                // Add it to the list
                ListOfTiles.Add(newTile);
            }
        }
    }
}
