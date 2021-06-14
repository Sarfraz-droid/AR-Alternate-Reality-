using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float move_speed = 100;
    public float multiplier = 1;
    public float air_mult = 1;
    public float look_speed = 100;
    
    [SerializeField] float h_input = 0;
    [SerializeField] float v_input = 0;



    [SerializeField] float jump_speed = 100;

    public bool isGrounded = false;
    bool isded = false;
    Vector3 rb_vel;

    Quaternion look_rot;

    Rigidbody rb;

    public float mouseSensitivity = 10;
    float mouse_x = 0, mouse_y = 0;

    public UIMenuManager Manager;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Manager = GetComponentInChildren<UIMenuManager>();
        rb_vel = Vector3.zero;
        look_rot = Quaternion.identity;
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        //to hide the curser
        Cursor.visible = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGrounded)
        {
            air_mult = 1;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                multiplier = 2;
            }
            else
            {
                multiplier = 1;
            }
        }else
        {
            air_mult = 0.1f;
        }

        GetInput();
        Move();
        if (rb_vel != Vector3.zero )
        {
            if (isGrounded)
                rb.velocity = new Vector3(rb_vel.x, rb.velocity.y, rb_vel.z);
            else
                rb.AddForce(rb_vel / 50, ForceMode.VelocityChange);
        }

        if(transform.position.y < -100 && !isded)
        {
            isded = true;
            Manager.Ded();
        }
    }



    private void Update()
    {
        isGrounded = GetComponentInChildren<Player__GroundCollision>().isGrounded;
        Jump();
    }
    void GetInput()
    {
        h_input = Input.GetAxis("Horizontal") * move_speed * multiplier;
        v_input = Input.GetAxis("Vertical") * move_speed * multiplier;
    }

    void Move()
    {
        rb_vel = transform.forward*v_input + transform.right*h_input;
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jump_speed, rb.velocity.z);
        }
    }


}
