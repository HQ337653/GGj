using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieAfterInstanciate : MonoBehaviour
{
    public float duration;
    void Start()
    {
        StartCoroutine(dieProcess(duration));
    }

    IEnumerator dieProcess(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }

}
