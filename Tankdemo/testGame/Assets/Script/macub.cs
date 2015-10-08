using UnityEngine;
using System.Collections;

public class macub : MonoBehaviour
{
    float t_time;
    bool isAdd;
    // Use this for initialization
    void Start()
    {
        t_time = 0;
        isAdd = false;
        //GetComponent<Renderer>().material.SetTextureOffset("ZTZ96A_Crawler_01_L",Vector2(0,10));
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0,50);
        if (Time.frameCount % 20 == 0)
        {
            if (GetComponent<Renderer>().material.mainTextureOffset.y <= 11 && isAdd == false)
            {
                t_time += 0.3f;
                GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, t_time);
                if (GetComponent<Renderer>().material.mainTextureOffset.y > 9)
                {
                    isAdd = true;
                }

            }
            if (GetComponent<Renderer>().material.mainTextureOffset.y >= 0f && isAdd)
            {
                t_time -= 0.3f;
                GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, t_time);
                if (GetComponent<Renderer>().material.mainTextureOffset.y < 0)
                {
                    isAdd = false;
                }

            }
        }


    }
}
