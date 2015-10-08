using UnityEngine;
using System.Collections;
/*
 *坦克发射炮弹的冷却时间
 */
public class BtnFire_danji : MonoBehaviour
{
    public static bool isbtnFire;  
    public GameObject paoguan;//炮管
    public static bool isReadFire;

    private bool StartCold = false;
    public float ColdTime;      //冷却的时间
    public UISprite sprCD;      //技能冷却
   
	// Use this for initialization
	void Start () {
        isbtnFire = true;
        isReadFire = false;

       
        sprCD = transform.FindChild("sprCD").GetComponent<UISprite>();
        sprCD.fillAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {

        AnimatorStateInfo info = paoguan.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        if (info.normalizedTime >= 1.0f)
        {
            paoguan.GetComponent<Animator>().SetBool("isFire", false);
        }

        //技能的冷却
        if (StartCold)
        {
          
            transform.GetComponent<UIButton>().enabled = false;
            sprCD.fillAmount -= (1f / ColdTime) * Time.deltaTime;
            if (sprCD.fillAmount < 0.001f)
            {
               
                transform.GetComponent<UIButton>().enabled = true;
                sprCD.fillAmount = 0;
                StartCold = false;
            }
        }
	}
    
    void OnClick()
    {
        print("Fire");
       
        if (StartCold == false)
        {
            sprCD.fillAmount = 1;
            StartCold = true;
            print("发射子弹");

            AudioManager.Main.PlayNewSound(MusicClass.Fire);
            paoguan.GetComponent<Animator>().SetBool("isFire", true);
            isReadFire = true;
        }
    }
         
}
