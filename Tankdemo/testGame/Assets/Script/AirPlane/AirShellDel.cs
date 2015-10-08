using UnityEngine;
using System.Collections;

public class AirShellDel : MonoBehaviour
{
    public GameObject lizi;//地面爆炸特效

    void OnTriggerEnter(Collider col)
    {
        //print("airplane=" + col.transform.name);
        if (col.transform.tag != "player")
        {           
            //  Destroy(gameObject);
            AudioManager.Main.PlayNewSound(MusicClass.hit_tank);
            GameObject ss = Instantiate(lizi, transform.position, Quaternion.identity) as GameObject;
            ss.transform.eulerAngles = new Vector3(-90, 0, 0);
            Destroy(ss, 2);
            //  Destroy(gameObject);
        }
    }
}