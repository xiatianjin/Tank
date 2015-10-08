using UnityEngine;
using System.Collections;

public class Cam_Main_PG : MonoBehaviour {

    public GameObject cam;
	// Update is called once per frame
	void Update () {
        transform.localRotation = cam.transform.localRotation;
	}
}
