using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopUp : MonoBehaviour
{
    // Start is called before the first frame update
    public void Set(float amount)
    {
        TextMeshPro textMeshPro = GetComponent<TextMeshPro>();
        textMeshPro.text = amount.ToString();
        StartCoroutine(dieProcess(0.5f));
    }

    IEnumerator dieProcess(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
