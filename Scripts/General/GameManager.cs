using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static List<Enemy> enemyMasterList;
    Enemy test;
    Enemy test2;

    void Start()
    {
        test = new Enemy();
        test2 = new Enemy();
        Debug.Log(Enemy.enemyMasterList);
        Debug.Log(Enemy.enemyCount);
    }

    void Update()
    {


    }
}
