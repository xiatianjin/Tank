using UnityEngine;
using System.Collections;

public class handShank : MonoBehaviour {
    public GameObject cube;     //炮台
    public GameObject shell;    //炮管
    public GameObject camY;     //摄像机 主
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseX;

    public float sensitivityX = 15F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public static float handrotationX = 0f;


    public float sensitivityY = 15F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    public static float handrotationY = 0F;
    // Use this for initialization
    void Start()
    {
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
       
        //if (Input.GetMouseButton(0))
        //{
        //    if (axes == RotationAxes.MouseX)
        //    {
        //        rotationX += Input.GetAxis("Mouse X") * sensitivityX;
        //        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
        //        transform.localEulerAngles = new Vector3(0, rotationX, 0);
        //    }
        //}

        //else if (axes == RotationAxes.MouseY)
        //{
        //    if (Input.GetMouseButton(0))
        //    {
        //        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        //        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        //        transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        //    }
        //}

    }

    public void BtnUp()
    {
        
        handrotationY +=  sensitivityY;
        handrotationY = Mathf.Clamp(handrotationY, minimumY, maximumY);
        shell.transform.localEulerAngles = new Vector3(-handrotationY, 0, 0);
        camY.transform.localEulerAngles = new Vector3(-handrotationY, 0, 0);
        mouseRX.rotationX = handrotationX;
        mouseRY.rotationY = handrotationY;
    }

    public void BtnDown()
    {
       
        handrotationY -=  sensitivityY;
        handrotationY = Mathf.Clamp(handrotationY, minimumY, maximumY);
        shell.transform.localEulerAngles = new Vector3(-handrotationY, 0, 0);
        camY.transform.localEulerAngles = new Vector3(-handrotationY, 0, 0);
        mouseRX.rotationX = handrotationX;
        mouseRY.rotationY = handrotationY;
    }

    public void BtnLeft()
    {
        
        handrotationX -= sensitivityX;
        handrotationX = Mathf.Clamp(handrotationX, minimumX, maximumX);
        cube.transform.localEulerAngles = new Vector3(0, handrotationX, 0);
        mouseRX.rotationX = handrotationX;
        mouseRY.rotationY = handrotationY;
    }

    public void BtnRight()
    {
        
        handrotationX += sensitivityX;
        handrotationX = Mathf.Clamp(handrotationX, minimumX, maximumX);
        cube.transform.localEulerAngles = new Vector3(0, handrotationX, 0);
        mouseRX.rotationX = handrotationX;
        mouseRY.rotationY = handrotationY;
    }

    void OnClick()
    {
        print("click="+transform.name);
        if (transform.name == "ButtonUP")
        {
            BtnUp();
        }
        else if(transform.name=="ButtonDown")
        {
            BtnDown();
        }
        else if (transform.name == "ButtonRight")
        {
            BtnRight();
        }
        else if (transform.name == "ButtonLeft")
        {
            BtnLeft();
        }
    }
}
