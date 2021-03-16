using UnityEngine;

public class Movement : MonoBehaviour
{
    Quaternion up_downRot;
    Quaternion left_RightRot;

    float left_rightRotSpeed;
    float lookLeftMin;
    float lookRightMax;

    float rotationUp_DownSpeed;
    float lookDownMin;
    float lookUpMax;

    // unity's start function
    void Start()
    {
        left_rightRotSpeed = 2f;
        lookLeftMin = -30f;
        lookRightMax = 30f;

        rotationUp_DownSpeed = 2f;
        lookDownMin = -20f;
        lookUpMax = 25f;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // unity's update function
    void Update()
    {
        // look rotation up and down
        up_downRot.x += Input.GetAxis("Mouse Y") * rotationUp_DownSpeed * (-1);
        up_downRot.x = Mathf.Clamp(up_downRot.x, lookDownMin, lookUpMax);
        transform.localRotation = Quaternion.Euler(up_downRot.x, left_RightRot.y, up_downRot.z);

        // look rotation left and right
        left_RightRot.y += Input.GetAxis("Mouse X") * left_rightRotSpeed;
        left_RightRot.y = Mathf.Clamp(left_RightRot.y, lookLeftMin, lookRightMax);
        transform.localRotation = Quaternion.Euler(up_downRot.x, left_RightRot.y, left_RightRot.z);
    }
}
