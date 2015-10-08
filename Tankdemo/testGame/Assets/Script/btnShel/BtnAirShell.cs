using UnityEngine;
using System.Collections;

public class BtnAirShell : MonoBehaviour {
    private bool StartCold = false;
    public float ColdTime;      //冷却的时间
    public UISprite sprCD;      //技能冷却
 
    public GameObject airplane; //飞机

    GameObject Tank;//玩家的坦克(用来获取坦克的位置)

   
	// Use this for initialization
	void Start () {
        Tank = GameObject.Find("First96A").gameObject;

     
        sprCD = transform.FindChild("sprCD").GetComponent<UISprite>();
        sprCD.fillAmount = 0;
	}

    // Update is called once per frame
    void Update()
    {
       
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
            GameObject air = Instantiate(airplane) as GameObject;
            
            sprCD.fillAmount = 1;
            StartCold = true;
            print("发射子弹");
           

        }
    }

}

