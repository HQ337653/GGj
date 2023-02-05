using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeController : MonoBehaviour
{
    public static ModeController instance;
    public static bool InInmagine { get; private set; }
    public delegate void handler(bool i);
    public static handler ModeChangediFToImagine;

    public static void change(bool toImagine)
    {
        if (toImagine!= InInmagine)
        {
            InInmagine=toImagine;
            ModeChangediFToImagine?.Invoke(InInmagine);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            change(!InInmagine);
        }
    }
}
