using UnityEngine;
using System.Collections;

public class ShowFPS : MonoBehaviour
{



    public Rect startRect = new Rect(10, 10, 75, 50); // The rect the window is initially displayed at.
    public bool updateColor = true; // Do you want the color to change if the FPS gets low
    public bool allowDrag = true; // Do you want to allow the dragging of the FPS window
    public float frequency = 0.5F; // The update frequency of the fps
    public int nbDecimal = 1; // How many decimal do you want to display

    private float accum = 0f; // FPS accumulated over the interval
    private int frames = 0; // Frames drawn over the interval
    private Color color = Color.white; // The color of the GUI, depending of the FPS ( R < 10, Y < 30, G >= 30 )
    private string sFPS = ""; // The fps formatted into a string.
    private GUIStyle style; // The style the text will be displayed at, based en defaultSkin.label.

    public static float fps; //帧率
    public static float max;//最大帧率
    public static float min;//最小帧率
    public static float mean;//平均帧率
    public static bool IsShowFps;

    void Start()
    {
        IsShowFps = false;
        PlayerPrefs.SetFloat("max", 0);
        PlayerPrefs.SetFloat("min", 100);
        StartCoroutine(FPS());
    }

    void Update()
    {
        accum += Time.timeScale / Time.deltaTime;
        ++frames;

        if (Input.GetKeyDown(KeyCode.A) || IsShowFps)
        {
            if (UIShowFps.UImax != null)
            {
                UIShowFps.UImax.text = "最高帧数：" + float.Parse(max.ToString().Substring(0, max.ToString().LastIndexOf(".") + 2));
                UIShowFps.UImin.text = "最低帧数：" + float.Parse(min.ToString().Substring(0, min.ToString().LastIndexOf(".") + 2));
                UIShowFps.UImean.text = "平均帧数：" + float.Parse(mean.ToString().Substring(0, mean.ToString().LastIndexOf(".") + 2));
                UIShowFps.UInumbel.text = "硬件指数：" + float.Parse((mean * 100).ToString().Substring(0, (mean * 100).ToString().LastIndexOf(".") + 0));
                Debug.Log("打印FPS");
            }
            Debug.Log("max=" + max + "   min=" + min + "   mean=" + mean);
            IsShowFps = false;
        }
    }

    IEnumerator FPS()
    {
        // Infinite loop executed every "frenquency" secondes.
        while (true)
        {
            // Update the FPS
            float fps = accum / frames;
            sFPS = fps.ToString("f" + Mathf.Clamp(nbDecimal, 0, 10));

            //Update the color
            color = (fps >= 30) ? Color.green : ((fps > 10) ? Color.red : Color.yellow);

            accum = 0.0F;
            frames = 0;

            if (fps > PlayerPrefs.GetFloat("max"))
            {
                PlayerPrefs.SetFloat("max", fps);

            }
            if (fps < PlayerPrefs.GetFloat("min"))
            {
                PlayerPrefs.SetFloat("min", fps);
            }

            int i;
            float sum = 0;
            float[] ff = new float[20];

            for (i = 0; i < ff.Length; i++)
            {
                ff[i] = fps;
                sum += ff[i];
            }
            max = PlayerPrefs.GetFloat("max");
            min = PlayerPrefs.GetFloat("min");
            mean = sum / 20;
            PlayerPrefs.SetFloat("mean_num", mean);
           

            yield return new WaitForSeconds(frequency);
        }
    }

    void OnGUI()
    {
        // Copy the default label skin, change the color and the alignement
        if (style == null)
        {
            style = new GUIStyle(GUI.skin.label);
            style.normal.textColor = Color.white;
            style.alignment = TextAnchor.MiddleCenter;
        }

        GUI.color = updateColor ? color : Color.white;
        startRect = GUI.Window(0, startRect, DoMyWindow, "");
    }

    void DoMyWindow(int windowID)
    {
        GUI.Label(new Rect(0, 0, startRect.width, startRect.height), sFPS + " FPS", style);
        if (allowDrag)
            GUI.DragWindow(new Rect(0, 0, Screen.width, Screen.height));
    }
}


//    float deltaTime = 0.0f;

//    void Update()
//    {
//        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
//    }

//    void OnGUI()
//    {
//        int w = Screen.width, h = Screen.height;

//        GUIStyle style = new GUIStyle();

//        Rect rect = new Rect(0, 0, w, h * 2 / 100);
//        style.alignment = TextAnchor.UpperLeft;
//        style.fontSize = h * 2 / 100;
//        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
//        float msec = deltaTime * 1000.0f;
//        float fps = 1.0f / deltaTime;
//        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
//        GUI.Label(rect, text, style);
//    }

//}






//    public float updateInterval = 0.5F;
//    private float lastInterval;
//    private float frames = 0;
//    private float fps;
//    void Start() {
//        lastInterval = Time.realtimeSinceStartup;
//        frames = 0;
//    }
//    void OnGUI() {
//        GUILayout.Label("" + (fps).ToString("f2"));
//    }
//    void Update() {
//        ++frames;
//        float timeNow = Time.realtimeSinceStartup;
//        if (timeNow > lastInterval + updateInterval) {
//            fps = frames / (timeNow - lastInterval);
//            frames = 0;
//            lastInterval = timeNow;
//        }
//    }
//}




//    public float f_UpdateInterval = 0.5F;

//    private float f_LastInterval;

//    private int i_Frames = 0;

//    private float f_Fps;

//    void Start() 
//    {
//        //Application.targetFrameRate=60;

//        f_LastInterval = Time.realtimeSinceStartup;

//        i_Frames = 0;
//    }

//    void OnGUI() 
//    {
//        GUI.Label(new Rect(0, 100, 200, 200), "FPS:" + f_Fps.ToString("f2"));
//    }

//    void Update() 
//    {
//        ++i_Frames;

//        if (Time.realtimeSinceStartup > f_LastInterval + f_UpdateInterval) 
//        {
//            f_Fps = i_Frames / (Time.realtimeSinceStartup - f_LastInterval);

//            i_Frames = 0;

//            f_LastInterval = Time.realtimeSinceStartup;
//        }
//    }
//}
