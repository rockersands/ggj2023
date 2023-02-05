using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BackgroundTileMapGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase[] tiles;

    Sprite[] objs;

    private int[,] mapData =
    {
        {1,1,1,1,1,1,1,1,1,1},
        {1,0,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,1},
        {1,1,1,1,1,1,1,1,1,1}
    };

    private void Start()
    {
        objs = Resources.LoadAll<Sprite>("Sprites");
        GenerateMap();
    }

    private void GenerateMap()
    {
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                Vector3Int p = new Vector3Int(x, y, 0);
                if (x == 0 || y == 0 || x == 9 || y == 9)
                {
                    tilemap.SetTile(p, tiles[1]);
                }
                else
                {
                    Sprite randomSprite = objs[Random.Range(0, 26)];
                    Tile tempTile = ScriptableObject.CreateInstance<Tile>();
                    tempTile.sprite = randomSprite;
                    tilemap.SetTile(p, tempTile);
                }

            }
        }
    }
}

