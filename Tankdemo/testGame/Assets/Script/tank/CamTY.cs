using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CamTY : MonoBehaviour
{
    public Camera cam;
    int iclick;
    public Text TLtxt;
    public GameObject handShankBtn;
    // Use this for initialization
    void Start()
    {
        //handShankBtn.SetActive(false);
        iclick = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.T))
        {
            cam.fieldOfView -= 0.2f;
            if (cam.fieldOfView <= 1)
            {
                cam.fieldOfView = 1;
            }
        }
        if (Input.GetKey(KeyCode.Y))
        {

            cam.fieldOfView += 0.2f;
            if (cam.fieldOfView >= 60)
            {
                cam.fieldOfView = 60;
            }
        }
    }
    public void Tcam()
    {
        //cam.fieldOfView -= 0.2f;
        //if (cam.fieldOfView <= 1)
        //{
        TLtxt.text = "推";
        cam.fieldOfView = 15;
        // }
    }
    public void Lcam()
    {
        //cam.fieldOfView += 0.2f;
        //if (cam.fieldOfView >= 60)
        //{
        TLtxt.text = "拉";
        cam.fieldOfView = 60;
        //}
    }
    public void TLcam()
    {
        iclick++;
        if (iclick % 2 == 0)       //拉  
        {
            // handShankBtn.SetActive(false);
            // transform.Find("/First Person Controller/tank/type69_T_01").GetComponent<mouseRX>().enabled = true;
            // transform.Find("/First Person Controller/tank/type69_T_01/paoguan").GetComponent<mouseRY>().enabled=true;
            //  transform.Find("/First Person Controller/tank/type69_T_01/Main Camera").GetComponent<mouseRY>().enabled = true;
            TLtxt.text = "推";
            cam.fieldOfView = 60;
        }
        else if (iclick % 2 == 1)   //推
        {
            // transform.Find("/First Person Controller/tank/type69_T_01").GetComponent<mouseRX>().enabled = false;
            //  transform.Find("/First Person Controller/tank/type69_T_01/paoguan").GetComponent<mouseRY>().enabled = false;
            //  transform.Find("/First Person Controller/tank/type69_T_01/Main Camera").GetComponent<mouseRY>().enabled = false;
            //   handShankBtn.SetActive(true);  
            TLtxt.text = "拉";
            cam.fieldOfView = 15;
        }
    }
}
