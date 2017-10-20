using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraStyle { AlwaysFollow, InstantFlip };

public class CameraController : MonoBehaviour {

    public Transform target;

    Vector3 velocity = Vector3.zero;

    public float smoothTime = 0.15f;

    public bool YMaxEnabled = false;
    public float YMaxValue = 0;

    public bool YMinEnabled = false;
    public float YMinValue = 0;

    public bool XMaxEnabled = false;
    public float XMaxValue = 0;

    public bool XMinEnabled = false;
    public float XMinValue = 0;

    public PlayerController playerController;

    public CameraStyle style;




    // Update is called once per frame
    void FixedUpdate () {

        Vector3 targetPos = target.position;

        //vertical
        if (YMinEnabled && YMaxEnabled)
            targetPos.y = Mathf.Clamp(target.position.y, YMinValue, YMaxValue);

        else if (YMinEnabled)
            targetPos.y = Mathf.Clamp(target.position.y, YMinValue, target.position.y);

        else if (YMaxEnabled)
            targetPos.y = Mathf.Clamp(target.position.y, target.position.y,YMaxValue);

        //horizontal
        if (XMinEnabled && XMaxEnabled)
            targetPos.x = Mathf.Clamp(target.position.x, XMinValue, XMaxValue);

        else if (XMinEnabled)
            targetPos.x = Mathf.Clamp(target.position.x, XMinValue, target.position.x);

        else if (XMaxEnabled)
             targetPos.x = Mathf.Clamp(target.position.x, target.position.x, XMaxValue);

        targetPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos,ref velocity, smoothTime);

        if (style == CameraStyle.AlwaysFollow)
        {
            AlwayFollowPlayer();
        }
        else if (style == CameraStyle.AlwaysFollow)
        {
            InstantFlip();
        }

        //Debug.Log(transform.rotation.eulerAngles.z);
    }

    void InstantFlip()
    {
        //flipping camera
        float r = playerController.playerRotation;
        if (!IsBtwTwoNum(r, 358, 1) && playerController.grounded)
        {
            RotateCamera();
        }

        if (!IsBtwTwoNum(r, 89, 91) && playerController.grounded)
        {
            RotateCamera();
        }

        if (!IsBtwTwoNum(r, 179, 181) && playerController.grounded)
        {
            RotateCamera();
        }

        if (!IsBtwTwoNum(r, 269, 271) && playerController.grounded)
        {
            RotateCamera();
        }


        //0=down 90- left 180-up 270-right
        if (playerController.isDownGrounded)
            SetCameraRotation(0);

        if (playerController.isLeftGrounded)
            SetCameraRotation(90);

        if (playerController.isUpGrounded)
            SetCameraRotation(180);

        if (playerController.isRightGrounded)
            SetCameraRotation(270);
    }

    /*
      void AlwayFollowPlayer()
    {
        float r = playerController.playerRotation;
        RotateCamera();
    }
     * */
    void AlwayFollowPlayer()
    {
        float r = playerController.playerRotation;
        // && !IsBtwTwoNum(r, 88, 92) && !IsBtwTwoNum(r, 179, 181) && !IsBtwTwoNum(r, 268, 272)
        if ((r >= 354 || r <= 6 || r == 0))
        {
            SetCameraRotation(0);
        }
        else if (IsBtwTwoNum(r, 84, 96))
        {
            SetCameraRotation(90);
        }
        else if (IsBtwTwoNum(r, 174, 186))
        {
            SetCameraRotation(180);
        }
        else if (IsBtwTwoNum(r, 264, 276))
        {
            SetCameraRotation(270);
        }
        else
        {
            RotateCamera();
        }
    }

    void RotateCamera()
    {
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.z = target.rotation.eulerAngles.z;
        transform.rotation = Quaternion.Euler(rotationVector);
    }

    void SetCameraRotation(int rotationVal)
    {
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.z = rotationVal;
        transform.rotation = Quaternion.Euler(rotationVector);
    }

    bool IsBtwTwoNum(float currentNum,float a, float b)
    {
        if (currentNum >= a && currentNum <= b)
        {
            return true;
        }
        else {
            return false;
        }
    }
   
}
