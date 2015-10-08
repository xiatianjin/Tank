using UnityEngine;
using System.Collections;

public class mouseRX : MonoBehaviour
{
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseX;
    public float sensitivityX = 15F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public static float rotationX = 0f;


    // Use this for initialization
    void Start()
    {
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
       

        if (playerPath.isTankRotate)
        {

            if (test_danji.pingtai == test_danji.CLIENT.WINDOWS)
            {
                if (Input.GetMouseButton(0))
                {
                    if (axes == RotationAxes.MouseX)
                    {
                        //                  Debug.Log("Ratate.y="+(transform.localRotation.y));
                        rotationX += Input.GetAxis("Mouse X") * sensitivityX;
                        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
                        transform.localEulerAngles = new Vector3(0, rotationX, 0);
                        handShank.handrotationX = rotationX;
                    }
                }
            }
            if (test_danji.pingtai == test_danji.CLIENT.ANDROID)
            {

                if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    if (axes == RotationAxes.MouseX)
                    {
                        rotationX += Input.GetAxis("Mouse X") * sensitivityX;
                        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
                        transform.localEulerAngles = new Vector3(0, rotationX, 0);
                        handShank.handrotationX = rotationX;
                    }
                }

            }
        }
    }
}
