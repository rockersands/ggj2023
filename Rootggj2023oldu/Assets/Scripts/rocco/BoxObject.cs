using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxObject : RaycastObject
{
    public bool movableBox;
    private RaycastHitWithDirection.directions directionToBeMovedTo = RaycastHitWithDirection.directions.noDir;
    public override void Start()
    {
        base.Start();
        movableBox = true;
        GameEvents.instance.playerTryingToMove_Event += TriggerRaycasts;
        GameEvents.instance.playerMoved_Event += CheckIfPlayerIsMovingMe;
    }
   
    private void CheckIfPlayerIsMovingMe(RaycastHitWithDirection.directions PlayerMovingDirection)
    {
        TriggerRaycasts();
        if (PlayerMovingDirection == directionToBeMovedTo )
        {
            Debug.Log("player moving me");
           
            MoveToDirection();
        }
    }
    
    #region moveToDirection

    [ContextMenu("MoveToDirection")]
    private void MoveToDirection()
    {
        switch (directionToBeMovedTo)
        {
            case RaycastHitWithDirection.directions.right:
                transform.position = transform.position + Vector3.right;
                break;
            case RaycastHitWithDirection.directions.left:
                transform.position = transform.position + Vector3.left;
                break;
            case RaycastHitWithDirection.directions.up:
                transform.position = transform.position + Vector3.up;
                break;
            case RaycastHitWithDirection.directions.down:
                transform.position = transform.position + Vector3.down;
                break;
            case RaycastHitWithDirection.directions.noDir:
                break;
            default:
                break;
        }
    }
    #endregion
    #region TriggerRaycasts
    private void TriggerRaycasts()
    {
        directionToBeMovedTo = RaycastHitWithDirection.directions.noDir;
        DrawRayCastDown();
        DrawRayCastLeft();
        DrawRayCastRight();
        DrawRayCastUp();
        VerifyHitInfo();
    }
    #endregion
    #region VerifyHitInfo
    private void VerifyHitInfo()
    {
        foreach (RaycastHitWithDirection raycastWDirection in myRayCastHits)
        {
            if (raycastWDirection.transformHitted == null) { continue; }

            if(raycastWDirection.transformHitted.name == "Player")
            {
                VerifyOposingDirection(raycastWDirection.myDirection);
                return;
            }
        }
        movableBox = true;
    }
    #endregion
    #region VerifyOposingDirection
    private void VerifyOposingDirection(RaycastHitWithDirection.directions hittingPlayerDirection)
    {
        Debug.Log("VerifyOposingDirection");
        bool playerCanMoveMe = true;
        #region switch hittingPlayerDirection
        switch (hittingPlayerDirection)
        {
            case RaycastHitWithDirection.directions.right:
                #region right
                Debug.Log("touched the player on my right");
                directionToBeMovedTo = RaycastHitWithDirection.directions.left;
                if (hitInfoLeft.transform == null) { movableBox = true; break; }
                if (hitInfoLeft.collider.tag == "Obstacle" || hitInfoLeft.collider.tag == "Box"
                     || hitInfoLeft.transform.CompareTag("Border"))
                    playerCanMoveMe = false;
                #endregion
                break;
            case RaycastHitWithDirection.directions.left:
                #region left
                Debug.Log("touched the player on my left");
                directionToBeMovedTo = RaycastHitWithDirection.directions.right;
                if (hitInfoRight.transform == null) { movableBox = true; break; }
                if (hitInfoRight.collider.tag == "Obstacle" || hitInfoRight.collider.tag == "Box" 
                    || hitInfoRight.transform.CompareTag("Border"))
                    playerCanMoveMe = false;
                #endregion
                break;
            case RaycastHitWithDirection.directions.up:
                #region up
                Debug.Log("touched the player on my up");
                directionToBeMovedTo = RaycastHitWithDirection.directions.down;
                if (hitInfoDown.transform == null) { movableBox = true; break; }
                if (hitInfoDown.collider.tag == "Obstacle" || hitInfoDown.collider.tag == "Box"
                    || hitInfoDown.transform.CompareTag("Border"))
                    playerCanMoveMe = false;
                #endregion
                break;
            case RaycastHitWithDirection.directions.down:
                #region down
                Debug.Log("touched the player on my down");
                directionToBeMovedTo = RaycastHitWithDirection.directions.up;
                if (hitInfoUp.transform == null) { movableBox = true; break; }
                if (hitInfoUp.collider.tag == "Obstacle" || hitInfoUp.collider.tag == "Box"
                     || hitInfoUp.transform.CompareTag("Border"))
                    playerCanMoveMe = false;
                #endregion
                break;
            default:
                break;
        }
        #endregion
        if (!playerCanMoveMe)
        {
            Debug.Log($"{name} cant move");
            movableBox = false;
        }
        else
        {
            Debug.Log($"{name} can move");
            movableBox = true;
        }

    }
    #endregion
}
