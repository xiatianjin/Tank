using UnityEngine;
using System.Collections;

public class enemyshell : MonoBehaviour {

    public float ins_time;
    public float lizi_time;
    // public GameObject shell_parclic;
    GameObject ins;
    public GameObject lizi;//粒子

    public GameObject Tail_Particle;
    // Use this for initialization
    void Start()
    {

        ins_time = 0;
        lizi_time = 0;
    }
    // Update is called once per frame
    void Update()
    {
        ins_time += Time.deltaTime;
        lizi_time += Time.deltaTime;
        if (ins_time >= 0.5f)
        {
            //拖尾的效果
            GameObject ss = Instantiate(Tail_Particle, transform.position, Quaternion.identity) as GameObject;
            ss.transform.eulerAngles = new Vector3(-90, 0, 0);
            Destroy(ss, 4);
            // ins = Instantiate(shell_parclic,transform.position,Quaternion.identity)as GameObject;
            ins_time = 0;
        }
        if (lizi_time >= 3f)
        {
            //到一定时间爆炸
           // AudioManager.Main.PlayNewSound(MusicClass.hit_ground);
            GameObject ss = Instantiate(lizi, transform.position, Quaternion.identity) as GameObject;
            ss.transform.eulerAngles = new Vector3(-90, 0, 0);
            Destroy(ss, 4);

            lizi_time = 0;
            Destroy(gameObject);
        }

       
    }

    void OnTriggerEnter(Collider col)
    {
        print("敌人子弹+col.transform.tag=" + col.transform.tag);
        if (col.transform.tag == "player")
        {
            Destroy(gameObject, 1);
        }
        else if (col.transform.tag == "Terrain")
        {
            print("地面爆炸");
            //AudioManager.Main.PlayNewSound(MusicClass.hit_ground);
            //GameObject ss = Instantiate(lizi, transform.position, Quaternion.identity) as GameObject;
            //ss.transform.eulerAngles = new Vector3(-90, 0, 0);
            //Destroy(ss, 5);
            //Destroy(gameObject);
        }

    }
}
