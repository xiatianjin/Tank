using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class fpsWin : MonoBehaviour
{
    public Text UImax;
    public Text UImin;
    public Text UImean;
    public Text UInumbel;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.gameObject != null)
        {
            UImax.text = "最高帧数：" + float.Parse(ShowFPS.max.ToString().Substring(0, ShowFPS.max.ToString().LastIndexOf(".") + 2));
            UImin.text = "最低帧数：" + float.Parse(ShowFPS.min.ToString().Substring(0, ShowFPS.min.ToString().LastIndexOf(".") + 2));
            UImean.text = "平均帧数：" + float.Parse(ShowFPS.mean.ToString().Substring(0, ShowFPS.mean.ToString().LastIndexOf(".") + 2));
            UInumbel.text = "硬件指数：" + float.Parse((ShowFPS.mean * 100).ToString().Substring(0, (ShowFPS.mean * 100).ToString().LastIndexOf(".") + 0));
        }
    }
}
