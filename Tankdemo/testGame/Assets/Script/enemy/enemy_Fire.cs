using UnityEngine;
using System.Collections;
/*
 * 敌人到达目标地点的时候 自动开炮
 */
public class enemy_Fire : MonoBehaviour
{  
    public Rigidbody shell;             //子弹(不跳蛋，有伤害)
    public Rigidbody TDShell;           //子弹（跳弹，没有伤害）
    Rigidbody obj;  
     float power;                 //子弹初速度  
    public GameObject particle_fire;    //粒子效果//炮管的Fire
    
    public GameObject cube2;            //小目标(用来控制导弹方向)
 
    //敌人发射炮弹命中的概率
    public int int_probability = 0;     //定义概率发的百分数
    float Fire_time;                    //多长时间发射一枚炮弹
	public float Time_min;
public float Time_max;
   
   
    // Use this for initialization
    void Start()
    {
        power = 300;      
       
        Fire_time = Random.Range(Time_min, Time_max);
        
        InvokeRepeating("RandomProbability", Random.Range(3,6), Fire_time); 
    }

    void RandomProbability()
    {
        if ((itweenTest.IsEnemyFire||EnemyPath.isenemyFire)&&playerBlood.isDealFire==false)
        {
            int i = Random.Range(1, 101);
           
            if (i <= int_probability)
            {

                GameObject Fire = Instantiate(particle_fire, transform.position, Quaternion.identity) as GameObject;
                Fire.transform.parent = transform;
                Fire.transform.localEulerAngles = new Vector3(-90,180,0);
                Destroy(Fire, 3);
                
                Quaternion cube2Rotate = Quaternion.LookRotation(transform.position - cube2.transform.position, Vector3.up);
                obj = Instantiate(shell, transform.position, Quaternion.identity) as Rigidbody;
              
                obj.GetComponent<Rigidbody>().velocity = ((transform.position - cube2.transform.position)).normalized * (-power);
                obj.transform.rotation = cube2Rotate;
               
            }
            else
            {
                GameObject Fire = Instantiate(particle_fire, transform.position, Quaternion.identity) as GameObject;
                Fire.transform.parent = transform;
                Fire.transform.localEulerAngles = new Vector3(-90, 180, 0);
                Destroy(Fire, 3);
              
                Quaternion cube2Rotate = Quaternion.LookRotation(transform.position - cube2.transform.position, Vector3.up);
                //跳弹的特效
                obj = Instantiate(TDShell, transform.position, Quaternion.identity) as Rigidbody;
                obj.GetComponent<Rigidbody>().velocity = ((transform.position - cube2.transform.position)).normalized * (-power);
                obj.transform.rotation = cube2Rotate;
            }
        }
       
    }


}
