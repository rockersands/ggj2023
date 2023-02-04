using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MovesCounterHandler : MonoBehaviour
{
    public TMP_Text MovesCounterText;
    public int moves;
    void Start()
    {
        Player.movesCounter = moves;
        GameEvents.instance.playerMoved_Event += UpdateMovesCounterText;
    }
    private void UpdateMovesCounterText(Enumerables.directions meh)
    {
        MovesCounterText.text = (moves -= 1).ToString();
    }

}
