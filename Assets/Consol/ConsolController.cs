using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsolController : MonoBehaviour
{
    [SerializeField]
    GameObject planes;
    [SerializeField]
    float velocity;
    private void Awake()
    {
        ModeController.ModeChangediFToImagine += ChangeState;
    }

    private void ChangeState(bool i)
    {
        this.enabled=i;
    }
    public delegate void handler(int i);
    public static handler SetModeTo;
    public delegate void handle(Vector2 i);
    public static handle Move;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            SetModeTo?.Invoke(0);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            SetModeTo?.Invoke(1);
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            SetModeTo?.Invoke(1);
        }


        int horizontal = 0;
        int vertical = 0;
        if (Input.GetKey(KeyCode.W))
        {
            vertical += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            horizontal -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vertical -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontal += 1;
        }
        
        Vector2 direction = new Vector2(horizontal, vertical);
        Move?.Invoke(direction * velocity);
    }
}
