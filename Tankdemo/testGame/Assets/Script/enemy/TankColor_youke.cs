using UnityEngine;
using System.Collections;
/*
 *坦克被击中的脚本
 */
public class TankColor_youke : MonoBehaviour
{

    public GameObject TankPos;//玩家的位置
    //坦克击中的粒子效果
    public GameObject TankShellParticle;    //坦克导弹的粒子特效
    public GameObject GunShellParticle;     //机枪的粒子特效
    public GameObject Tank_Smoke;       //燃烧

    public GameObject deal;             //死亡的log


    //血条
    public Transform Cube;      //血条所在的位置
    public Transform UI;        //血条的UI（血条 前景+背景）
    public UISprite SprBlood;   //血条
    private float Fomat;
    private Transform Head;

    ////判断是否死亡
   // public static bool isdealTank;

    public GameObject Gold;
    // Use this for initialization
    void Start()
    {
        GetComponent<BoxCollider>().enabled = true;
        SprBlood.fillAmount = 1;
        TankPos = GameObject.Find("First96A");
        Cube = this.transform;
       // SprBlood = transform.Find("UI Root/Camera/UIPanel/UI/Sprite").GetComponent<UISprite>();
        //UI = transform.Find("/UI Root/Camera/UIPanel/UI");
        Head = Cube.Find("head");
        Fomat = Vector3.Distance(Head.position, Camera.main.transform.position);
        print("head=" + Head);
    }

    // Update is called once per frame
    void Update()
    {
        //血条
        //transform.parent.LookAt(TankPos.transform.position);
        UI.transform.rotation = Camera.main.transform.rotation;

        float newFomat = Fomat / Vector3.Distance(Head.position, Camera.main.transform.position);
        UI.position = WorldToUI(Head.position);
        UI.localScale = Vector3.one * newFomat * 0.1f;



    }


    public Vector3 WorldToUI(Vector3 point)
    {
        Vector3 pt = Camera.main.WorldToScreenPoint(point);

        Vector3 ff = UICamera.list[0].GetComponent<Camera>().ScreenToWorldPoint(pt);
        ff.z = 0;
        return ff;

    }
    void OnTriggerEnter(Collider col)
    {
        // print("打印的次数");
        //坦克触碰到shell标签所产生的功能
        if (col.tag == "TankShell")
        {

            print("坦克爆炸音效="+col.tag);
            AudioManager.Main.PlayNewSound(MusicClass.hit_tank);
            GameObject particleexplosion = Instantiate(TankShellParticle, transform.position + new Vector3(0, 4, 0), Quaternion.identity) as GameObject;
            
            Destroy(particleexplosion, 10);
            
            print("击中目标：" + transform.parent.name);
            SprBlood.fillAmount -= (1f / enemyM1Config.M1Blood) * playerConfig.TankHarm;
            if (SprBlood.fillAmount <= 0.001f)
            {
                GameObject particleTank_Smoke = Instantiate(Tank_Smoke, transform.position + new Vector3(0, 4, 0), Quaternion.identity) as GameObject;
                Destroy(particleTank_Smoke, 3);
                GetComponent<BoxCollider>().enabled = false;
                SprBlood.fillAmount = 0;
                playerPath.EnemyAllNum++;
                Destroy(transform.parent.gameObject,3);
                Instantiate(deal);
                print("死亡");
                GameObject Ins_Gold = Instantiate(Gold, transform.position, Quaternion.identity) as GameObject;
                Destroy(transform.FindChild("GameObject/Object001/Sphere1").gameObject);
            }
            Destroy(col.transform.gameObject);
        }

        if (col.tag == "GunShell")
        {
            
            Destroy(col.transform.gameObject);
            AudioManager.Main.PlayNewSound(MusicClass.hit_tank);
            GameObject particleexplosion = Instantiate(GunShellParticle, transform.position + new Vector3(0, 4, 0), Quaternion.identity) as GameObject;
           // GameObject particleTank_Smoke = Instantiate(Tank_Smoke, transform.position + new Vector3(0, 4, 0), Quaternion.identity) as GameObject;
            Destroy(particleexplosion, 10);
           // Destroy(particleTank_Smoke, 10);
            print("击中目标：" + transform.parent.name);
            SprBlood.fillAmount -= (1f / enemyM1Config.M1Blood) * playerConfig.TankGun;
            if (SprBlood.fillAmount <= 0.001f)
            {
                GameObject particleTank_Smoke = Instantiate(Tank_Smoke, transform.position + new Vector3(0, 4, 0), Quaternion.identity) as GameObject;
                Destroy(particleTank_Smoke, 3);
                GetComponent<BoxCollider>().enabled = false;
                SprBlood.fillAmount = 0;
                playerPath.EnemyAllNum++;
                Destroy(transform.parent.gameObject,3);
                Instantiate(deal);
                print("死亡");
                GameObject Ins_Gold = Instantiate(Gold, transform.position, Quaternion.identity) as GameObject;
                Destroy(transform.FindChild("GameObject/Object001/Sphere1").gameObject);
              
            }
            Destroy(col.transform.gameObject);
        }
        //飞机的导弹
        if (col.tag == "AirShell")
        {
            GetComponent<BoxCollider>().enabled = false;
            print("坦克爆炸音效");
            AudioManager.Main.PlayNewSound(MusicClass.hit_tank);
            GameObject particleexplosion = Instantiate(TankShellParticle, transform.position + new Vector3(0, 4, 0), Quaternion.identity) as GameObject;
            GameObject particleTank_Smoke = Instantiate(Tank_Smoke, transform.position + new Vector3(0, 4, 0), Quaternion.identity) as GameObject;
            Destroy(particleexplosion, 10);
            Destroy(particleTank_Smoke, 10);
            print("击中目标：" + transform.parent.name);

            playerPath.EnemyAllNum++;
            Destroy(transform.parent.gameObject);
            Instantiate(deal);
          

        }
    }

}
