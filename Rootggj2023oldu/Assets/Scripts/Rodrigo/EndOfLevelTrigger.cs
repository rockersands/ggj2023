using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevelTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by " + other.gameObject.tag);
        if(other.gameObject.tag == "Player")
        {
            levelManager.instance.LevelUp();
        }
    }
}
