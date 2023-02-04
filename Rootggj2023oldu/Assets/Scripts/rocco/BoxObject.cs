using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxObject : RaycastObject
{
    private bool movableBox;
    private RaycastHitWithDirection.directions directionToBeMovedTo = RaycastHitWithDirection.directions.noDir;
    public override void Start()
    {
        base.Start();
        GameEvents.instance.playerMoved_Event += CheckIfPlayerIsMovingMe;
    }
    private void CheckIfPlayerIsMovingMe(RaycastHitWithDirection.directions PlayerMovingDirection)
    {
        if(PlayerMovingDirection == directionToBeMovedTo)
        {
            MoveToDirection();
        }
        TriggerRaycasts();
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
        bool hittingPlayer = false;
        foreach (RaycastHitWithDirection raycastWDirection in myRayCastHits)
        {
            movableBox = false;
            if (raycastWDirection.transformHitted == null) { continue; }

            if(raycastWDirection.transformHitted.name == "Player")
            {
                VerifyOposingDirection(raycastWDirection.myDirection);
            }
        }
    }
    #endregion
    #region VerifyOposingDirection
    private void VerifyOposingDirection(RaycastHitWithDirection.directions hittingPlayerDirection)
    {
        bool playerCanMoveMe = true;
        #region switch hittingPlayerDirection
        switch (hittingPlayerDirection)
        {
            case RaycastHitWithDirection.directions.right:
                #region right
                Debug.Log("touched the player on my right");
                directionToBeMovedTo = RaycastHitWithDirection.directions.left;
                if (hitInfoLeft.transform == null) { break; }
                if (hitInfoLeft.collider.tag == "Obstacle" || hitInfoUp.collider.tag == "Box")
                    playerCanMoveMe = false;
                #endregion
                break;
            case RaycastHitWithDirection.directions.left:
                #region left
                Debug.Log("touched the player on my left");
                directionToBeMovedTo = RaycastHitWithDirection.directions.right;
                if (hitInfoRight.transform == null) { break; }
                if (hitInfoRight.collider.tag == "Obstacle" || hitInfoUp.collider.tag == "Box")
                    playerCanMoveMe = false;
                #endregion
                break;
            case RaycastHitWithDirection.directions.up:
                #region up
                Debug.Log("touched the player on my up");
                directionToBeMovedTo = RaycastHitWithDirection.directions.down;
                if (hitInfoDown.transform == null) { break; }
                if (hitInfoDown.collider.tag == "Obstacle" || hitInfoUp.collider.tag == "Box")
                    playerCanMoveMe = false;
                #endregion
                break;
            case RaycastHitWithDirection.directions.down:
                #region down
                Debug.Log("touched the player on my down");
                directionToBeMovedTo = RaycastHitWithDirection.directions.up;
                if (hitInfoUp.transform == null) { break; }
                if (hitInfoUp.collider.tag == "Obstacle" || hitInfoUp.collider.tag == "Box")
                    playerCanMoveMe = false;
                #endregion
                break;
            default:
                break;
        }
        #endregion
        if (!playerCanMoveMe)
            movableBox = false;
        else movableBox = true;

    }
    #endregion
}
