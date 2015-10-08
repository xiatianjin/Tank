using UnityEngine;
using System.Collections;
/*
 *用射线来判断敌人的血条是否显示
 */
public class CubeSph : MonoBehaviour
{
    public GameObject sph;
    public static Vector3 HitVec;   //射线点击的位置
    public Camera cam;
    public static string nan;
    void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (cam != null)
        {

            // print("sph=" + sph);
            Vector3 vos = new Vector3(Screen.width / 2, (Screen.height / 2), 0);
            Ray ray = cam.ScreenPointToRay(vos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                nan = hit.transform.tag;
                // print("射线点击的位置：" + hit.point);
                //print("hit.name.Camera=" + hit.transform.tag + "   9=" + hit.transform);
                HitVec = hit.point;
                if (hit.transform.tag == "CubeDown")
                {
                    sph = hit.transform.parent.FindChild("UI Root").gameObject;
                    sph.SetActive(true);
                }
                else
                {
                    //print("没有");
                    if (sph != null)
                    {
                        //sph = hit.transform.parent.FindChild("UI Root").gameObject;
                        sph.SetActive(false);
                    }
                }
            }
            else
            {
                print("没有");
                if (sph != null)
                {
                    // sph = hit.transform.parent.FindChild("UI Root").gameObject;
                    sph.SetActive(false);
                }
            }

        }
    }


}
