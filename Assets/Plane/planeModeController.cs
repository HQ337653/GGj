using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class planeModeController : MonoBehaviour
{
   static planeModeController instance;

    [SerializeField]
    List<planeController> planes=new List<planeController>();
    planeController currentController;

    public float MoveSpeed = 1;
    int currentIndex;

    [SerializeField]
    GameObject planePrefeb;
    private void Awake()
    {
        instance=this;
        ModeController.ModeChangediFToImagine += ChangeState;
        currentController = planes[0];
        currentIndex = 0;
    }
    private void Start()
    {
        planes[currentIndex].selected();
    }
    private void ChangeState(bool i)
    {
        this.enabled = !i;
        if (i)
        {
            foreach (planeController p in planes)
            {
                p.NotInMoce();
            }
        } else if (!i)
        {
            foreach (planeController p in planes)
            {
                p.Unselected();
            }
            planes[currentIndex].selected();
        }
    }

    //change plane to Index
    public void changeControl(int PlaneIndex)
    {
        if (planes.Count==0)
        {
            Debug.Log("LLLLLOOOOOOSSSSSSWEEEEEEEEEEEEE");
            return;
        }
        currentIndex=PlaneIndex;
        if (PlaneIndex< planes.Count)
        {
            currentController=planes[PlaneIndex];
        }

        foreach (planeController p in planes)
        {
            p.Unselected();
        }
        planes[PlaneIndex].selected();
    }

    private void Update()
    {
        #region changeDirection
        int horizontal =0;
        int vertical=0;
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
        
        Vector2 direction = new Vector2(horizontal,vertical);
        if (currentController!=null)
        {
        currentController?.setVelocity(direction* MoveSpeed);
        }

        #endregion

        #region changePlane

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentIndex< planes.Count-1)
            {
                currentIndex += 1;
            }
            else
            {
                currentIndex = 0;

            }
            changeControl(currentIndex);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentIndex > 0)
            {
                currentIndex -= 1;
            }
            else
            {
                currentIndex = planes.Count - 1;
            }
            changeControl(currentIndex);
        }
        #endregion


       
            if (Input.GetKeyDown(KeyCode.E))
        {
            currentController.Explode();
        }



    }

    public static void PlaneDie(int index)
    {
        List<planeController>  planes = instance.planes;
        int currentIndex = instance.currentIndex;
        planes.RemoveAt(index);
        for(int i =0; i< planes.Count; i++)
        {
            planes[i].changeNum(i+1);
        }
        if (currentIndex == index)
        {
                instance.currentIndex = 0;
                instance.changeControl(currentIndex);
        }
    }

    public static void AddPlane()
    {
        List<planeController> planes = instance.planes;
        int currentIndex = instance.currentIndex;

        Vector3 position = instance.transform.position;
        GameObject g = Instantiate(instance.planePrefeb, instance.gameObject.transform);
        planes.Add(g.GetComponent<planeController>());
        g.GetComponent<planeController>().initiate(position,planes.Count);
        
    }

}
