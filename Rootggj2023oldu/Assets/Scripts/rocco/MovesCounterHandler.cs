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
    }
    private void UpdateMovesCounterText(Enumerables.directions meh)
    {
        MovesCounterText.text = (moves -= 1).ToString();
    }

}
