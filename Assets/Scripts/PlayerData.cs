using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//important pentru lucru cu fisiere
public class PlayerData
{
    public int lose;
    public int win;

    public PlayerData (PauseMenu player)//pause menu asta denumirea la fisierul din care salvez
    {
        win = PauseMenu.winCount;
        lose = PauseMenu.loseCount;
    }
}
