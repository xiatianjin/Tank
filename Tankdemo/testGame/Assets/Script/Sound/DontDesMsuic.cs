using UnityEngine;
using System.Collections;

public class DontDesMsuic : MonoBehaviour {
    public GameObject dontDel;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(dontDel);
        DontDestroyOnLoad(GameObject.Find("ShowFPS"));
	}
	

}
