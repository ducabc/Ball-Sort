using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int level;
    public int coin;
    public List<int> idBallObj;
    public GameData()
    {
        this.level = 1;
        this.coin = 0;
        this.idBallObj = new List<int>();
    }
}
