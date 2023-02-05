using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        Destroy(gameObject, 10f);
        transform.Translate(new Vector2(0, enemybulletspeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Enemies")
        {
            Destroy(gameObject);
        }

    }

    public void Bullettimestop()
    {
        enemybulletspeed = 0;
    }
    public void Bulletmovementcontrol(Vector2 destination)
    {
        transform.DOMove(destination, 0.5f);

    }
}
