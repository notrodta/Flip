using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController pc;

    public float moveSpeed;
    public float jumpHeight;

    public Transform groundCheckDown, groundCheckUp, groundCheckLeft, groundCheckRight;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public float playerRotation;

    public bool grounded;
    public bool isDownGrounded,isLeftGrounded,isRightGrounded,isUpGrounded;
    public bool isJump;

    public float stopSpeed = 1;

    public Transform respwanPoint;
    public GameObject mainCamera;

    private void Start()
    {
        pc = this;
    }

    private void FixedUpdate()
    {

        //Debug.Log(Mathf.Abs((int)transform.eulerAngles.z));


        // down- left- up- right
        if (Mathf.Abs((int)transform.eulerAngles.z) >= 358 || Mathf.Abs((int)transform.eulerAngles.z) <= 1 || Mathf.Abs((int)transform.eulerAngles.z) == 0)
        {
            grounded = Physics2D.OverlapCircle(groundCheckDown.position, groundCheckRadius, whatIsGround);
            SetGroundedFalse();
            isDownGrounded = true;
            Debug.Log("ground down");
        }
        else if (Mathf.Abs((int)transform.eulerAngles.z) >= 89 && Mathf.Abs((int)transform.eulerAngles.z) <= 91)
        {
            grounded = Physics2D.OverlapCircle(groundCheckLeft.position, groundCheckRadius, whatIsGround);
            SetGroundedFalse();
            isLeftGrounded = true;
            Debug.Log("ground left");
        }
        else if (Mathf.Abs((int)transform.eulerAngles.z) >= 179 && Mathf.Abs((int)transform.eulerAngles.z) <= 181)
        {
            grounded = Physics2D.OverlapCircle(groundCheckUp.position, groundCheckRadius, whatIsGround);
            SetGroundedFalse();
            isUpGrounded = true;
            Debug.Log("ground up");
        }
        else if (Mathf.Abs((int)transform.eulerAngles.z) >= 269 && Mathf.Abs((int)transform.eulerAngles.z) <= 271)
        {
            grounded = Physics2D.OverlapCircle(groundCheckRight.position, groundCheckRadius, whatIsGround);
            SetGroundedFalse();
            isRightGrounded = true;
        }
        else {
            grounded = false;
        }

        playerRotation = Mathf.Abs((int)transform.eulerAngles.z);
    }

    void SetGroundedFalse()
    {
        isDownGrounded = false;
        isLeftGrounded = false;
        isRightGrounded = false;
        isUpGrounded = false;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
        }

        if (grounded == false)
        {
            isJump = true;
        }

        if (isJump && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            isJump = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.anyKey == false && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }


    }

    IEnumerator StopMoveCo(float speed)
    {
        while (Input.anyKey == false)
        {
            if (speed > 0)
            {
                while (speed > 0)
                {
                    Debug.Log("right");
                    speed -= Time.deltaTime * stopSpeed;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
                    yield return null;
                }
                break;
            }
            else if (speed < 0)
            {
                while (speed < 0)
                {
                    Debug.Log("left");
                    speed += Time.deltaTime * stopSpeed;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
                    yield return null;
                }
                break;
            }
        }
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    public static void Respawn()
    {
        Debug.Log("respawn");
        pc.transform.position = pc.respwanPoint.position;
        pc.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        pc.mainCamera.transform.rotation = Quaternion.Euler(new Vector3 (0,0,0));
    }


}
