using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ForegroundTileMapPopulator : MonoBehaviour
{
    //Este script leera los datos de los csv y colocará los gameobjects relevantes en el nivel.
    public Tilemap tilemap;
    /*Los gameobjects van a ser los siguientes:
     * 
     * 0)Nada
     * 1)Terreno invisible e impasable
     * 2)Posición inicial del jugador, siempre volteando hacia abajo
     * 3)Cajas
     * 4)Rocas que no se mueven y son impasables
     * 5)Fin del nivel
     * 
     * */
    public GameObject[] activeObjects;

    void Start()
    {
        //Primero leemos el csv, tenemos que sacar una lista de csv y elegir el adecuado.
        ReadData reader = GetComponent<ReadData>();
        if(reader == null)
        {
            Debug.Log("Error, reader not found");
            return;
        }
        string[,] csvData = reader.ReadFromCSV(0);

        int rows = csvData.GetLength(0);
        int columns = csvData.GetLength(1);


        for (int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++) 
            {
                int index = new int();
                index = int.Parse(csvData[i, j]);

                if (index == 5)
                    break;
                else
                {
                    Vector3Int cellPosition = new Vector3Int(j, i, 1);
                    Vector3 cellCenter = tilemap.GetCellCenterLocal(cellPosition);

                    GameObject spawnedObject = Instantiate(activeObjects[index], tilemap.transform);
                    spawnedObject.transform.localPosition = cellCenter;
                }
            }
        }
    }

}
