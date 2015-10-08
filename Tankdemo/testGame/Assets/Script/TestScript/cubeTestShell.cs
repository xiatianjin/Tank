using UnityEngine;
using System.Collections;

public class cubeTestShell : MonoBehaviour {
    public GameObject shell;
    public GameObject par;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown(KeyCode.J))
	{
        GameObject ins = Instantiate(shell, transform.position + new Vector3(0, 20, 0), Quaternion.identity) as GameObject;
	}
	
	}

    void OnTriggerEnter(Collider col)
    {
        print("col.name=" + col.transform.tag);
        if (col.transform.tag=="AirShell")
        {
            GameObject inAir = Instantiate(par, transform.position , Quaternion.identity) as GameObject;
        }
    }
}
