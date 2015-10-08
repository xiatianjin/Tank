using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*
 *玩家的血量控制脚本
 *敌人发射的炮弹是玩家血量减少
 */
public class playerBlood : MonoBehaviour
{

    public GameObject PickHitParticle;      //皮卡击中坦克的粒子
    public GameObject M1HitParticle;        //M1击中坦克的粒子效果
   // public GameObject NoHitParticle;    //跳弹的特效
    public GameObject TDeal;            //坦克死亡特效
    public static UISprite spriteBlood;        //玩家的血量精灵
    public static bool isDealFire;      //控制死亡后不能开炮

    //坦克的护甲
    public static UISprite playerArmor;        //定义玩家的护甲
    float time_Armor = 2;               //定义护甲回复的时间

    public float ArmorNum = 1;          //护甲的恢复指数

    void Awake()
    {
        GameObject.Find("bgFailorSucceed").GetComponent<Image>().enabled = false;
        playerArmor = GameObject.Find("UIfire/PanelBlood/Armor/Foreground").GetComponent<UISprite>();
        spriteBlood = GameObject.Find("UIfire/PanelBlood/Blood/SpriteBlood").GetComponent<UISprite>();
        print("护甲=" + playerArmor.fillAmount);
    }
    void Start()
    {
        isDealFire = false;   
        //多久开始恢复护甲
        InvokeRepeating("ArmorRepair", 1, 1);//每秒调用一次

    }
    void FixedUpdate()
    {
        if (spriteBlood.fillAmount <= 0.001f)
        {
            spriteBlood.gameObject.SetActive(false);
            print("死亡");
           // GameObject tankdeal = Instantiate(TDeal, transform.position, Quaternion.identity) as GameObject;

            itweenTest.IsEnemyFire = false;//玩家死亡后不开炮
            GameObject.Find("bgFailorSucceed").GetComponent<Image>().enabled = true;
            GameObject.Find("FailorSucceed").GetComponent<Text>().text = "失败\n\n点击屏幕重新开始游戏";
            isDealFire = true;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        print("player+col.transform.tag=" + col.transform.tag);
        if (col.transform.tag == "pickshell")
        {
            AudioManager.Main.PlayNewSound(MusicClass.hit_ground);
            GameObject ss = Instantiate(PickHitParticle, transform.position, Quaternion.identity) as GameObject;
            ss.transform.eulerAngles = new Vector3(-90, 0, 0);
            Destroy(ss, 5);
            //血量
            if (playerArmor.fillAmount <= 0)
            {
                playerArmor.fillAmount = 0;
                spriteBlood.fillAmount -= (1f / playerConfig.TankBlood) * enemyPickConfig.PickHarm;
                if (spriteBlood.fillAmount <= 0.001f)
                {
                    spriteBlood.gameObject.SetActive(false);
                    print("死亡");
                    GameObject tankdeal = Instantiate(TDeal, transform.position, Quaternion.identity) as GameObject;
                    Destroy(tankdeal,3);
                    itweenTest.IsEnemyFire = false;//玩家死亡后不开炮
                    GameObject.Find("bgFailorSucceed").GetComponent<Image>().enabled = true;
                    GameObject.Find("FailorSucceed").GetComponent<Text>().text = "失败\n\n点击屏幕重新开始游戏";
                    isDealFire = true;
                }

            }

            //护甲
            else if (playerArmor.fillAmount > 0)
            {
                playerArmor.fillAmount -= (1f / playerConfig.TankArmor) * enemyConfig.enemyHarm;
            }

        }
        if (col.transform.tag == "M1Shell")
        {
            AudioManager.Main.PlayNewSound(MusicClass.hit_ground);
            GameObject ss = Instantiate(M1HitParticle, transform.position, Quaternion.identity) as GameObject;
            ss.transform.eulerAngles = new Vector3(-90, 0, 0);
            Destroy(ss, 5);
            //血量
            if (playerArmor.fillAmount <= 0)
            {
                playerArmor.fillAmount = 0;
                spriteBlood.fillAmount -= (1f / playerConfig.TankBlood) * enemyM1Config.M1Harm;
                if (spriteBlood.fillAmount <= 0.001f)
                {
                    spriteBlood.gameObject.SetActive(false);
                    print("死亡");
                    GameObject tankdeal = Instantiate(TDeal, transform.position, Quaternion.identity) as GameObject;
                    Destroy(tankdeal, 3);
                    itweenTest.IsEnemyFire = false;//玩家死亡后不开炮
                    GameObject.Find("bgFailorSucceed").GetComponent<Image>().enabled = true;
                    GameObject.Find("FailorSucceed").GetComponent<Text>().text = "失败\n\n点击屏幕重新开始游戏";
                    isDealFire = true;
                }

            }

            //护甲
            else if (playerArmor.fillAmount > 0)
            {
                playerArmor.fillAmount -= (1f / playerConfig.TankArmor) * enemyM1Config.M1Harm;
            }

        }
        else if (col.transform.tag=="AirShell")
        {
            print("轰炸机");
        }
        else
        {
            print("跳弹");
           // GameObject insNoHit = Instantiate(NoHitParticle, col.transform.position, Quaternion.identity) as GameObject;
           // insNoHit.transform.eulerAngles = new Vector3(-90, 0, 0);
           // Destroy(insNoHit, 2);
        }

    }

    //护甲自动修复
    void ArmorRepair()
    {

        if (playerArmor.fillAmount > 0 && playerArmor.fillAmount <= 1)
        {
            playerArmor.fillAmount += (1f / playerConfig.TankArmor) * ArmorNum;
        }
        else
        {
            playerArmor.fillAmount = 0;
        }

    }

}
