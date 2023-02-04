using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : RaycastObject
{
    public static int movesCounter;
    [SerializeField]
    private Transform headObject;
    [Header("RootSprites")]
    [SerializeField]
    private Sprite straightRoot;
    [SerializeField]
    private Sprite cornerRoot;
    private List<GameObject> tailParts = new List<GameObject>();
    private List<RaycastHitWithDirection> cantMoveToTheseDirections = new List<RaycastHitWithDirection>();
    private PlayerMovement playerMovement;
    private bool finishedMove = true;
    [SerializeField]
    private Enumerables.directions lastDirection = Enumerables.directions.noDir;
    public void AssignFirstDirection(int direction)
    {
        switch (direction)
        {
           case 0:
               headObject.eulerAngles = new Vector3(0, 0, 90);
                lastDirection = Enumerables.directions.right;
               break;
           case 1:
               headObject.eulerAngles = new Vector3(0, 0, 270);
                lastDirection = Enumerables.directions.left;
                break;
           case 2:
               headObject.eulerAngles = new Vector3(0, 0, 180);
                lastDirection = Enumerables.directions.down;
                break;
           case 3:
               headObject.eulerAngles = new Vector3(0, 0, 0);
                lastDirection = Enumerables.directions.up;
                break;
           default:
                break;
        }
    }
    public override void Start()
    {
        base.Start();
        switch (lastDirection)
        {
            case Enumerables.directions.right:
                headObject.eulerAngles = new Vector3(0, 0, 90);
                break;
            case Enumerables.directions.left:
                headObject.eulerAngles = new Vector3(0, 0, 270);
                break;
            case Enumerables.directions.up:
                headObject.eulerAngles = new Vector3(0, 0, 180);
                break;
            case Enumerables.directions.down:
                headObject.eulerAngles = new Vector3(0, 0, 0);
                break;
            default:
                break;
        }
    }
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
        if (!CanMoveToThisDirection(direction)) { AudioController.PlaySfx(AudioController.Sfx.stump); return; }
        if (ImmobableBoxInDirection(direction)) { AudioController.PlaySfx(AudioController.Sfx.stump); return; }

        CreateCorrectTailPart(direction);
        GameEvents.instance.PlayerMoved(direction);
        AudioController.PlaySfx(AudioController.Sfx.move);

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
    private void CreateCorrectTailPart(Enumerables.directions newDirection)
    {
        if (lastDirection == Enumerables.directions.noDir)
        {
            lastDirection = Enumerables.directions.down;
        }
        GameObject tempTailObject = Instantiate(Resources.Load<GameObject>("Prefabs/Root"), transform.position, Quaternion.identity, null);
        SpriteRenderer tempSpriteRend = tempTailObject.GetComponent<SpriteRenderer>();
        tailParts.Add(tempTailObject);
        Debug.Log("statmach");
        switch (lastDirection)
        {
            case Enumerables.directions.right:
                switch (newDirection)
                {
                    case Enumerables.directions.right:
                        tempTailObject.transform.eulerAngles = new Vector3(0, 0, 90);
                        tempSpriteRend.sprite = straightRoot;
                        headObject.transform.eulerAngles = new Vector3(0, 0, 90);
                        lastDirection = Enumerables.directions.right;
                        break;
                    case Enumerables.directions.up:
                        tempTailObject.transform.eulerAngles = new Vector3(0, 0, 180);
                        tempSpriteRend.sprite = cornerRoot;
                        headObject.transform.eulerAngles = new Vector3(0, 0, 180);
                        lastDirection = Enumerables.directions.up;
                        break;
                    case Enumerables.directions.down:
                        Debug.Log("right down");
                        tempTailObject.transform.eulerAngles = new Vector3(0, 0, -90);
                        headObject.transform.eulerAngles = new Vector3(0, 0, 0);
                        tempSpriteRend.sprite = cornerRoot;
                        lastDirection = Enumerables.directions.down;
                        break;
                    case Enumerables.directions.noDir:
                        break;
                    default:
                        break;
                }
                break;
            case Enumerables.directions.left:
                switch (newDirection)
                {
                    case Enumerables.directions.left:
                        tempTailObject.transform.eulerAngles = new Vector3(0, 0, 90);
                        headObject.transform.eulerAngles = new Vector3(0, 0, 270);
                        tempSpriteRend.sprite = straightRoot;
                        lastDirection = Enumerables.directions.left;
                        break;
                    case Enumerables.directions.up:
                        tempTailObject.transform.eulerAngles = new Vector3(0, 0, 90);
                        headObject.transform.eulerAngles = new Vector3(0, 0, 180);
                        tempSpriteRend.sprite = cornerRoot;
                        lastDirection = Enumerables.directions.up;
                        break;
                    case Enumerables.directions.down:
                        tempTailObject.transform.eulerAngles = new Vector3(0, 0, 0);
                        headObject.transform.eulerAngles = new Vector3(0, 0, 0);
                        tempSpriteRend.sprite = cornerRoot;
                        lastDirection = Enumerables.directions.down;
                        break;
                    case Enumerables.directions.noDir:
                        break;
                    default:
                        break;
                }
                break;
            case Enumerables.directions.up:
                switch (newDirection)
                {
                    case Enumerables.directions.right:
                        tempTailObject.transform.eulerAngles = new Vector3(0, 0, 0);
                        headObject.transform.eulerAngles = new Vector3(0, 0, 90);
                        tempSpriteRend.sprite = cornerRoot;
                        lastDirection = Enumerables.directions.right;
                        break;
                    case Enumerables.directions.left:
                        tempTailObject.transform.eulerAngles = new Vector3(0, 0, -90);
                        headObject.transform.eulerAngles = new Vector3(0, 0, 270);
                        tempSpriteRend.sprite = cornerRoot;
                        lastDirection = Enumerables.directions.left;
                        break;
                    case Enumerables.directions.up:
                        tempTailObject.transform.eulerAngles = new Vector3(0, 0, 0);
                        headObject.transform.eulerAngles = new Vector3(0, 0, 180);
                        tempSpriteRend.sprite = straightRoot;
                        lastDirection = Enumerables.directions.up;
                        break;
                    case Enumerables.directions.noDir:
                        break;
                    default:
                        break;
                }
                break;
            case Enumerables.directions.down:
                switch (newDirection)
                {
                    case Enumerables.directions.right:
                        tempTailObject.transform.eulerAngles = new Vector3(0, 0, 90);
                        tempSpriteRend.sprite = cornerRoot;
                        headObject.transform.eulerAngles = new Vector3(0, 0, 90);
                        lastDirection = Enumerables.directions.right;
                        break;
                    case Enumerables.directions.left:
                        tempTailObject.transform.eulerAngles = new Vector3(0, 0, 180);
                        tempSpriteRend.sprite = cornerRoot;
                        headObject.transform.eulerAngles = new Vector3(0, 0, 270);
                        lastDirection = Enumerables.directions.left;
                        break;
                    case Enumerables.directions.down:
                        tempTailObject.transform.eulerAngles = new Vector3(0, 0, 0);
                        tempSpriteRend.sprite = straightRoot;
                        headObject.transform.eulerAngles = new Vector3(0, 0, 0);
                        lastDirection = Enumerables.directions.down;
                        break;
                    case Enumerables.directions.noDir:
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
        tailParts.Add(Instantiate(Resources.Load<GameObject>("Prefabs/Root"), transform.position, Quaternion.identity, null));
    }
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
