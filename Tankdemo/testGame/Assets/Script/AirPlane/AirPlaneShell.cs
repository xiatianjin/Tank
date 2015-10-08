using UnityEngine;
using System.Collections;
/*
 * 1.飞机的运动轨迹
 * 2.飞机空投导弹的脚本
 */
public class AirPlaneShell : MonoBehaviour {
    public GameObject airShell;//飞机投的导弹种类
    float shell_time;
    GameObject tank;
    public float itw_time;//运动的时间

    public GameObject ATShell;//轰炸的导弹
	// Use this for initialization
	void Start () {
        tank = GameObject.Find("First96A").gameObject;
        //tank = GameObject.Find("Cube").gameObject;
        print("坦克的位置="+tank.transform.position);
        transform.position = new Vector3(tank.transform.position.x, transform.localPosition.y, tank.transform.position.z);
        shell_time = 0;
        print(transform.position);
        iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(transform.localPosition.x, transform.localPosition.y, tank.transform.position.z-100), "time", itw_time, "easetype",iTween.EaseType.linear,"onupdate", "itwonupdate","oncomplete","StopMove"));
	}
	
	// Update is called once per frame
    void itwonupdate()
    {
        shell_time += Time.deltaTime;
      
        if (Input.GetKeyDown(KeyCode.A)||shell_time>1f)
        {
            for (int i = -30; i < 30;i++ )
            {
                i+=10;
                GameObject Shell = Instantiate(airShell, new Vector3(transform.localPosition.x+i, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
                Shell.transform.localEulerAngles = new Vector3(0, 90, 0);
                Destroy(Shell, 4);
            }
            shell_time = 0;
        }
        	
	}

    void StopMove()
    {
        Destroy(this.gameObject);
        GameObject AirAT = Instantiate(ATShell, transform.position, Quaternion.identity) as GameObject;
        AirAT.transform.position = tank.transform.position + new Vector3(0, 30, 0);
        Destroy(AirAT, 5);
    }
   
}
