using UnityEngine;
using System.Collections;

public class DealLog : MonoBehaviour
{

    float deal_time;
    // Use this for initialization
    void Start()
    {
        deal_time = 0;
      

    }
    // Update is called once per frame
    void Update()
    {
       


        deal_time += Time.deltaTime;
        if (deal_time > 1)
        {
            Destroy(gameObject);
                    
            deal_time = 0;
            
                      
        }


    }
}
