using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIShowFps : MonoBehaviour
{

    public static Text UImax;
    public static Text UImin;
    public static Text UImean;
    public static Text UInumbel;

	// Use this for initialization
	void Start ()
	{
	    UImax = transform.Find("Image/max").GetComponent<Text>();
	    UImin = transform.Find("Image/min").GetComponent<Text>();
	    UImean = transform.Find("Image/mean").GetComponent<Text>();
	    UInumbel = transform.Find("Image/numbel").GetComponent<Text>();
      
	}

  

}
