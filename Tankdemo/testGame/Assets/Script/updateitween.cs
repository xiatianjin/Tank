using UnityEngine;
using System.Collections;

public class updateitween : MonoBehaviour {
    public iTweenPath fapath;
    bool isQET;
    float i_time=0;
	// Use this for initialization
	void Start () {
        isQET = false;
        i_time = 6;
     //   transform.eulerAngles = new Vector3(30,20,60);
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(fapath.pathName), "time", 6, "delay", 0,
       "orienttopath", true, "looktime", 1f, "easetype", iTween.EaseType.linear, "onupdate", "iTweenUpdate", "oncomplete", "StopMove"));
	}

    void iTweenUpdate()
    {
        print("yundongyi 11");
       
        if (transform.position.x>=0&&isQET==false)
        {
            //print("时间=" + Time.realtimeSinceStartup);
            Time.timeScale = 0.1f;
            //iTween.Pause(this.gameObject);
            //print("停止");
                             
        }
    }


    void StopMove()
    {
        print("停止");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Time.timeScale = 1f;
            //iTween.Resume(this.gameObject);
            isQET = true;
            print("isQET=" + isQET);
        }
    }
}
