using ThinksquirrelSoftware.Utilities;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*
 *坦克的开炮 以及控制不同平台的脚本
 */
public class test_danji : MonoBehaviour
{

    //不同的平台
    public enum CLIENT
    {
        ANDROID = 1,
        WINDOWS,
    }
#if UNITY_STANDALONE_WIN || UNITY_EDITOR
    public static CLIENT pingtai = CLIENT.WINDOWS;//需要什么样子的平台

#elif UNITY_ANDROID
            public static CLIENT pingtai = CLIENT.ANDROID;//需要什么样子的平台
           
#endif



    public Rigidbody shell; //子弹
    Rigidbody obj;
    public Camera cam;      //相机
    public static float power;//子弹初速度



    public GameObject particle_fire;//粒子效果//炮管的Fire



    public GameObject cube2;//小目标(用来控制导弹方向)

    int distance;//测量坦克与目标的之间的距离

    //public static int Dis_Score;//坦克与敌人之间的距离
    public GameObject CubeTank;
    // Use this for initialization
    void Start()
    {
        power = 300;
        if (CubeTank != null)
        {
            CubeTank = transform.Find("/GameObject/Cubetank").gameObject;
        }

        particle_fire.SetActive(false);

        //Screen.showCursor = false;   //隐藏鼠标

    }

    // Update is called once per frame
    void Update()
    {

        if (playerBlood.isDealFire == false)
        {

            if (pingtai == CLIENT.WINDOWS)
            //向前发射的力（发射炮弹）
            {
                if (Input.GetButtonUp("Fire1") && BtnFire_danji.isReadFire)
                {
                    //开炮后镜头缩回
                    // GameObject.Find("ButtonCam").GetComponent<openCam>().Cam_fieldOfView60();

                    //  CameraShake.Shake();

                    particle_fire.SetActive(true);


                    particle_fire.GetComponent<ParticleSystem>().Play();


                    Quaternion cube2Rotate = Quaternion.LookRotation(transform.position - cube2.transform.position, Vector3.up);
                    //  GameObject lizi = Instantiate(particle, transform.position, Quaternion.identity) as GameObject;
                    //  lizi.transform.localEulerAngles
                    //lizi.rigidbody.velocity = (ray).direction*2;
                    obj = Instantiate(shell, transform.position, Quaternion.identity) as Rigidbody;

                    obj.GetComponent<Rigidbody>().velocity = ((transform.position - cube2.transform.position)).normalized * (-power);
                    // obj.GetComponent<Rigidbody>().AddForce(((transform.position - cube2.transform.position)).normalized * 50 * (-power /*+ WindForce.AirForce*/)/* + WindForce.VecVelocity.normalized * WindForce.WindSpeed * 20f*/);
                    obj.transform.rotation = cube2Rotate;

                    BtnFire_danji.isReadFire = false;
                    BtnFire_danji.isbtnFire = false;
                    Debug.Log("发射炮弹");
                }
            }
            else if (pingtai == CLIENT.ANDROID)
            {
                // if (Input.touchCount == 1)
                {
                    //向前发射的力（发射炮弹）
                    // for (int i = 0; i < Input.touchCount; i++)
                    {


                        if (/*Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended &&*/ BtnFire_danji.isReadFire)
                        {

                            //  CameraShake.Shake();

                            particle_fire.SetActive(true);

                            particle_fire.GetComponent<ParticleSystem>().Play();


                            Quaternion cube2Rotate = Quaternion.LookRotation(transform.position - cube2.transform.position, Vector3.up);

                            obj = Instantiate(shell, transform.position, Quaternion.identity) as Rigidbody;

                            obj.GetComponent<Rigidbody>().velocity = ((transform.position - cube2.transform.position)).normalized * (-power);

                            obj.transform.rotation = cube2Rotate;

                            BtnFire_danji.isReadFire = false;
                            BtnFire_danji.isbtnFire = false;
                            Debug.Log("发射炮弹");
                        }
                    }
                }
            }
        }


    }




}
