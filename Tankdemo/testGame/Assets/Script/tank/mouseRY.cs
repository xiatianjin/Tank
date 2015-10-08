using UnityEngine;
using System.Collections;

public class mouseRY : MonoBehaviour
{

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseY;

    public float sensitivityY = 15F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    public static float rotationY = 0F;

    void Update()
    {
        if (playerPath.isTankRotate)
        {

            if (axes == RotationAxes.MouseY)
            {
                if (test_danji.pingtai == test_danji.CLIENT.WINDOWS)
                {
                    if (Input.GetMouseButton(0))
                    {
                        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
                        transform.localEulerAngles = new Vector3(-rotationY , transform.localEulerAngles.y, 0);
                        handShank.handrotationY = rotationY;
                    }
                }
                if (test_danji.pingtai == test_danji.CLIENT.ANDROID)
                {

                    if (Input.touchCount ==1 && Input.GetTouch(0).phase== TouchPhase.Moved)
                    {
                        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
                        transform.localEulerAngles = new Vector3(-rotationY , transform.localEulerAngles.y, 0);
                        handShank.handrotationY = rotationY;
                    }

                }
            }
        }
    }
    void Start()
    {
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
    }
}
