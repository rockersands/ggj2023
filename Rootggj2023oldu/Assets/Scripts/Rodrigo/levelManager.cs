using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class levelManager : MonoBehaviour
{
    //Manejador de niveles.
    //Este código simplemente va a cargar el nivel apropiado y con otra función va a cargar el siguiente nivel.
    public static levelManager instance = null;
    public float transitionWaitTime;
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
    }

    public void LoadLevel()
    {
        VisualAndSoundEventsHangler.instance.ScreenTransition();
        StartCoroutine(ActionsAfterSeconds(() =>
        {
            GetComponent<ForegroundTileMapPopulator>().Populate(levelCount);
        },
        transitionWaitTime));
        
    }
    private IEnumerator ActionsAfterSeconds(System.Action FunctionAfterSeconds,float secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);
        FunctionAfterSeconds?.Invoke();
    }
    // Aquí vamos a llamar al siguiente nivel.
    public void LevelUp()
    {
        Debug.Log("levelup");
        StartCoroutine(ActionsAfterSeconds(() =>
        {
            //Aquí va a ir la lógica de recargar el nivel.
            levelCount += 1;
            CleanMap();
            StartCoroutine(WaitOneSecond());
            if (levelCount <= 9)
            {
                LoadLevel();
            }
        },
           transitionWaitTime));
    }

    public void ResetLevel()
    {
        CleanMap();
        StartCoroutine(WaitOneSecond());
        if (levelCount <= 9)
        {
            LoadLevel();
        }
    }

    void CleanMap()
    {
        Player.ResetTail();
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
