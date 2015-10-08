using UnityEngine;
using System.Collections;

public class testCamRotate : MonoBehaviour {
    public GameObject CameObj;

    int i_touch;
	// Use this for initialization
	void Start () {
        i_touch = 0;
        playerPath.isTankRotate = true;
	}

    void OnClick()
    {
        i_touch++;
        if (i_touch % 2 == 0)
        {

            CameObj.transform.localPosition = new Vector3(0, 3.5f, -4f);
            CameObj.transform.localEulerAngles = new Vector3( 5, 0, 0);
           
        }
        else if (i_touch % 2 == 1)
        {
            CameObj.transform.localPosition = new Vector3(0, 4, -13);
            CameObj.transform.localEulerAngles = new Vector3(3.5f + 5, 0, 0);
        }


    }
}
