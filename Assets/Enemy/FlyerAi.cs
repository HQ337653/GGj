using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerAi : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed;
    private float rotate;
    private float sidewallx;
    void Start()
    {
        speed = 3f;
        rotate = -10f;
        sidewallx = 22f;
        if (transform.position.x < 0)
        {
            rotate = 10f;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        transform.Rotate(Vector3.forward, Time.deltaTime * rotate);
        if (transform.rotation.z < -0.6f || transform.rotation.z > 0.6f)
        {
            speed = 5f;
            rotate = 0f;
        }
        if (transform.position.x > sidewallx || transform.position.x < -sidewallx)
        {
            Destroy(gameObject);
        }

    }

}

