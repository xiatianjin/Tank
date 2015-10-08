using UnityEngine;
using System.Collections;

public class mandeal : MonoBehaviour {
    public GameObject deal;             //死亡的log
	// Use this for initialization
	void Start () {
        Instantiate(deal);
        Destroy(gameObject, 3);
	}
	
	
}
