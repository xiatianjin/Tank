using UnityEngine;
using System.Collections;
/*
 *坦克的外挂设备  
 *
 */
public class TankGun : MonoBehaviour {

    public Rigidbody Gunshell;     //需要实例化的坦克
    public GameObject Fire_position; //实例化子弹的位置
    public GameObject GunFire_Particle;//机枪特效

    
  
    Rigidbody obj;

    float fire_time;
    public float ShellSpeed;
    public static bool isGunFire;
	// Use this for initialization
	void Start () {
        fire_time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(CubeSph.HitVec);
        fire_time += Time.deltaTime;
   
        if (Input.GetMouseButtonDown(1))
        {
            print("机枪的位置=" + CubeSph.HitVec+"点击的物体名字="+CubeSph.nan);
        }
      
        if (fireGun.isFireGun&&fire_time>0.3f)
        {
            isGunFire = true;

            print("发射炮弹");
            Quaternion cube2Rotate = Quaternion.LookRotation(Fire_position.transform.position - CubeSph.HitVec, Vector3.up);
            obj = Instantiate(Gunshell, Fire_position.transform.position, Quaternion.identity) as Rigidbody;
            obj.GetComponent<Rigidbody>().velocity = ((Fire_position.transform.position - CubeSph.HitVec)).normalized * (-ShellSpeed);
            obj.transform.rotation = cube2Rotate;
            //机枪特效
            GameObject Gun_Particle = Instantiate(GunFire_Particle, Fire_position.transform.position, Quaternion.identity) as GameObject;

            Destroy(Gun_Particle, 2);
            fire_time = 0;
        }
        
	}
}
