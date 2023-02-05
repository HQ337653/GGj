using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float interval = 1;
    public GameObject prefeb;
    public Vector2 direction;
    public float speed;
    private void OnEnable()
    {
        StartCoroutine(shootProcess());
    }
    public IEnumerator shootProcess()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            GameObject g= Instantiate(prefeb);
            g.transform.position = transform.position;
            g.GetComponent<Rigidbody2D>().velocity = direction*speed;
        }
    }
}
