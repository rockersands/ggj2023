using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxObject : RaycastObject
{
    [HideInInspector]
    public bool movableBox;
    private Enumerables.directions directionToBeMovedTo = Enumerables.directions.noDir;
    public override void Start()
    {
        base.Start();
        movableBox = true;
        GameEvents.instance.playerTryingToMove_Event += TriggerRaycasts;
        GameEvents.instance.playerMoved_Event += CheckIfPlayerIsMovingMe;
    }
    #region CheckIfPlayerIsMovingMe
    private void CheckIfPlayerIsMovingMe(Enumerables.directions PlayerMovingDirection)
    {
        TriggerRaycasts();
        if (PlayerMovingDirection == directionToBeMovedTo )
        {
            Debug.Log("player moving me");
           
            MoveToDirection();
        }
    }
    #endregion

    #region moveToDirection
    [ContextMenu("MoveToDirection")]
    private void MoveToDirection()
    {
        switch (directionToBeMovedTo)
        {
            case Enumerables.directions.right:
                transform.position = transform.position + Vector3.right;
                break;
            case Enumerables.directions.left:
                transform.position = transform.position + Vector3.left;
                break;
            case Enumerables.directions.up:
                transform.position = transform.position + Vector3.up;
                break;
            case Enumerables.directions.down:
                transform.position = transform.position + Vector3.down;
                break;
            case Enumerables.directions.noDir:
                break;
            default:
                break;
        }
    }
    #endregion
    #region TriggerRaycasts
    private void TriggerRaycasts()
    {
        directionToBeMovedTo = Enumerables.directions.noDir;
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
    private void VerifyOposingDirection(Enumerables.directions hittingPlayerDirection)
    {
        Debug.Log("VerifyOposingDirection");
        bool playerCanMoveMe = true;
        #region switch hittingPlayerDirection
        switch (hittingPlayerDirection)
        {
            case Enumerables.directions.right:
                #region right
                directionToBeMovedTo = Enumerables.directions.left;
                if (hitInfoLeft.transform == null) { movableBox = true; break; }
                if (hitInfoLeft.collider.tag == "Obstacle" || hitInfoLeft.collider.tag == "Box"
                     || hitInfoLeft.transform.CompareTag("Border") || hitInfoLeft.transform.CompareTag("Root"))
                    playerCanMoveMe = false;
                #endregion
                break;
            case Enumerables.directions.left:
                #region left
                directionToBeMovedTo = Enumerables.directions.right;
                if (hitInfoRight.transform == null) { movableBox = true; break; }
                if (hitInfoRight.collider.tag == "Obstacle" || hitInfoRight.collider.tag == "Box" 
                    || hitInfoRight.transform.CompareTag("Border") || hitInfoRight.transform.CompareTag("Root"))
                    playerCanMoveMe = false;
                #endregion
                break;
            case Enumerables.directions.up:
                #region up
                directionToBeMovedTo = Enumerables.directions.down;
                if (hitInfoDown.transform == null) { movableBox = true; break; }
                if (hitInfoDown.collider.tag == "Obstacle" || hitInfoDown.collider.tag == "Box"
                    || hitInfoDown.transform.CompareTag("Border") || hitInfoDown.transform.CompareTag("Root"))
                    playerCanMoveMe = false;
                #endregion
                break;
            case Enumerables.directions.down:
                #region down
                directionToBeMovedTo = Enumerables.directions.up;
                if (hitInfoUp.transform == null) { movableBox = true; break; }
                if (hitInfoUp.transform.CompareTag("Obstacle") || hitInfoUp.transform.CompareTag("Box")
                     || hitInfoUp.transform.CompareTag("Border")|| hitInfoUp.transform.CompareTag("Root"))
                    playerCanMoveMe = false;
                #endregion
                break;
            default:
                break;
        }
        #endregion
        if (!playerCanMoveMe)
            movableBox = false;
        else
            movableBox = true;

    }
    #endregion
}
