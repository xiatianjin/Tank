using UnityEngine;
using System.Collections;

public class itweenPath : MonoBehaviour {

    public GameObject[] EnemyTankNum;   //坦克的种类（要是出现击中坦克）
    public iTweenPath PathNum;          //路径
    public int num;                     //坦克出现的的个数
    public float Enemy_time;            //运动的时间   
    public float Delay_Time;            //延迟多久出现
    void Awake()
    {
        
            Instantiate(PathNum);
        
    }
    // Use this for initialization
    void Start()
    {
        Enemy_time = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {

            Inst_tank();
        }
        

    }

    //实例化坦克
    void Inst_tank()
    {
        for (int i = 0; i < EnemyTankNum.Length; i++)
        {
       
            int tNum = Random.Range(0, EnemyTankNum.Length);
            GameObject ins = Instantiate(EnemyTankNum[tNum]) as GameObject;
            ins.transform.position = (Vector3)iTweenPath.GetPath(PathNum.pathName).GetValue(0);
            Obj_itween(ins, PathNum, Enemy_time, Delay_Time);

        }
    }

    /// <param name="obj  ：运动的对象" ></param> 
    /// <param name="path ：对象运动的路径"></param>
    /// <param name="iTime：对象运动的时间"></param>
    /// /// <param name="delay_Time：对象运动前等待的时间"></param>
    void Obj_itween(GameObject obj, iTweenPath path, float iTime, float delay_Time)
    {
        obj.transform.position = (Vector3)iTweenPath.GetPath(path.pathName).GetValue(0);
        iTween.MoveTo(obj, iTween.Hash("path", iTweenPath.GetPath(path.pathName), "time", iTime, "delay", delay_Time,
       "orienttopath", true, "looktime", 1f, "easetype", iTween.EaseType.easeInOutCubic, "looptype", iTween.LoopType.none, "oncomplete", "StopMove", "oncompletetarget", gameObject));
    }

    void StopMove()
    {
        Debug.Log(" 敌人到达目标点 ");

    }

    //void RayHit()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            print("hit.name=" + hit.transform.name);
    //            Destroy(hit.transform.gameObject);
    //            num--;
    //            print("num=" + num);
    //            if (num >= 0)
    //            {
                   
    //                Inst_tank();  //再次出现敌人

    //            }
    //            else
    //            {
    //                print("敌人全部死亡");
    //            }
    //        }
    //    }

    //}
}
