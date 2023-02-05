using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaBulletOne : MonoBehaviour
{
    [SerializeField]
    float DamageAmount = 10f;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHp HpScript = collision.GetComponent<EnemyHp>();
        if (HpScript != null)
        {
            HpScript.Damage(DamageAmount);
            Destroy(gameObject);
        }
        
        
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
