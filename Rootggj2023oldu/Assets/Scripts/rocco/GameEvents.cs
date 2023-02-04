using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameEvents : MonoBehaviour
{
    #region singleton
    public static GameEvents instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(this);
    }
    #endregion
    public event Action playerTryingToMove_Event;
    public event Action<Enumerables.directions> playerMoved_Event;
    [ContextMenu("playerMoved")]
    public void PlayerMoved(Enumerables.directions playerMovingDirection)
    {
        playerMoved_Event?.Invoke(playerMovingDirection);
    }
    public void PlayerTryingToMove()
    {
        playerTryingToMove_Event?.Invoke();
    }
}
