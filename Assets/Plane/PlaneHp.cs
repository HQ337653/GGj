using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneHp : MonoBehaviour
{
    [SerializeField]
    planeController controller;
    [SerializeField]
    float currentHp;
    [SerializeField]
    float MaxHp;

    public void takeDamage(float damage)
    {
        currentHp-=damage;
        if(currentHp < 0)
        {
            controller.die();
        }
    }

}
