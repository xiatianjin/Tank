using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*
 此脚本用来判断装弹箱显示 打完一炮后 要冷却这么多（t_shell）时间
 * 已经导弹的的质量 和初速度（这版本没有） 
 */
public class readfire_danji : MonoBehaviour
{
    public GameObject fireLoad;//是否可以开火
    public GameObject fireRead;//可以开火的按钮（有子弹）

   
    private Text timetext;
    public static float t_shell;//出现装弹的时间（冷却时间）

    //public static float shell_power;//子弹的初速度（根据子弹的不同有不同的效果）
    //public static float shell_Mass; //子弹的重力（不同子弹所受的重力（质量不同）
    //public static float shell_time;//子弹的冷却时间（）

    public GameObject ButShell;
    // Use this for initialization
    void Start()
    {
     
        timetext = GameObject.Find("TimeText").GetComponent<Text>();
        t_shell = 1;
        timetext.transform.gameObject.SetActive(false);
        transform.GetComponent<UISprite>().spriteName = "AP_ass";
    }

    // Update is called once per frame
    void Update()
    {
        print("btn="+BtnFire_danji.isbtnFire);
        if (BtnFire_danji.isbtnFire==false)
        {
           
            if (timetext != null)
            {
                transform.GetComponent<UISprite>().spriteName = "noshell";   
              //  print("计时器");
                fireLoad.SetActive(true);
                fireRead.SetActive(false);
                t_shell -= Time.deltaTime;
                timetext.transform.gameObject.SetActive(true);
                timetext.text =  double.Parse((t_shell).ToString().Substring(0, (t_shell).ToString().LastIndexOf(".") + 3)) + " s";
            }
            if (t_shell <= 0)
            {
             //   print("装子弹");
                transform.GetComponent<UISprite>().spriteName = "AP_ass";                       
                fireLoad.SetActive(false);
                fireRead.SetActive(true);
                BtnFire_danji.isbtnFire = true;
                timetext.transform.gameObject.SetActive(false);
                t_shell =1;
            }

        }
            
    }

  
}
