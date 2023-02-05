using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour{

    [SerializeField]
    float defaltMaxHp;
    [SerializeField]

    float currentMaxHP;
    [SerializeField]

    float currentHp;

    void Start(){
        Debug.Log(gameObject.name);
        defaltMaxHp = 30f;
        currentHp = defaltMaxHp;
    
    }

    public void Damage(float amount)
    {
        EffectController.DoDamagePopUp(transform.position,amount);
        currentHp -= amount;
        if (currentHp <= 0)
        {
            Debug.Log(currentHp);
            Destroy(gameObject);
        }

    }

}
