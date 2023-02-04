using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyfire : MonoBehaviour
{
    public GameObject enemybullet;
    public Transform firePos;
    // Start is called before the first frame update
    void Start()
    {
        firePos = transform.GetChild(0);
        enemybullet = Resources.Load<GameObject>("enemybullets");
        
        StartCoroutine(shoot());
    }

    IEnumerator shoot(){
        for(int i = 0; i < 1; i++){
            Enemyattack();
            yield return new WaitForSeconds(2f);
        }
        yield return null;
    }

    void Update()
    {
        
    }

    void Enemyattack(){
        GameObject tempBullet = Instantiate(enemybullet, firePos.position, firePos.rotation);
        tempBullet.AddComponent<Enemybulletcontrol>();  
    }
}
