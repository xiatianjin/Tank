using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*
 * 玩家运动的路径
 * 玩家死亡后重新开始
 */
public class playerPath : MonoBehaviour
{
    public GameObject play;         //玩家
    public float play_Time;         //玩家运动时间
    public float delay_Time;         //w玩家运动延迟时间

    public iTweenPath[] play_path;  //玩家要行走的路径
    int path_num;                   //路径的数量
    int path_i;

    public int[] Run_path_EnNum ;     //用来判断player的运动路线（往下一段路程运动）
    int run_num;                      //用来获取每一轮所要歼灭的敌人的数目

    //敌人运动的路线
    public GameObject[] Enemy_Path;
    int i_Path;                       //数组--敌人运动的路径

    public static int EnemyAllNum;    //消灭敌人的总数目

    public static bool isTankRotate;  //判断坦克的炮台能否旋转 true 旋转 false不能旋转(过期)

    //UI界面
    public GameObject uifire;

    public GameObject ImageTouch;//用来控制触摸
    void Awake()
    {
        ImageTouch = GameObject.Find("Canvas/ImageTouch").gameObject;
        isTankRotate = false;
        i_Path = -1;
        for (int i = 0; i < Enemy_Path.Length; i++)
        {
            for (int j = 0; j < Enemy_Path[i].transform.childCount;j++ )
            {
                print("Enemy_Path[i].transform.childCount=" + Enemy_Path[i].transform.childCount);
                Enemy_Path[i].transform.GetChild(j).GetComponent<EnemyPath>().enabled = false;
            }

           
        }
    }
    // Use this for initialization
    void Start()
    {
        uifire = GameObject.Find("UIfire");
        uifire.SetActive(false);
        EnemyAllNum = 0;
        //player路径
        #region
        path_num = play_path.Length;
        path_i = play_path.Length;
        print("path_Num=" + path_num + " path_i= " + path_i);
        Obj_itween(play, play_path[path_num - path_i], play_Time, delay_Time);
       // StartCoroutine(Obj_itween(play, play_path[path_num - path_i], play_Time, delay_Time));
      //  print("path_num - path_i=" + (path_num - path_i) + "  ");
        #endregion

        //
       

    }

    void Run_Path()
    {
       
            run_num = Run_path_EnNum[path_num - path_i ];
            print("EnemyAllNum=" + EnemyAllNum + "  run_num=" + run_num + "  path_num - path_i=" + (path_num - path_i));
            if ( (path_num - path_i )== Run_path_EnNum.Length -1)
            {
                if (run_num == EnemyAllNum)
                {
                    print("胜利");
                    playerBlood.isDealFire = true;
                    GameObject.Find("bgFailorSucceed").GetComponent<Image>().enabled = true;
                    GameObject.Find("FailorSucceed").GetComponent<Text>().text = "<color=#CC00FF>胜利\n\n点击屏幕重新开始游戏</color>";
                }
            }
            else if (run_num == EnemyAllNum && (path_num - path_i) < Run_path_EnNum.Length-1 )
            {
                path_i--;
                print("走一段路程");
                isTankRotate = false;
               // StartCoroutine(Obj_itween(play, play_path[path_num - path_i], play_Time, delay_Time));//itween运动
                Obj_itween(play, play_path[path_num - path_i], play_Time, delay_Time);
                EnemyAllNum = 0;
            }

            if (Input.GetMouseButtonDown(0) && playerBlood.isDealFire)
            {
                Application.LoadLevel(0);//重新开始
            }
    }

    // Update is called once per frame
    void Update()
    {
        Run_Path();
       

    }

    void Obj_itween(GameObject obj, iTweenPath path, float iTime, float delay_Time)
    {
        ImageTouch.SetActive(false);
        fireGun.isFireGun = false;
        uifire.SetActive(false);
       // yield return new WaitForSeconds(delay_Time);
        transform.GetComponent<Camera>().enabled=true;
        Camera.main.GetComponent<Camera>().enabled = false;
        obj.transform.position = (Vector3)iTweenPath.GetPath(path.pathName).GetValue(0);
        iTween.MoveTo(obj, iTween.Hash("path", iTweenPath.GetPath(path.pathName), "time", iTime, "delay", delay_Time,
       "orienttopath", true, "looktime", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none, "oncomplete", "StopMove", "oncompletetarget", gameObject));

        GameObject.Find("First96A/ZTZ96A_FirstCam/Tank_paotai").transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    
    //itween动画播放停止的
    void StopMove()
    {
        ImageTouch.SetActive(true);
        Debug.Log(" 到达目标点 ");
        uifire.SetActive(true);
        GameObject.Find("Main Camera").GetComponent<Camera>().enabled = true;//主摄像机，开炮时候用的相机
        transform.GetComponent<Camera>().enabled = false; //移动的时候相机（停止运动的时候关掉）
        
        i_Path++;
        for (int j = 0; j < Enemy_Path[i_Path].transform.childCount; j++)
        {
          
            Enemy_Path[i_Path].transform.GetChild(j).GetComponent<EnemyPath>().enabled = true;
        }
        isTankRotate = true;
       
    }

}
