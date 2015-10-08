using ThinksquirrelSoftware.Utilities;
using UnityEngine;
using System.Collections;

public class camshake : MonoBehaviour
{
   // private CameraShake shake;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CameraShake.Shake();
        }
	}
}
