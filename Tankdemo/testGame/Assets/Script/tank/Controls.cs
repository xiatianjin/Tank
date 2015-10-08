using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour
{
   //public Texture2D round;
    float x = 0;
    float y = 0;

    float cross_x = 0;
    float cross_y = 0;

    int num;
    float xdown;
    float ydown;
    float CamY;//y轴的旋转角度
    float CamX;//x轴的旋转角度
    void Start()
    {
        CamY =0;
        CamX = 0;
        num = 0;
        x = (Screen.width - 256) / 2;
        y = (Screen.height - 256) / 2;
        xdown = x;
        cross_x = Screen.width - 256;
        cross_y = Screen.height - 256;
    }

  //  void OnGUI()
   // {

     // GUI.Label(new Rect(0, 0, 480, 100), "position is " + Input.acceleration);

    //    GUI.DrawTexture(new Rect(x, cross_y, 256, 256), round,ScaleMode.ScaleToFit,true);
    //    switch (num)
    //    {
    //        case 1:
    //            GUI.Label(new Rect(0, 200, 480, 100), "1111111");
    //            break;
    //        case 2:
    //            GUI.Label(new Rect(0, 200, 480, 100), "22222");
    //            break;
    //        case 3:
    //            GUI.Label(new Rect(0, 200, 480, 100), "333333");
    //            break;
    //        case 4:
    //            GUI.Label(new Rect(0, 200, 480, 100), "444444");
    //            break;

    //        case 5:
    //            GUI.Label(new Rect(200, 200, 480, 100), "55555555");
    //            CamY += 6f * Time.deltaTime;
               
    //            CamY = Mathf.Clamp(CamY, -20, 20);
    //            if (CamY < 10 && CamY > -10)
    //            {
    //                transform.localEulerAngles = new Vector3(0, 0, 0);
    //            }
    //            else
    //            {
    //                transform.localEulerAngles = new Vector3(0, CamY-10, 0);
    //            }
                
               
    //            break;
    //        case 6:
    //            GUI.Label(new Rect(200, 200, 480, 100), "666666");
    //            CamY -= 6f * Time.deltaTime;
    //            CamY = Mathf.Clamp(CamY, -20, 20);
    //            if (CamY < 10 && CamY > -10)
    //            {
    //                transform.localEulerAngles = new Vector3(0, 0, 0);
    //            }
    //            else
    //            {
    //                transform.localEulerAngles = new Vector3(0, CamY +10, 0);
    //            }
                            
    //            break;
    //    }
      //  GUI.Label(new Rect(300, 60, 200, 60), "x=" + (x / Screen.width).ToString());
      //  GUI.Label(new Rect(300, 0, 200, 100), "CamY=" + CamY.ToString());
      //  GUI.Label(new Rect(300, 120, 200, 60), "y=" + (y/Screen.height).ToString());
      //  GUI.Label(new Rect(300, 200, 200, 100), " transform.localEulerAngles=" + transform.localEulerAngles.ToString());
   // }

    void Update()
    {
        x += Input.acceleration.x * 80;
        y += -Input.acceleration.y * 80;
        #region
        //if (xdown > x)
        //{
        //    num = 5;
        //    xdown = x;
           
        //}
        //if (xdown < x)
        //{
        //    num = 6;
        //    xdown = x;
            
        //}
        //if (xdown == x)
        //{

        //}
        #endregion

        //重力感应 旋转
        #region
        //沿着y轴旋转
        if ((x/Screen.width)<0.43f)
        {
          CamY = Mathf.Clamp(CamY, -20, 20);
          CamY=(0.43f-(x/Screen.width))*(-10);
          transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, CamY, 0);           
        }
        else if ((x / Screen.width) >= 0.43f)
        {
            CamY = Mathf.Clamp(CamY, -20, 20);
            CamY = ( (x / Screen.width)-0.43f) * (10);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, CamY, 0);
        }
        else
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, 0);
        }
        //沿着X轴旋转
        if ((y/Screen.height) < 0.76f)
        {
            CamX = Mathf.Clamp(CamX, -10, 10);
            CamX = (0.76f - (y / Screen.height)) * (-5);
            transform.localEulerAngles = new Vector3(CamX, transform.localEulerAngles.y, 0);
        }       
        else
        {
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
        }
        #endregion

        //在屏幕内运动
        #region 
        if (x < 0)
        {
            x = 0;
          
        }
        else if (x > cross_x)
        {
            x = cross_x;
           
        }

        if (y < 0)
        {
            y = 0;
            
        }
        else if (y > cross_y)
        {
            y = cross_y;

        }
        #endregion
    }
}