using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybulletcontrol : MonoBehaviour
{
    // Start is called before the first frame update
    private float enemybulletspeed = 10f;
    void Start()
    {
        Destroy(gameObject, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,10f);
        transform.Translate(new Vector2(0,enemybulletspeed*Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
    }
}
