using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : RaycastObject
{
    public static int movesCounter;
    private List<GameObject> tailParts = new List<GameObject>();
    private List<RaycastHitWithDirection> cantMoveToTheseDirections = new List<RaycastHitWithDirection>();
    private PlayerMovement playerMovement;
    private bool finishedMove = true;
    #region Awake
    private void Awake()
    {
        playerMovement = new PlayerMovement();
    }
    #endregion
    #region on enable
    private void OnEnable()
    {
        playerMovement.Enable();
    }
    #endregion
    #region ondisable
    private void OnDisable()
    {
        playerMovement.Disable();
    }
    #endregion
    #region update
    private void Update()
    {
        Movement();
    }
    #endregion
    #region Movement
    private void Movement()
    {
        Vector2 move = playerMovement.Player.LeftStick.ReadValue<Vector2>();
        if (move == Vector2.zero) { finishedMove = true; }
        if (!finishedMove) { return; }
        TriggerRaycasts();
        #region directions
        if (move.x < 0)
        {
            Moving(Enumerables.directions.left);
        }
        else if (move.x > 0)
        {
            Moving(Enumerables.directions.right);
        }
        else if (move.y < 0)
        {
            Moving(Enumerables.directions.down);
        }
        else if (move.y > 0)
        {
            Moving(Enumerables.directions.up);
        }
        #endregion
    }
    #region Moving
    private void Moving(Enumerables.directions direction)
    {
        if (movesCounter == 0)
            return;
        GameEvents.instance.PlayerTryingToMove();
        if (!CanMoveToThisDirection(direction)) { return; }
        if (ImmobableBoxInDirection(direction)) { return; }
        tailParts.Add(Instantiate(Resources.Load<GameObject>("Prefabs/Root"), transform.position, Quaternion.identity, null));
        GameEvents.instance.PlayerMoved(direction);
        #region switch
        switch (direction)
        {
            case Enumerables.directions.right:
                transform.position += Vector3.right;
                break;
            case Enumerables.directions.left:
                transform.position += Vector3.left;
                break;
            case Enumerables.directions.up:
                transform.position += Vector3.up;
                break;
            case Enumerables.directions.down:
                transform.position += Vector3.down;
                break;
            case Enumerables.directions.noDir:
                break;
            default:
                break;
        }
        #endregion
        finishedMove = false;
        movesCounter -= 1;
    }
    #endregion
    #endregion
    [ContextMenu("ResetTail")]
    private void ResetTail()
    {
        Debug.Log($"tail parts count  {tailParts.Count}");
        foreach (var item in tailParts)
        {
            Destroy(item);
        }
    }
    #region TriggerRaycasts
    private void TriggerRaycasts()
    {
        DrawRayCastDown();
        DrawRayCastLeft();
        DrawRayCastRight();
        DrawRayCastUp();
    }
    #endregion
    #region ImmobableBoxInDirection
    private bool ImmobableBoxInDirection(Enumerables.directions directionToMoveTo)
    {
        BoxObject tempBox = new BoxObject();
        switch (directionToMoveTo)
        {
            case Enumerables.directions.right:
                if(hitInfoRight.transform == null) { return false; }
                if (hitInfoRight.transform.CompareTag("Box"))
                    tempBox = hitInfoRight.transform.GetComponent<BoxObject>();
                break;
            case Enumerables.directions.left:
                if (hitInfoLeft.transform == null) { return false; }
                if (hitInfoLeft.transform.CompareTag("Box"))
                    tempBox = hitInfoLeft.transform.GetComponent<BoxObject>();
                break;
            case Enumerables.directions.up:
                if (hitInfoUp.transform == null) { return false; }
                if (hitInfoUp.transform.CompareTag("Box"))
                {
                    Debug.Log("potato2");
                    tempBox = hitInfoUp.transform.GetComponent<BoxObject>();
                }
                break;
            case Enumerables.directions.down:
                if (hitInfoDown.transform == null) { return false; }
                if (hitInfoDown.transform.CompareTag("Box"))
                    tempBox = hitInfoDown.transform.GetComponent<BoxObject>();
                break;
            case Enumerables.directions.noDir:
                return false;
            default:
                break;
        }
        if (tempBox == null)
            return false;
        if (tempBox != null)
        {
            if (!tempBox.movableBox)
                return true;
            else return false;
        }
        return false;
    }
    #endregion
    #region CanMoveToThisDirection
    private bool CanMoveToThisDirection(Enumerables.directions directionToMoveTo)
    {
        #region switch
        switch (directionToMoveTo)
        {
            case Enumerables.directions.right:
                #region right
                if (hitInfoRight.transform == null) { return true;}
                if(hitInfoRight.transform.CompareTag("Obstacle") || hitInfoRight.transform.CompareTag("Border")
                   || hitInfoRight.transform.CompareTag("Root"))
                    return false;
                else return true;
            #endregion
            case Enumerables.directions.left:
                #region left
                if (hitInfoLeft.transform == null) {  return true; }
                if (hitInfoLeft.transform.CompareTag("Obstacle") || hitInfoLeft.transform.CompareTag("Border")
                   || hitInfoLeft.transform.CompareTag("Root"))
                    return false;
                else return true;
            #endregion
            case Enumerables.directions.up:
                #region up
                if (hitInfoUp.transform == null) { return true; }
                if (hitInfoUp.transform.CompareTag("Obstacle") || hitInfoUp.transform.CompareTag("Border")
                   || hitInfoUp.transform.CompareTag("Root"))
                    return false;
                else return true;
            #endregion
            case Enumerables.directions.down:
                #region down
                if (hitInfoDown.transform == null) { return true; }
                if (hitInfoDown.transform.CompareTag("Obstacle") || hitInfoDown.transform.CompareTag("Border")
                   || hitInfoDown.transform.CompareTag("Root"))
                    return false;
                else return true;
            #endregion
            case Enumerables.directions.noDir:
            default:
                return false;
        }
        #endregion
    }
    #endregion
}
