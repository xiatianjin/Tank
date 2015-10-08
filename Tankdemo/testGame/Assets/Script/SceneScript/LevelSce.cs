using UnityEngine;
using System.Collections;

public class LevelSce : MonoBehaviour {

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel(1);
            
        }
    }
}
