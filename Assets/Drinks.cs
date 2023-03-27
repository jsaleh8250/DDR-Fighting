using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drinks : MonoBehaviour
{
   public void HealthDrink()
    {
     GameManager.inHealthMode = true;
     GameManager.inCutscene = false;
     Debug.Log("Healthmode");
    }

    public void StyleDrink()
    {
     GameManager.inBattleMode = true;
     GameManager.inCutscene = false;
     BattleMode.buttons = BattleMode.buttons + 4;
        if (BattleMode.hits >= 2)
        {
            BattleMode.hits--;
        }
        else
        {
            BattleMode.hits = 1;
        }

    }
}
