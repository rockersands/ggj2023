using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeMySprite : MonoBehaviour
{
    [SerializeField]
    List<Sprite> possibleSprites;
    [SerializeField]
    private SpriteRenderer mySpriteRenderer;
    // Start is cal
    // led before the first frame update
    void Start()
    {
        mySpriteRenderer.sprite = possibleSprites[Random.Range(0, possibleSprites.Count)];
    }
}
