using UnityEngine;
using System.Collections;

public class manAnimator : MonoBehaviour
{

    private Animator anima;
    public static GameObject First96A;

    private float float_Man;

   

    public GameObject Gold;//死亡时候的实例化的金币

    public GameObject man_Particle;//人物被打倒的粒子特效(喷血)

    public GameObject Deal_ins; //死亡后播放死亡的动画
    // Use this for initialization
    void Start()
    {
       transform.FindChild("AK/JQ0.75_Fire").GetComponent<ParticleSystem>().Stop();
        GetComponent<BoxCollider>().enabled = true;
        float_Man = 1;
         First96A = GameObject.Find("First96A/ZTZ96A_FirstCam").gameObject;
        anima = GetComponent<Animator>();
    }  

  
    void OnTriggerEnter(Collider col)
    {
        print("人="+col.transform.tag);
        if (col.transform.tag=="TankShell")
        {
            Destroy(col.transform.gameObject);
            GameObject Ins_deal_man = Instantiate(man_Particle, transform.position + new Vector3(0, 1, 0), Quaternion.identity) as GameObject;
            Destroy(Ins_deal_man, 2);
            float_Man -= (1f / enemyZDManConfig.zdManBlood) * playerConfig.TankArmor;
            if (float_Man <= 0.001f)
            {
                playerPath.EnemyAllNum++;
                GameObject ins_deal = Instantiate(Deal_ins, transform.position, Quaternion.identity) as GameObject;
                GetComponent<BoxCollider>().enabled = false;
                transform.FindChild("AK/JQ0.75_Fire").GetComponent<ParticleSystem>().emissionRate = 0;
                Destroy(gameObject);
                float_Man = 0;              
                GameObject Ins_Gold = Instantiate(Gold, transform.position, Quaternion.identity) as GameObject;
                
                
            }
            
        }
        if (col.transform.tag=="GunShell")
        {
            Destroy(col.transform.gameObject);
            GameObject Ins_deal_man = Instantiate(man_Particle, transform.position + new Vector3(0,1,0), Quaternion.identity) as GameObject;
            Destroy(Ins_deal_man, 2);
            float_Man -= (1f / enemyZDManConfig.zdManBlood) * playerConfig.TankGun;
            if (float_Man <= 0.001f)
            {
                playerPath.EnemyAllNum++;
                GameObject ins_deal = Instantiate(Deal_ins, transform.position, Quaternion.identity) as GameObject;
                GetComponent<BoxCollider>().enabled = false;
                transform.FindChild("AK/JQ0.75_Fire").GetComponent<ParticleSystem>().emissionRate = 0;
                Destroy(gameObject);
                float_Man = 0;                            
                GameObject Ins_Gold = Instantiate(Gold, transform.position, Quaternion.identity) as GameObject;                
            }
        }
        if (col.transform.tag=="AirShell")
        {
            playerPath.EnemyAllNum++;
            GameObject ins_deal = Instantiate(Deal_ins, transform.position, Quaternion.identity) as GameObject;
            GameObject Ins_deal_man = Instantiate(man_Particle, transform.position  +new Vector3(0, 1, 0), Quaternion.identity) as GameObject;
            Destroy(Ins_deal_man, 2);
            GetComponent<BoxCollider>().enabled = false;
            transform.FindChild("AK/JQ0.75_Fire").GetComponent<ParticleSystem>().emissionRate = 0;
            Destroy(gameObject);
           
          
           
        }
    }
   
}
