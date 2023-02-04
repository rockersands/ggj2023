using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastObject : MonoBehaviour
{

    public float rayCastDistance;
    [HideInInspector]
    public List<RaycastHitWithDirection> myRayCastHits = new List<RaycastHitWithDirection>();
    [HideInInspector]
    public bool collisionedDown, collisionedRight, collisionedLeft, collisionedUp;
    [HideInInspector]
    public RaycastHit hitInfoRight, hitInfoDown, hitInfoLeft, hitInfoUp;
    public virtual void Start()
    {
        #region filling raycasts hit list
        myRayCastHits.Add(new RaycastHitWithDirection(Enumerables.directions.right,hitInfoRight));
        myRayCastHits.Add(new RaycastHitWithDirection(Enumerables.directions.left, hitInfoLeft));
        myRayCastHits.Add(new RaycastHitWithDirection(Enumerables.directions.up, hitInfoUp));
        myRayCastHits.Add(new RaycastHitWithDirection(Enumerables.directions.down, hitInfoDown));
        #endregion
    }
    #region drawRayCasts
    #region DrawRayCastRight
    public virtual void DrawRayCastRight()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hitInfoRight, rayCastDistance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * rayCastDistance, Color.red);
            collisionedRight = true;
            ModifyRaycastWithDir(Enumerables.directions.right, hitInfoRight.transform);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * rayCastDistance, Color.green);
            collisionedRight = false;
            ModifyRaycastWithDir(Enumerables.directions.right, null);
        }
    }
    #endregion
    #region DrawRayCastDown
    public virtual void DrawRayCastDown()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hitInfoDown, rayCastDistance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * rayCastDistance, Color.red);
            collisionedDown = true;
            ModifyRaycastWithDir(Enumerables.directions.down, hitInfoDown.transform);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * rayCastDistance, Color.green);
            collisionedDown = false;
            ModifyRaycastWithDir(Enumerables.directions.down, null);
        }
    }
    #endregion
    #region DrawRayCastLeft
    public virtual void DrawRayCastLeft()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hitInfoLeft, rayCastDistance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * rayCastDistance, Color.red);
            Transform objectHitted = hitInfoLeft.transform;
            collisionedLeft = true;
            ModifyRaycastWithDir(Enumerables.directions.left, objectHitted);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * rayCastDistance, Color.green);
            collisionedLeft = false;
            ModifyRaycastWithDir(Enumerables.directions.left, null);
        }
    }
    #endregion
    #region DrawRayCastUp
    public virtual void DrawRayCastUp()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hitInfoUp, rayCastDistance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * rayCastDistance, Color.red);
            collisionedUp = true;
            ModifyRaycastWithDir(Enumerables.directions.up, hitInfoUp.transform);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * rayCastDistance, Color.green);
            collisionedUp = false;
            ModifyRaycastWithDir(Enumerables.directions.up, null);
        }
    }
    #endregion
    #endregion
    #region ModifyRaycastWithDir
    public void ModifyRaycastWithDir(Enumerables.directions direction,Transform transformHit)
    {
        foreach (RaycastHitWithDirection item in myRayCastHits)
        {
            if(item.myDirection == direction)
            {
                //Debug.Log($"{transformHit.name}");
                item.transformHitted = transformHit;
            }
        }
    }
    #endregion
}
public class RaycastHitWithDirection
{
    public RaycastHitWithDirection(Enumerables.directions direction, RaycastHit raycastHit)
    {
        myDirection = direction;
        myRayCastHit = raycastHit;
    }
    public Enumerables.directions myDirection;
    public RaycastHit myRayCastHit;
    public Transform transformHitted;
}
