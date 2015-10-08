using UnityEngine;
using System.Collections;

public class EnemyLookFirst : MonoBehaviour
{
    public GameObject First96A;
    // Use this for initialization
    void Start()
    {
        First96A = GameObject.Find("First96A/ZTZ96A_FirstCam").gameObject;
        // transform.LookAt(First96A.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(First96A.transform.position);

    }
}
