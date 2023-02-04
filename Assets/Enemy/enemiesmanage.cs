using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesmanage : MonoBehaviour
{
    public GameObject[] enemies;
    void Start()
    {
        enemies = Resources.LoadAll<GameObject>("enemyprefab");
        InvokeRepeating("CreatEnemies", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreatEnemies(){
        int num = Random.Range(0, enemies.Length);
        Vector3 spawnpoint = new Vector3(Random.Range(-20f, 20f), 20f, 1f);
        GameObject tempenemy = Instantiate(enemies[num], spawnpoint, Quaternion.identity);
        tempenemy.AddComponent<Enemyai>();
        tempenemy.AddComponent<enemyfire>();
        tempenemy.AddComponent<EnemyHp>();
    }
}
