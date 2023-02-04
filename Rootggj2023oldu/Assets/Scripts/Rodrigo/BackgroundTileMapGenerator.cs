﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BackgroundTileMapGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase[] tiles;

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
                    tilemap.SetTile(p, tiles[0]);
                }

            }
        }
    }
}

