using UnityEngine;
using System.Collections;
/*
 *恢复护甲
 */
public class BtnArmor : MonoBehaviour {
    private bool StartCold = false;
    public float ColdTime;      //冷却的时间
    public UISprite sprCD;      //技能冷却
	// Use this for initialization
	void Start () {
        sprCD = transform.FindChild("sprCD").GetComponent<UISprite>();
        sprCD.fillAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {
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
        print("护甲恢复");

        if (StartCold == false)
        {
            sprCD.fillAmount = 1;
            StartCold = true;
            playerBlood.playerArmor.fillAmount += 0.5f;
        }
    }

}
