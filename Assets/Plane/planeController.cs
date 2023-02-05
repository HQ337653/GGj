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
    [SerializeField]
    GameObject[] shootingMode;
    public void initiate(Vector3 position, int index)
    {
        indx=index;
        TMP.text = index.ToString();
    }
    private void Start()
    {
        setMode(0);
        ConsolController.SetModeTo += setMode;
        ConsolController.Move += Move;
    }

    private void Move(Vector2 i)
    {
        Rigidbody2D.velocity = i;
    }

    private void OnDestroy()
    {
        ConsolController.SetModeTo -= setMode;
    }
    public void changeNum(int index)
    {
        indx = index;
        TMP.text= index.ToString();
    }
    #region IndividualControl
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
    public void Explode()
    {
        Vector2 center = ExplodeRegion.transform.TransformPoint(ExplodeRegion.offset);

        //Get the size of the collider in world space
        Vector2 size = ExplodeRegion.size;

        //Check if the collider overlaps with any other colliders in the scene
        Collider2D[] overlaps = Physics2D.OverlapBoxAll(center, size, 0);

        //Iterate over the overlaps and do something with them
        foreach (Collider2D overlap in overlaps)
        {
            Debug.Log("Overlap with " + overlap.gameObject.name);
            overlap.GetComponent<EnemyHp>()?.Damage(100);
        }
    }
    #endregion

    #region bullet
    List<bulletController> shootingProcess;
    GameObject ShootingPrefeb;
    [SerializeField]
    BoxCollider2D ExplodeRegion;


    public void setMode(int index)
    {
        foreach(GameObject g in shootingMode)
        {
            g.SetActive(false);
        }
        shootingMode[index].SetActive(true);

    }
    #endregion
    internal void die()
    {
        planeModeController.PlaneDie(indx);
    }
}
