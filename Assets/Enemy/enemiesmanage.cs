using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesmanage : MonoBehaviour
{
    private GameObject[] enemies;
    private Vector3 flyerspawnpoint;
    private Vector3 stationaryfighterspawnpoint;
    void Start()
    {
        enemies = Resources.LoadAll<GameObject>("enemyprefab");


        StartCoroutine(SpawnEnemyModeControl());

    }

    IEnumerator SpawnEnemyModeControl()
    {
        while (1 < 2)
        {
            for (int i = 0; i < 4; i++)
            {
                StartCoroutine(SpawnRandomEnemies());
                yield return new WaitForSeconds(3f);
            }
            StartCoroutine(LotsOfEnemies());
            yield return new WaitForSeconds(15f);
        }

    }

    // Update is called once per frame
    IEnumerator SpawnRandomEnemies()
    {

        if (Random.Range(0f, 1f) > 0.5)
        {
            StartCoroutine(CreatEnemiesstationaryfigher());
        }
        else if (Random.Range(0f, 1f) > 0.5)
        {
            StartCoroutine(CreatEnemiesflyer(20));
        }
        else
        {
            StartCoroutine(CreatEnemiesflyer(-20));
        }
        yield return null;

    }
    IEnumerator LotsOfEnemies()
    {
        StartCoroutine(CreatEnemiesflyer(-20f));
        yield return new WaitForSeconds(2.2f);
        StartCoroutine(CreatEnemiesflyer(-20f));
        for (int i = 7 - 1; i >= 0; i--)
        {
            StartCoroutine(CreatEnemiesstationaryfigher());
        }
        yield return new WaitForSeconds(2.2f);
        StartCoroutine(CreatEnemiesflyer(20f));
        yield return new WaitForSeconds(2.2f);
        StartCoroutine(CreatEnemiesflyer(20f));
    }

    IEnumerator CreatEnemiesflyer(float WhichSide)
    {
        flyerspawnpoint = new Vector3(WhichSide, Random.Range(10f, 20f), 1f);
        for (int i = 0; i < 4; i++)
        {
            GameObject tempenemy = Instantiate(enemies[0], flyerspawnpoint, Quaternion.identity);
            tempenemy.AddComponent<FlyerAi>();
            tempenemy.AddComponent<enemyfire>();
            tempenemy.AddComponent<EnemyHp>();
            yield return new WaitForSeconds(0.5f);
        }


    }
    IEnumerator CreatEnemiesstationaryfigher()
    {
        stationaryfighterspawnpoint = new Vector3(Random.Range(-10f, 10f), 15f, 1f);
        GameObject tempenemy = Instantiate(enemies[1], stationaryfighterspawnpoint, Quaternion.identity);
        tempenemy.AddComponent<StationaryfighterAi>();
        tempenemy.AddComponent<enemyfire>();
        tempenemy.AddComponent<EnemyHp>();
        yield return null;
    }
}
