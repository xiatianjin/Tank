using UnityEngine;
using System.Collections;

public class UICameTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        print("ui=" + IsMouseOverUI);
        if (IsMouseOverUI)
        {
            print("点击在NGUI上");
        }
        
	
	}
    /// <summary>
    /// 鼠标是否在Ngui的UI界面上
    /// </summary>
    public static bool IsMouseOverUI
    {
        get
        {
            Vector3 mousePostion = Input.mousePosition;
            GameObject hoverobject = UICamera.Raycast(mousePostion) ? UICamera.lastHit.collider.gameObject : null;
            if (hoverobject != null)
            {
                return true;
               
            }
            else
            {
                return false;
                print("没有点击在NGUI");
            }
        }
    }
}
