using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeModeController : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        ModeController.ModeChangediFToImagine += ChangeState;
    }

    private void ChangeState(bool i)
    {
        this.enabled = !i;
    }
}
