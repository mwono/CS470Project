using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public delegate void GameEvent();

    public static event GameEvent Event_PlayerDie;

    public static void TriggerPlayerDie()
    {
        if (Event_PlayerDie != null)
        {
            Event_PlayerDie();
        }
    }
}
