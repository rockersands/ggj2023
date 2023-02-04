using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class levelManager : MonoBehaviour
{
    //Manejador de niveles.
    //Este código simplemente va a cargar el nivel apropiado y con otra función va a cargar el siguiente nivel.
    public static levelManager instance = null;

    [SerializeField]
    private ForegroundTileMapPopulator populator;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);
    }
    int levelCount = new int();
    public Tilemap tilemap;

    void Start()
    {
        levelCount = 0;
        LoadLevel();
    }

    void LoadLevel()
    {
        GetComponent<ForegroundTileMapPopulator>().Populate(levelCount);
    }

    // Aquí vamos a llamar al siguiente nivel.
    public void LevelUp()
    {

        //Aquí va a ir la lógica de recargar el nivel.
        levelCount += 1;
        CleanMap();
        StartCoroutine(WaitOneSecond());
        if(levelCount<=9)
        {
            LoadLevel();
        }
    }

    void CleanMap()
    {
        foreach (var item in populator.currentLevel)
        {
            Destroy(item);
        }
        tilemap.ClearAllTiles();
    }

    IEnumerator WaitOneSecond()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("One second has passed");
    }
}
