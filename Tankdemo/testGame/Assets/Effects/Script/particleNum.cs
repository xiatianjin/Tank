using UnityEngine;
using System.Collections;

public class particleNum : MonoBehaviour
{
    public float Emission_Rate;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GetComponent<ParticleSystem>().emissionRate = Emission_Rate;
        }
        else
        {
            GetComponent<ParticleSystem>().emissionRate = 0;
        }

    }
}
