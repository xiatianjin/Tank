using UnityEngine;
using System.Collections;

public class iTwCam : MonoBehaviour
{
    public GameObject TankFirst;        //坦克的曲线运动


    public static bool isOnepath;

    bool isMR;

    // Use this for initialization
    void Start()
    {
        isMR = false;

        isOnepath = false;
      
       

        Obj_itweenString(TankFirst, "First96A1", 18, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(TankFirst.transform.position);

        if (itweenTest.isTwoPath && itweenTest.levelnum < 2)
        {
            Obj_itweenString(TankFirst, "First96A2", 18, 0.3f);
            itweenTest.isTwoPath = false;
        }

        if (isMR)
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, new Vector3(0,4,-6), 0.1f*Time.deltaTime);
           
            if (transform.localPosition.x<=4.01f)
            {
                transform.localPosition = new Vector3(0,4,-6);
                isMR = false;
                transform.GetComponent<Camera>().depth = -1;
            }

        }
        if (Input.GetMouseButtonDown(0) && playerBlood.isDealFire)
        {
            Application.LoadLevel(1);
        }

    }


    /// <param name="obj       ：运动的对象" ></param> 
    /// <param name="path      ：对象运动的路径"></param>
    /// <param name="iTime     ：对象运动的时间"></param>
    /// <param name="delay_Time：对象运动前等待的时间"></param>
    void Obj_itween(GameObject obj, iTweenPath path, float iTime, float delay_Time)
    {
        obj.transform.position = (Vector3)iTweenPath.GetPath(path.pathName).GetValue(0);
        iTween.MoveTo(obj, iTween.Hash("path", iTweenPath.GetPath(path.pathName), "time", iTime, "delay", delay_Time,
       "orienttopath", true, "looktime", 1f, "easetype", iTween.EaseType.easeInOutCubic, "looptype", iTween.LoopType.none, "oncomplete", "StopMove", "oncompletetarget", gameObject));
    }

    void Obj_itweenString(GameObject obj, string path, float iTime, float delay_Time)
    {
        obj.transform.position = (Vector3)iTweenPath.GetPath(path).GetValue(0);
        iTween.MoveTo(obj, iTween.Hash("path", iTweenPath.GetPath(path), "time", iTime, "delay", delay_Time,
       "orienttopath", true, "looktime", 1f, "easetype", iTween.EaseType.easeInOutCubic, "looptype", iTween.LoopType.none, "oncomplete", "StopMove", "oncompletetarget", gameObject));
    }

    void StopMove()
    {
        Debug.Log(" 到达目标点 ");
        isMR = true;
        
        TankRotate();
    }

    void TankRotate()
    {
        print("旋转");
        //iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(5, 0, 0), "time", 2, "oncomplete", "StopRotate", "oncompletetarget", gameObject));
       
        isOnepath = true;
    }

    void StopRotate()
    {
        print("旋转结束");
        // isOnepath = true;
    }
}
