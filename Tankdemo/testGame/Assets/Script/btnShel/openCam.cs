using ThinksquirrelSoftware.Utilities;//开炮的时候镜头抖动
using UnityEngine;
using System.Collections;

public class openCam : MonoBehaviour
{
 
    int i_touch;
   
    public GameObject fangda;//放大的
    //Main Camera
    public Camera cam; 
    //炮台
    public GameObject type69_t_01;
    //炮管
    public GameObject paoguan;
    //相机的背景图片
    public GameObject CamBG;
    //是否改变相机的背景图片
    bool isChgCamBG;
    // Use this for initialization
    void Start()
    {
      

        isChgCamBG = false;
        i_touch = 0;
        if ( fangda != null)
        {
           
          
            fangda.SetActive(false);
        }
    }



    /// <summary>
    /// 镜头的旋转速度
    /// </summary>
    void FixedUpdate()
    {
        //开近的时候 镜头旋转慢
        if(isChgCamBG)
        {
            CamBG.GetComponent<UISprite>().spriteName = "ZOOM_IN";

            type69_t_01.GetComponent<mouseRX>().sensitivityX = 0.1f;
            paoguan.GetComponent<mouseRY>().sensitivityY = 0.05f;
            cam.GetComponent<mouseRY>().sensitivityY = 0.05f;
        }
        else
        {
            CamBG.GetComponent<UISprite>().spriteName = "ZOOM_OUT";
            type69_t_01.GetComponent<mouseRX>().sensitivityX =0.5f;
            paoguan.GetComponent<mouseRY>().sensitivityY = 0.25f;
            cam.GetComponent<mouseRY>().sensitivityY = 0.25f;
        }
    }
    void OnClick()
    {
        i_touch++;
        if (i_touch % 2 == 0)
        {
            isChgCamBG = false;
          
            Cam_ThreeView();
            print("1");
        }
        else if (i_touch%2==1)
        {
            isChgCamBG = true;
            print("2");
            Cam_firstView();
        } 
       
      
    }

    //开炮后镜头缩回来
    public void Cam_fieldOfView60()
    {
        print("//开炮后镜头缩回来");
        isChgCamBG = false;
        cam.fieldOfView = 60;

     
        fangda.SetActive(false);
        i_touch = 0;
    }

    //坦克第一人称视角
    public void Cam_firstView()
    {

       
        fangda.SetActive(true);
        cam.fieldOfView = 30;
        cam.transform.localPosition = new Vector3(0,2.96f,0.24f);
        cam.transform.localEulerAngles = new Vector3(cam.transform.localEulerAngles.x, 0, 0);
    }

    //坦克第三人称视角
    public void Cam_ThreeView()
    {

       
        fangda.SetActive(false);
        cam.fieldOfView = 30;
        cam.transform.localPosition = new Vector3(0, 4.0f, -6);
        cam.transform.localEulerAngles = new Vector3(1*cam.transform.localEulerAngles.x, 0, 0);

    }
    
    //第一人称后拉近视角
    public void Cam_first_filedOfView()
    {

       
        fangda.SetActive(true);
        cam.transform.localPosition = new Vector3(0, 2.96f, 0.24f);
        cam.transform.localEulerAngles = new Vector3(cam.transform.localEulerAngles.x, 0, 0);
        cam.fieldOfView = 12;
    }
   

}
