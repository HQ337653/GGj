using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class StationaryfighterAi : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed;
    void Start()
    {
        transform.Rotate(Vector3.forward, 180);
        speed = Random.Range(0.1f, 0.2f);

        StartCoroutine(Enemymovements());

    }

    void FixedUpdate()
    {
        speed *= 1.005f;


    }


    IEnumerator Enemymovements()
    {
        float bottomwally = -10f;
        while (transform.position.y > bottomwally)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            yield return null;
        }
        Destroy(gameObject);
        yield return null;

    }
}

