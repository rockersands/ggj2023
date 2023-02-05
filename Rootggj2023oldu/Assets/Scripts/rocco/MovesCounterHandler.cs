using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MovesCounterHandler : MonoBehaviour
{
    public TMP_Text MovesCounterText;
    public static int moves;
    void Start()
    {
        GameEvents.instance.playerMoved_Event += UpdateMovesCounterText;
        GameEvents.instance.updateMoves_Event += UpdateMovesCounterTextt;
    }
    private void UpdateMovesCounterText(Enumerables.directions meh)
    {
        MovesCounterText.text = $"Movimientos restantes {moves-=1 }";
    }
    private void UpdateMovesCounterTextt()
    {
        MovesCounterText.text = $"Movimientos restantes {moves -= 1 }";
    }
    private void OnDisable()
    {
        GameEvents.instance.playerMoved_Event -= UpdateMovesCounterText;
    }

}
