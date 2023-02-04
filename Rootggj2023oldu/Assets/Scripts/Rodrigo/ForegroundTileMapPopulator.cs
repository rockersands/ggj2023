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
     * 
     * 0)Terreno invisible e impasable
     * 1)jugador, con su dirección inicial.
     * 2)Cajas
     * 3)Rocas que no se mueven y son impasables
     * 4)Fin del nivel
     * 5)Nada
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
        string[,] csvData = reader.ReadFromCSV(1);

        int rows = csvData.GetLength(0);
        int columns = csvData.GetLength(1);

        int direction = 0;
        int.TryParse(csvData[rows-1, 0], out direction);

        int movesData = 0;
        int.TryParse(csvData[rows - 1, 1], out movesData);

        for (int i = 0; i < rows-1; i++)
        {
            for(int j = 0; j < columns; j++) 
            {
                int index = new int();
                index = int.Parse(csvData[i, j]);
                

                if (index == 5)
                    continue;
                else
                {
                    Vector3Int cellPosition = new Vector3Int(columns - j - 1, rows - i - 2, 1);
                    Vector3 cellCenter = tilemap.GetCellCenterLocal(cellPosition);

                    if(index == 1)
                    {
                        GameObject spawnedObject = Instantiate(activeObjects[index], tilemap.transform);
                        spawnedObject.GetComponent<Player>().AssignFirstDirection(direction);
                        spawnedObject.GetComponent<MovesCounterHandler>().moves = movesData;
                        spawnedObject.transform.localPosition = cellCenter;
                    }
                    else
                    {
                        GameObject spawnedObject = Instantiate(activeObjects[index], tilemap.transform);
                        spawnedObject.transform.localPosition = cellCenter;
                    }                   
                }
            }
        }
    }

}
