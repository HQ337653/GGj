using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybulletcontrol : MonoBehaviour
{
    // Start is called before the first frame update
    public float enemybulletspeed = 2f;
    void Start()
    {
        //Destroy(gameObject, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0,enemybulletspeed*Time.deltaTime));
    }
}
