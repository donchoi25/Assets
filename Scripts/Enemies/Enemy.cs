using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: IKillable
{
    public static int enemyCount = 0;
    public static List<Enemy> enemyMasterList = new List<Enemy>();

    public Enemy()
    {
        ++enemyCount;
        enemyMasterList.Add(this);
    }

    ~Enemy()
    {
        --enemyCount;
        enemyMasterList.Remove(this);
    }

   public void Kill(float velocity)
    {

    }

    public GameObject findPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }

}
