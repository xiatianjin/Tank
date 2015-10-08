using UnityEngine;
using System.Collections;

public class EnemyPath : MonoBehaviour {
 public GameObject[] EnemyTankNum;   //坦克的种类（要是出现击中坦克）
    public iTweenPath enemyPath;          //路径
    public int EnemyNum;                     //坦克出现的的个数
    public float Enemy_time;            //运动的时间   
    public float Delay_Time;            //延迟多久出现
    GameObject ins;

    public static bool isenemyFire; //敌人是否开火;
    public  bool isManFire;
    float fire_time;

    float Rom_f;
    // Use this for initialization
    void Start()
    {
        fire_time = 0;
        enemyPath = this.gameObject.GetComponent<iTweenPath>();
        isenemyFire = false;
        isManFire = false;
        Inst_tank();
    }

    // Update is called once per frame
    void Update()
    {
        
        print("EnemyNum=" + EnemyNum);
        if (ins==null&&EnemyNum>0)
        {
            Inst_tank();  //再次出现敌人
            isManFire = false;
        }
        if (isManFire)
        {
            if (ins != null)
            {
                fire_time += Time.deltaTime;
                if (fire_time >= 0 && fire_time <= 2)
                {
                    if (ins.transform.FindChild("AK/JQ0.75_Fire").gameObject != null)
                    {
                        ins.transform.FindChild("AK/JQ0.75_Fire").GetComponent<ParticleSystem>().Play();
                    }
                   
                    StartCoroutine("zdmanFire", 2);
                    ins.GetComponent<Animator>().SetBool("manfire", true);
                    if (Time.frameCount%60==0)
                    {
                        Rom_f = Random.Range(0, 20);
                        if (Rom_f<20)
                        {
                            if (playerBlood.playerArmor.fillAmount <= 0)
                            {
                                playerBlood.playerArmor.fillAmount = 0;
                                playerBlood.spriteBlood.fillAmount -= (1f / playerConfig.TankBlood) * enemyZDManConfig.zdManHarm;
                                if (playerBlood.spriteBlood.fillAmount <= 0.01f)
                                {
                                    playerBlood.spriteBlood.fillAmount = 0;
                                    print("玩家被人打死了");
                                }

                            }
                            else
                            {
                                playerBlood.playerArmor.fillAmount -= (1f / playerConfig.TankArmor) * enemyZDManConfig.zdManHarm;
                                print("被人打了");
                            }
                        }
                       
                    }
                    
                }
                else if (fire_time > 2 && fire_time <= 4)
                {
                    ins.GetComponent<Animator>().SetBool("manfire", false);
                    if (ins.transform.FindChild("AK/JQ0.75_Fire").gameObject!=null)
                    {
                        ins.transform.FindChild("AK/JQ0.75_Fire").GetComponent<ParticleSystem>().Stop();
                    }
                   
                }
                else if (fire_time > 4)
                {
                    fire_time = 0;
                }
            }
            else
            {
                isManFire = false;
            }
           
            
          
        }
    }

    //实例化坦克
    void Inst_tank()
    {
        for (int i = 0; i < EnemyTankNum.Length; i++)
        {
       
            int tNum = Random.Range(0, EnemyTankNum.Length);
             ins = Instantiate(EnemyTankNum[tNum]) as GameObject;
            ins.transform.position = (Vector3)iTweenPath.GetPath(enemyPath.pathName).GetValue(0);
            Obj_itween(ins, enemyPath, Enemy_time, Delay_Time);

        }
    }

    /// <param name="obj  ：运动的对象" ></param> 
    /// <param name="path ：对象运动的路径"></param>
    /// <param name="iTime：对象运动的时间"></param>
    /// /// <param name="delay_Time：对象运动前等待的时间"></param>
    void Obj_itween(GameObject obj, iTweenPath path, float iTime, float delay_Time)
    {
        EnemyNum--;
        obj.transform.position = (Vector3)iTweenPath.GetPath(path.pathName).GetValue(0);
        iTween.MoveTo(obj, iTween.Hash("path", iTweenPath.GetPath(path.pathName), "time", iTime, "delay", delay_Time,
       "orienttopath", true, "looktime", 1f, "easetype", iTween.EaseType.easeInOutCubic, "looptype", iTween.LoopType.none, "oncomplete", "StopMove", "oncompletetarget", gameObject));
    }

    void StopMove()
    {
        Debug.Log(" 敌人到达目标点 ");
        isenemyFire = true;
        if (ins.GetComponent<Animator>()!=null)
        {
            
            isManFire = true;            
        }
                
    }
    IEnumerator zdmanFire()
    {
        ins.transform.FindChild("AK/JQ0.75_Fire").GetComponent<ParticleSystem>().Play();
        if (ins != null)
        {
            yield return new WaitForSeconds(5);
            
        }
    }
  
}


