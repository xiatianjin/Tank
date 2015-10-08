using UnityEngine;
using System.Collections;

public class Gold : MonoBehaviour {
    Vector3 playVec;
    
    // Use this for initialization
    void Start()
    {
        playVec = GameObject.Find("First96A").transform.position;


        iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(transform.position.x, transform.position.y + 9, transform.position.z), "time", 1, "oncomplete", "StopMove"));

    }


    void StopMove()
    {
        print("上升");
        iTween.MoveTo(this.gameObject, iTween.Hash("position", playVec, "time", 3, "oncomplete", "StopMove3"));
    }
    void StopMove3()
    {
        print("捡到金币");
        Destroy(gameObject);
    }
}
