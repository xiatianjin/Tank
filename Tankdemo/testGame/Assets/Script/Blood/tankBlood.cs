using UnityEngine;
using System.Collections;

public class tankBlood : MonoBehaviour {

    public Transform Cube;
    public Transform UI;
    public  UISprite SprBlood;


    private float Fomat;
    private Transform Head;

 

    void Start()
    {
       
        Cube = this.transform;
        SprBlood = transform.Find("UI Root/Camera/UIPanel/UI/Sprite").GetComponent<UISprite>();
        UI = transform.Find("UI Root/Camera/UIPanel/UI");
        Head = Cube.Find("Cubetank/head");
        Fomat = Vector3.Distance(Head.position, Camera.main.transform.position);
        print(Head);
    }

    void Update()
    {
       transform.LookAt(new Vector3(0,0,-109));
       UI.transform.rotation = Camera.main.transform.rotation;
       // RayHit();
        float newFomat = Fomat / Vector3.Distance(Head.position, Camera.main.transform.position);
        UI.position = WorldToUI(Head.position);
        UI.localScale = Vector3.one * newFomat*0.2f;
       

      
    }


    public  Vector3 WorldToUI(Vector3 point)
    {
        Vector3 pt = Camera.main.WorldToScreenPoint(point);
        
        Vector3 ff = UICamera.list[0].GetComponent<Camera>().ScreenToWorldPoint(pt);
        ff.z = 0;
        return ff;
       
    }

    
    
    //void RayHit()
    //{

    //    //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    //RaycastHit hit;
    //    //if (Input.GetMouseButtonDown(0))
    //    //{
    //    //    if (Physics.Raycast(ray, out hit))
    //    //    {
    //    //        print("hit.name=" + hit.transform.name);
    //    //        hitNum++;
    //    //        if (hitNum > 5)
    //    //        {
    //    //            print("死亡");
    //    //            Destroy(hit.transform.gameObject);
    //    //        }
                
    //    //    }
    //    //}

    //}
}
