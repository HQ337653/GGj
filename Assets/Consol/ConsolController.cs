using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsolController : MonoBehaviour
{
    private void Awake()
    {
        ModeController.ModeChangediFToImagine += ChangeState;
    }

    private void ChangeState(bool i)
    {
        this.enabled=i;
    }
}
