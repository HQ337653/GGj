using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField]
    GameObject DamagePopup;
    static EffectController instance;
    private void Awake()
    {
        instance = this;
    }
    public static void DoDamagePopUp(Vector3 worldPosition, float amount)
    {
        GameObject g= Instantiate(instance.DamagePopup);
        g.transform.position = worldPosition;
        g.GetComponent<DamagePopUp>().Set(amount);
    }
}
