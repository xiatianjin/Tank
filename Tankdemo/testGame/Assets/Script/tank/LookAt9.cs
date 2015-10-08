using UnityEngine;
using System.Collections;

public class LookAt9 : MonoBehaviour {

    float posZ;
    float posX;
    Vector3 lastpos;
    public GameObject cube;
    bool isMove;
    float time_move;
	// Use this for initialization
	void Start () {
        lastpos = transform.position;
        isMove = false;
        time_move=0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            // posZ = Random.Range(5, 10);
            // posX = Random.Range(-30, 30); 
            //lastpos=transform.position + new Vector3(posX,0,posZ);
           isMove = true;
            PosRotate();
        }
        if (isMove)
        {
            time_move += Time.deltaTime;
           if (time_move>2)
           {
               PosRotate();
               print("0");
               time_move = 0;
           }
           
            
        } 
      

        cube.transform.rotation = Quaternion.Slerp(cube.transform.rotation, Quaternion.LookRotation(lastpos - cube.transform.position), Time.deltaTime * 1);
        transform.position = Vector3.MoveTowards(transform.position, lastpos, Time.deltaTime*2);
    
	}
    void PosRotate()
    {
        posZ = Random.Range(5, 10);
        posX = Random.Range(-5, 5);
        lastpos = transform.position + new Vector3(posX, 0, posZ);
      
    }
}
