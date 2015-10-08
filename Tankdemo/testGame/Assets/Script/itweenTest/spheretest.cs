using UnityEngine;
using System.Collections;

public class spheretest : MonoBehaviour
{

    public GameObject EnemyTank;
    public iTweenPath itw_path;

    //Hashtable args = new Hashtable();
    // Use this for initialization
    void Start()
    {




        // sp = this.gameObject;

        //for (int i = 0; i < itw_path.Length;i++ )
        {
            // Instantiate(itw_path);
            // print("ss=" + itw_path[i].pathName + "   " + itw_path[i].name);
        }



        // print("path="+iTweenPath.GetPath("pathT").GetValue(0));
        print("ss=" + itw_path.pathName + "   " + itw_path.name);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            #region
            // sp.transform.position = (Vector3)iTweenPath.GetPath("pathT").GetValue(0);
            //   GameObject insta = Instantiate(sp) as GameObject;
            // insta.transform.position = (Vector3)iTweenPath.GetPath("pathitween").GetValue(0);
            // iTween.MoveTo(insta, iTween.Hash("path", iTweenPath.GetPath("pathitween"), "time", 3f,
            //"orienttopath", true, "looktime", 1f, "easetype", iTween.EaseType.easeInOutCubic,"looptype",iTween.LoopType.none));

            //    Obj_itween(insta, itw_path,3);
            #endregion

            //   for (int i = 0; i < EnemyTank.Length;i++ )
            {
                //for (int one = 0; one < 5;one++ )
                {
                    GameObject ins = Instantiate(EnemyTank) as GameObject;
                    // ins.transform.position = (Vector3)iTweenPath.GetPath(itw_path.pathName).GetValue(0);
                    //  Obj_itween(ins, itw_path, 3);
                    ins.transform.position = (Vector3)iTweenPath.GetPath(itw_path.pathName).GetValue(0);
                    iTween.MoveTo(ins, iTween.Hash(itw_path.name, iTweenPath.GetPath(itw_path.pathName), "time", 3f));

                }
            }
        }
    }

    void Obj_itween(GameObject obj, iTweenPath path, float iTime)
    {

        obj.transform.position = (Vector3)iTweenPath.GetPath(path.pathName).GetValue(0);
        iTween.MoveTo(obj, iTween.Hash("path", iTweenPath.GetPath(path.pathName), "time", iTime,
       "orienttopath", true, "looktime", 1f, "easetype", iTween.EaseType.easeInOutCubic, "looptype", iTween.LoopType.none));
    }
}
