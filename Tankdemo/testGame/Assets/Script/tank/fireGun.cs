using UnityEngine;
using System.Collections;

public class fireGun : MonoBehaviour {
    float fire_time;
    int num;
   public static bool isFireGun;
	// Use this for initialization
	void Start () {
        isFireGun = false;
        num = 0;
        fire_time = 0;
	}
	
	// Update is called once per frame
    //void Update () {
    //    if (isFireGun)
    //    {
    //        fire_time += Time.deltaTime;
    //        if (fire_time > 0.3f)
    //        {
    //            print("实例化子弹");
    //            fire_time = 0;
    //        }
    //    }
       
    //}
    void OnPress()
    {
        num++;
        if (num%2==1)
        {
            print("开火了");
            isFireGun = true;
        }
        else
        {
            isFireGun = false;
            print("熄火了");
            num = 0;
        }

       
       
    }
}
