using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField]
    float defaltMaxHp;
    [SerializeField]

    float currentMaxHP;
    [SerializeField]

    float currentHp;

    void Start(){
        defaltMaxHp = 1000f;
    }

    public void Damage(float amount)
    {
        EffectController.DoDamagePopUp(transform.position,amount);
        currentHp = defaltMaxHp;
        currentHp -= amount;
        if (currentHp < 0)
        {
            Destroy(gameObject);

        }

    }

}
