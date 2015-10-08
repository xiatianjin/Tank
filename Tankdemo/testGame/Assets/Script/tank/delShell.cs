using UnityEngine;
using System.Collections;
/*
 * 控制导弹的爆炸删除
 */
public class delShell : MonoBehaviour {
    public float ins_time;
    public float lizi_time;
   // public GameObject shell_parclic;
    GameObject ins;
    public GameObject lizi;//粒子

    public GameObject Tail_Particle;
	// Use this for initialization
    void Start () {
    
	    ins_time = 0;
        lizi_time = 0;
    }
	// Update is called once per frame
    void Update()
    {
        ins_time += Time.deltaTime;
        lizi_time += Time.deltaTime;
       
        if (lizi_time >= 5f)
        {
            //到一定时间爆炸
            AudioManager.Main.PlayNewSound(MusicClass.hit_ground);
            GameObject ss = Instantiate(lizi, transform.position, Quaternion.identity) as GameObject;
            ss.transform.eulerAngles = new Vector3(-90, 0, 0);
            Destroy(ss, 4);

            lizi_time = 0;
        }
      
        Destroy(gameObject,4);
    }
 
    void OnTriggerEnter(Collider col)
    {
        print("导弹删除的时候col.transform.tag=" + col.transform.tag);
        if (col.transform.tag == "CubeDown")
        {
            AudioManager.Main.PlayNewSound(MusicClass.hit_ground);
            GameObject ss = Instantiate(lizi, transform.position, Quaternion.identity) as GameObject;
            ss.transform.eulerAngles = new Vector3(-90, 0, 0);
            Destroy(ss, 5);
           // Destroy(gameObject);
            
        }
        else if (col.transform.tag == "Terrain")
        {
            print("地面爆炸");
            AudioManager.Main.PlayNewSound(MusicClass.hit_ground);
            GameObject ss = Instantiate(lizi, transform.position, Quaternion.identity) as GameObject;
            ss.transform.eulerAngles = new Vector3(-90, 0, 0);
            Destroy(ss, 5);
            //Destroy(gameObject);
        }
        else if (col.transform.tag == "zdman")
        {
            print("地面爆炸");
            AudioManager.Main.PlayNewSound(MusicClass.hit_ground);
            GameObject ss = Instantiate(lizi, transform.position, Quaternion.identity) as GameObject;
            ss.transform.eulerAngles = new Vector3(-90, 0, 0);
            Destroy(ss, 1);
           // Destroy(gameObject);
        }
       
    }
}
