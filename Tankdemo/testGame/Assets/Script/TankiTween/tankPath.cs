using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class tankPath : MonoBehaviour {

    public GameObject camback;
    List<Vector3> path_one=new List<Vector3>();
	// Use this for initialization
	void Start () {
        iTweenPathone();
        path_one.Add(new Vector3(0, 0, -109));
        path_one.Add(new Vector3(-16, 2, -69));
        path_one.Add(new Vector3(1, 0, 9));
        camback.SetActive(false);
	}
    //添加第一个路径坐标
	void iTweenPathone()
    {
       
    }
    //第一个路径运动
    void ItMoveOne()
    {
        iTween.MoveTo(this.gameObject, iTween.Hash("path_one", path_one.ToArray(), "time", 12f,
          "orienttopath", true, "looktime", 1f, "easetype", iTween.EaseType.easeInOutCubic));
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            camback.SetActive(true);
            ItMoveOne();
        }

        iTween.MoveTo(this.gameObject, iTween.Hash("path_one", path_one.ToArray(), "time", 12f,
          "orienttopath", true, "looktime", 1f, "easetype", iTween.EaseType.easeInOutCubic));
	
	}
}
