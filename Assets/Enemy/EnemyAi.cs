using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyai : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed;
    private Transform direction;
    void Start()
    {
        speed = Random.Range(1f,6f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*Time.deltaTime*speed);
    }
}
