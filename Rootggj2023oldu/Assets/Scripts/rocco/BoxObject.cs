using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxObject : RaycastObject
{
    // [HideInInspector]
    private bool assignedThisFrame;
    public bool movableBox;
    [SerializeField]
    private Enumerables.directions directionToBeMovedTo;
    public override void Start()
    {
        base.Start();
        movableBox = true;
        GameEvents.instance.playerTryingToMove_Event += TriggerRaycasts;
        GameEvents.instance.playerMoved_Event += CheckIfPlayerIsMovingMe;
    }
    private void OnDestroy()
    {
        GameEvents.instance.playerTryingToMove_Event -= TriggerRaycasts;
        GameEvents.instance.playerMoved_Event -= CheckIfPlayerIsMovingMe;
    }
    #region CheckIfPlayerIsMovingMe
    private void CheckIfPlayerIsMovingMe(Enumerables.directions PlayerMovingDirection)
    {
        VerifyHitInfo();
        Debug.Log($"moved to {directionToBeMovedTo} playermovingto {PlayerMovingDirection} ");
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
        Debug.Log("hi1");
        directionToBeMovedTo = Enumerables.directions.noDir;
        //if (!assignedThisFrame)
        //{
        //    directionToBeMovedTo = Enumerables.directions.noDir;
        //    assignedThisFrame = true;
        //    StartCoroutine(LateFrame());
        //}
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
            Debug.Log($"at pos {transform.position}i hitted {raycastWDirection.transformHitted}");
            if (raycastWDirection.transformHitted.CompareTag("Player"))
            {
                Debug.Log("player");
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
        Debug.Log($"VerifyOposingDirection {hittingPlayerDirection}");
        bool playerCanMoveMe = true;
        #region switch hittingPlayerDirection
        switch (hittingPlayerDirection)
        {
            case Enumerables.directions.right:
                #region right
                Debug.Log("1r");
                directionToBeMovedTo = Enumerables.directions.left;
                Debug.Log(directionToBeMovedTo);
                if (hitInfoLeft.transform == null) { Debug.Log("2r"); playerCanMoveMe = true; break; }
                if (hitInfoLeft.collider.tag == "Obstacle" || hitInfoLeft.collider.tag == "Box"
                     || hitInfoLeft.transform.CompareTag("Border") || hitInfoLeft.transform.CompareTag("Root")
                    || hitInfoLeft.transform.CompareTag("LevelEnd"))
                    playerCanMoveMe = false;
                #endregion
                break;
            case Enumerables.directions.left:
                #region left
                Debug.Log("1l");
                directionToBeMovedTo = Enumerables.directions.right;
                if (hitInfoRight.transform == null) { playerCanMoveMe = true; break; }
                if (hitInfoRight.collider.tag == "Obstacle" || hitInfoRight.collider.tag == "Box" 
                    || hitInfoRight.transform.CompareTag("Border") || hitInfoRight.transform.CompareTag("Root")
                    || hitInfoLeft.transform.CompareTag("LevelEnd"))
                    playerCanMoveMe = false;
                #endregion
                break;
            case Enumerables.directions.up:
                #region up
                Debug.Log("1u");
                directionToBeMovedTo = Enumerables.directions.down;
                if (hitInfoDown.transform == null) { playerCanMoveMe = true; break; }
                if (hitInfoDown.collider.tag == "Obstacle" || hitInfoDown.collider.tag == "Box"
                    || hitInfoDown.transform.CompareTag("Border") || hitInfoDown.transform.CompareTag("Root")
                    || hitInfoLeft.transform.CompareTag("LevelEnd"))
                    playerCanMoveMe = false;
                #endregion
                break;
            case Enumerables.directions.down:
                #region down
                Debug.Log("1d");
                directionToBeMovedTo = Enumerables.directions.up;
                if (hitInfoUp.transform == null) { Debug.Log($"player down im up"); playerCanMoveMe = true; break; }
                if (hitInfoUp.transform.CompareTag("Obstacle") || hitInfoUp.transform.CompareTag("Box")
                     || hitInfoUp.transform.CompareTag("Border")|| hitInfoUp.transform.CompareTag("Root")
                     || hitInfoLeft.transform.CompareTag("LevelEnd"))
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
