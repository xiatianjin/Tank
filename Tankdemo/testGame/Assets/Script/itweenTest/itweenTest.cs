using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class itweenTest : MonoBehaviour {
    public GameObject[] EnemyTankNum;   //坦克的种类（要是出现击中坦克）
    public iTweenPath[] PathNum;        //路径数组（有几条路径）
    public static int  num;             //坦克出现的的个数
    public float Enemy_time;            //运动的时间   
    public float Delay_Time;            //延迟多久出现

    bool isboolnum;
    public static bool IsEnemyFire;//敌人是否可以发射子弹

    public static bool isTwoPath;       //第二段路线

    public iTweenPath[] PathNum2;

    public static int levelnum;
    void Awake()
    {
        for (int i = 0; i < PathNum.Length;i++ )
        {
            Instantiate(PathNum[i]);
        }
    }
	// Use this for initialization
	void Start () {
        levelnum = 0;
        isboolnum = false;
        isTwoPath = false;
        IsEnemyFire = false;
	}
	
	// Update is called once per frame
	void Update () {
        print("levelnum=" + levelnum);
        if (Input.GetKeyDown(KeyCode.A)||iTwCam.isOnepath)
        {
            Inst_tank();
            iTwCam.isOnepath = false;
        }
       if (isboolnum)
       {
           if (GameObject.Find("GameObject(Clone)") != null)
           {
               print("有敌人" );
           }
           else
           {
               itweenTest.IsEnemyFire = false;
               levelnum++;
               for (int i = 0; i < PathNum.Length;i++ )
               {
                   PathNum[i] = PathNum2[i];
               }
               isTwoPath = true;
               print("没有敌人");
               isboolnum = false;
               if (levelnum>1)
               {
                   print("胜利");
                   playerBlood.isDealFire = true;
                   GameObject.Find("bgFailorSucceed").GetComponent<Image>().enabled = true;
                   GameObject.Find("FailorSucceed").GetComponent<Text>().text = "<color=#CC00FF>胜利\n\n点击屏幕重新开始游戏</color>";
               }
           }
       }
       	
	}

    //实例化坦克
    void Inst_tank()
    {
        for (int i = 0; i < EnemyTankNum.Length; i++)
        {
            num = EnemyTankNum.Length;
            int tNum = Random.Range(0, EnemyTankNum.Length);
            GameObject ins = Instantiate(EnemyTankNum[tNum]) as GameObject;
            ins.transform.position = (Vector3)iTweenPath.GetPath(PathNum[i].pathName).GetValue(0);
            Obj_itween(ins, PathNum[i], Enemy_time, Delay_Time);              
        }
    }
    
    /// <param name="obj  ：运动的对象" ></param> 
    /// <param name="path ：对象运动的路径"></param>
    /// <param name="iTime：对象运动的时间"></param>
    /// /// <param name="delay_Time：对象运动前等待的时间"></param>
    void Obj_itween(GameObject obj, iTweenPath path, float iTime,float delay_Time)
    {
        obj.transform.position = (Vector3)iTweenPath.GetPath(path.pathName).GetValue(0);
        iTween.MoveTo(obj, iTween.Hash("path", iTweenPath.GetPath(path.pathName), "time", iTime,"delay",delay_Time,
       "orienttopath", true, "looktime", 1f, "easetype", iTween.EaseType.easeInOutCubic, "looptype", iTween.LoopType.none, "oncomplete", "StopMove", "oncompletetarget", gameObject));
    }

    void StopMove()
    {
        Debug.Log(" 敌人到达目标点 ");
        isboolnum = true;
        IsEnemyFire = true;
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
    //            print("num=="+num);
    //            if (num<=0)
    //            {
    //                print("敌人全部死亡");
    //                Inst_tank();  //再次出现敌人                                                           
    //            }
    //        }
    //    }
        
    //}
}
