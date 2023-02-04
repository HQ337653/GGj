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
       
        InvokeRepeating("Enemyattack",1f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Enemyattack(){
        GameObject tempBullet = Instantiate(enemybullet, firePos);
        tempBullet.AddComponent<Enemybulletcontrol>();  
    }
}
