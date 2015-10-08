using UnityEngine;
using System.Collections;

public class BtnPause : MonoBehaviour {
    public UISprite btnSprite;//按钮精灵
    int Btn_num;
	// Use this for initialization
	void Start () {
        Btn_num = 0;
        btnSprite = transform.FindChild("Background").GetComponent<UISprite>();
        
	}
    void OnClick()
    {
        Btn_num++;
        if (Btn_num%2==1)
        {
            print("暂停");
            btnSprite.spriteName = "pause";
            GetComponent<UIButton>().normalSprite = btnSprite.spriteName;
            Time.timeScale = 0;
        }
        else
        {
            btnSprite.spriteName = "play";
            GetComponent<UIButton>().normalSprite = btnSprite.spriteName;
            Time.timeScale = 1;
            print("播放");
            Btn_num = 0;
        }
    }
	
}
