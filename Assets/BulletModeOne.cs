using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletModeOne : MonoBehaviour
{
    [SerializeField]
    bulletController c;
    private void OnEnable()
    {
        StartCoroutine(shootProcess());
        StartCoroutine(changeAngle());
    }

    public float interval = 0.3f;
    public GameObject prefeb;
    public Vector2 direction;
    public float velocity;
    public IEnumerator shootProcess()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            GameObject g = Instantiate(prefeb);
            g.transform.position = transform.position;
            g.GetComponent<Rigidbody2D>().velocity = direction* velocity;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            g.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


            g = Instantiate(prefeb);
            g.transform.position = transform.position;
            g.GetComponent<Rigidbody2D>().velocity = velocity * new Vector2(-direction.x, direction.y);
             angle = Mathf.Atan2(direction.y, -direction.x) * Mathf.Rad2Deg;
            g.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public IEnumerator changeAngle()
    {
         Vector2 start = new Vector2(0, 1);
         Vector2 end = new Vector2(1, 0);
        while (true)
        {
            float elapsedTime = 0f;
            while (elapsedTime < 1)
            {
                elapsedTime += Time.deltaTime;
                direction = Vector2.Lerp(start, end, elapsedTime / 1);
                yield return null;
            }

            //Swap the start and end values so the interpolation goes in the opposite direction
            Vector2 temp = start;
            start = end;
            end = temp;
        }
    }
}
