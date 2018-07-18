using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public static int enemyCount = 0;
    public static List<Enemy> enemyMasterList = new List<Enemy>();

    public Enemy()
    {
        Debug.Log("Made");
        ++enemyCount;
        enemyMasterList.Add(this);
    }

    ~Enemy()
    {
        --enemyCount;
        enemyMasterList.Remove(this);
    }

    public GameObject findPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }

}
