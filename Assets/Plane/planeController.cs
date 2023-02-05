using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class planeController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D Rigidbody2D;
    [SerializeField]
    SpriteRenderer Renderer;
    [SerializeField]
    Color A;
    [SerializeField]
    Color B;
    [SerializeField]
    Color C;
    [SerializeField]
    TextMeshPro TMP;
    [SerializeField]
    int indx;

    public void initiate(Vector3 position, int index)
    {
        indx=index;
        TMP.text = index.ToString();
    }

    public void changeNum(int index)
    {
        indx = index;
        TMP.text= index.ToString();
    }
    public void setVelocity(Vector2 V)
    {
        Rigidbody2D.velocity = V;
    }

    public void selected()
    {
        Renderer.color = A;    
    }
    public void Unselected()
    {
        Renderer.color = B;
        StartCoroutine(Stop());
    }
    public void NotInMoce()
    {
        Renderer.color = C;
        StartCoroutine(Stop());
    }
    IEnumerator Stop()
    {
        yield return null;
        Rigidbody2D.velocity = Vector2.zero;

    }

    internal void die()
    {
        planeModeController.PlaneDie(indx);
    }
}
