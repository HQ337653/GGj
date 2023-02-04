using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyai : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed;
    void Start(){
        transform.Rotate(Vector3.forward,180);
        speed = Random.Range(1f,6f);

        StartCoroutine(Enemymovements());
     
    }

    
    IEnumerator Enemymovements(){
        float bottomwally = -5f;
        while(transform.position.y > bottomwally){
            transform.Translate(Vector3.up*Time.deltaTime*speed);
            yield return null;
        }
        Destroy(gameObject);
        yield return null;
        
    }
}
