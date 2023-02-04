using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : RaycastObject
{
    private List<RaycastHitWithDirection> cantMoveToTheseDirections = new List<RaycastHitWithDirection>();
    private PlayerMovement playerMovement;
    private bool finishedMove = true;
    private void Awake()
    {
        playerMovement = new PlayerMovement();
    }
    private void OnEnable()
    {
        playerMovement.Enable();
    }
    private void OnDisable()
    {
        playerMovement.Disable();
    }
    private void Update()
    {
        Movement();
    }
    #region Movement
    private void Movement()
    {
        Vector2 move = playerMovement.Player.LeftStick.ReadValue<Vector2>();
        if (move == Vector2.zero) { finishedMove = true; }
        if (!finishedMove) { return; }
        TriggerRaycasts();
        #region left
        if (move.x < 0)
        {
            Debug.Log("1");
            GameEvents.instance.PlayerTryingToMove();
            Debug.Log("2");
            if (!CanMoveToThisDirection(RaycastHitWithDirection.directions.left)) { return; }
            Debug.Log("3");
            if (ImmobableBoxInDirection(RaycastHitWithDirection.directions.left)) { return; }
            Debug.Log("4");
            GameEvents.instance.PlayerMoved(RaycastHitWithDirection.directions.left);
            Debug.Log("5");
            transform.position += Vector3.left;
            Debug.Log("6");
            finishedMove = false;
        }
        #endregion
        #region right
        else if (move.x > 0)
        {
            GameEvents.instance.PlayerTryingToMove();
            if (!CanMoveToThisDirection(RaycastHitWithDirection.directions.right)) { Debug.Log("cantMove right"); return; }
            if (ImmobableBoxInDirection(RaycastHitWithDirection.directions.right)) { Debug.Log("immovable right"); return; }
            GameEvents.instance.PlayerMoved(RaycastHitWithDirection.directions.right);
            transform.position += Vector3.right;
            finishedMove = false;
        }
        #endregion
        #region down
        else if (move.y < 0)
        {
            GameEvents.instance.PlayerTryingToMove();
            if (!CanMoveToThisDirection(RaycastHitWithDirection.directions.down)) { Debug.Log("cantMove down"); return; }
            if (ImmobableBoxInDirection(RaycastHitWithDirection.directions.down)) { Debug.Log("immovable down"); return; }
            GameEvents.instance.PlayerMoved(RaycastHitWithDirection.directions.down);
            transform.position += Vector3.down;
            finishedMove = false;
        }
        #endregion
        #region up
        else if (move.y > 0)
        {
            GameEvents.instance.PlayerTryingToMove();
            if (!CanMoveToThisDirection(RaycastHitWithDirection.directions.up)) { return; }
            if (ImmobableBoxInDirection(RaycastHitWithDirection.directions.up)) { return; }
            GameEvents.instance.PlayerMoved(RaycastHitWithDirection.directions.up);
            transform.position += Vector3.up;
            finishedMove = false;
        }
        #endregion
    }
    #endregion
    private void TriggerRaycasts()
    {
        DrawRayCastDown();
        DrawRayCastLeft();
        DrawRayCastRight();
        DrawRayCastUp();
    }
    private bool ImmobableBoxInDirection(RaycastHitWithDirection.directions directionToMoveTo)
    {
        BoxObject tempBox = new BoxObject();
        switch (directionToMoveTo)
        {
            case RaycastHitWithDirection.directions.right:
                if(hitInfoRight.transform == null) { return false; }
                if (hitInfoRight.transform.CompareTag("Box"))
                    tempBox = hitInfoRight.transform.GetComponent<BoxObject>();
                break;
            case RaycastHitWithDirection.directions.left:
                if (hitInfoLeft.transform == null) { return false; }
                if (hitInfoLeft.transform.CompareTag("Box"))
                    tempBox = hitInfoLeft.transform.GetComponent<BoxObject>();
                break;
            case RaycastHitWithDirection.directions.up:
                if (hitInfoUp.transform == null) { Debug.Log("potato"); return false; }
                if (hitInfoUp.transform.CompareTag("Box"))
                {
                    Debug.Log("potato2");
                    tempBox = hitInfoUp.transform.GetComponent<BoxObject>();
                }
                break;
            case RaycastHitWithDirection.directions.down:
                if (hitInfoDown.transform == null) { return false; }
                if (hitInfoDown.transform.CompareTag("Box"))
                    tempBox = hitInfoDown.transform.GetComponent<BoxObject>();
                break;
            case RaycastHitWithDirection.directions.noDir:
                return false;
            default:
                break;
        }
        Debug.Log("hi");
        if (tempBox == null)
            return false;
        if (tempBox != null)
        {
            Debug.Log(tempBox.movableBox);
            if (!tempBox.movableBox)
                return true;
            else return false;
        }
        return false;
    }
    private bool CanMoveToThisDirection(RaycastHitWithDirection.directions directionToMoveTo)
    {
        TriggerRaycasts();
        Debug.Log($"im going to move to {directionToMoveTo}");
        switch (directionToMoveTo)
        {
            case RaycastHitWithDirection.directions.right:
                if(hitInfoRight.transform == null) { return true;}
                if(hitInfoRight.transform.CompareTag("Obstacle") || hitInfoRight.transform.CompareTag("Border")
                   || hitInfoRight.transform.CompareTag("Root"))
                    return false;
                else return true;
            case RaycastHitWithDirection.directions.left:
                Debug.Log("hola");
                if (hitInfoLeft.transform == null) { Debug.Log("nothingLeft"); return true; }
                Debug.Log("hola2");
                if (hitInfoLeft.transform.CompareTag("Obstacle") || hitInfoLeft.transform.CompareTag("Border")
                   || hitInfoLeft.transform.CompareTag("Root"))
                {
                    Debug.Log("somethingleftCantPass");
                    return false;
                }
                else return true;
            case RaycastHitWithDirection.directions.up:
                if (hitInfoUp.transform == null) { return true; }
                if (hitInfoUp.transform.CompareTag("Obstacle") || hitInfoUp.transform.CompareTag("Border")
                   || hitInfoUp.transform.CompareTag("Root"))
                    return false;
                else return true;
            case RaycastHitWithDirection.directions.down:
                if (hitInfoDown.transform == null) { return true; }
                if (hitInfoDown.transform.CompareTag("Obstacle") || hitInfoDown.transform.CompareTag("Border")
                   || hitInfoDown.transform.CompareTag("Root"))
                    return false;
                else return true;
            case RaycastHitWithDirection.directions.noDir:
            default:
                return false;
        }
        return false;
    }
}
