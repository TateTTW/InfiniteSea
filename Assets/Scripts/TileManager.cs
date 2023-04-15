using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tilePrefabs;

    public int size;
    private Vector2 tileSize = new Vector2(400, 400);
    private Vector3 oldTilePos = new Vector3(Mathf.Infinity, 0, Mathf.Infinity);
    private Dictionary<Vector2, GameObject> spawnedTiles = new Dictionary<Vector2, GameObject>();

    void Awake()
    {

/*        SpawnTile(tr);
        Vector3.

        for(int i = 0; i < tileLength; i++)
        {

        }*/
    }

    // Update is called once per frame
    private void Update()
    {
        CalculateTiles();
    }
    private void CalculateTiles()
    {
        Vector3 tilePos = PlayerToTilePosition();
        int xPos = (int)(tilePos.x);
        int zPos = (int)(tilePos.z);
        if (new Vector3(xPos, 0, zPos) != oldTilePos)
        {
            oldTilePos = new Vector3(xPos, 0, zPos);
            CreateGrid(xPos, zPos);
        }
    }

    private Vector3 PlayerToTilePosition()
    {
        return new Vector3(Round(CurrentPlayer.instance.player.transform.position.x, tileSize.x), 0, Round(CurrentPlayer.instance.player.transform.position.z, tileSize.y));
    }
    private int Round(float value, float factor)
    {
        return (int)Mathf.Round((value / factor));
    }
    private void CreateGrid(int xPos, int zPos)
    {
        List<Vector2> newCoords = new List<Vector2>();
        for (int x = -size; x <= size; x++)
        {
            for (int z = -size; z <= size; z++)
            {
                /*newCoords.Add(new Vector2(xPos + x, zPos + z));*/
                if (!spawnedTiles.ContainsKey(new Vector2(xPos + x, zPos + z)))
                {
                    CreateTile(xPos + x, zPos + z);
                }
            }
        }
        /*RemoveTiles(newCoords);*/
    }

    private void RemoveTiles(List<Vector2> coords)
    {
        List<Vector2> toRemove = new List<Vector2>();
        foreach (var t in spawnedTiles.Keys)
        {
            if (!coords.Contains(t))
            {
                GameObject tile = spawnedTiles[t];
                Destroy(tile);
                toRemove.Add(t);
            }
        }
        foreach (var tP in toRemove)
        {
            spawnedTiles.Remove(tP);
        }
    }

    private void CreateTile(int xPos, int zPos)
    {
        GameObject newTile = Instantiate(tilePrefabs[Random.Range(0, tilePrefabs.Length - 1)], new Vector3((int)tileSize.x * xPos, 0, (int)tileSize.y * zPos), Quaternion.identity);
        /*newTile.Initalize(string.Format("{0},{1}", new object[] { xPos, zPos }));*/
        spawnedTiles.Add(new Vector2(xPos, zPos), newTile);
    }
}

/*private void SpawnTile(Vector3 position)
    {
        int index = Random.Range(0, tilePrefabs.Length - 1);
        Instantiate(tilePrefabs[index], position, transform.rotation);
    }
}*/
