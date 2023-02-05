using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    [SerializeField]
    Transform top;
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0,-5);
    }
    private void OnBecameInvisible()
    {
        transform.position = top.position;
    }

}
