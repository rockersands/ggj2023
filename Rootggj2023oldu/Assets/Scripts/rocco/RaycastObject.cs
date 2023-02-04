using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastObject : MonoBehaviour
{

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hitInfo.distance, Color.red);
        Physics.Raycast(transform.position,transform.TransformDirection(Vector3.down),out RaycastHit hitInfo, 20f))
        {
            Debug.Log("hit something");
        }
    }
}
