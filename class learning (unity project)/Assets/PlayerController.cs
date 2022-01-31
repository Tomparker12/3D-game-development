using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 3.5f;
    public float speed = 2f;
    public float jumpforce = 0.5f; // jumping force

    private CharacterController controller;
    private Vector3 motion;
    private float currentspeed = 0;
    private float velocity = 0;

    // Awake is called before the start method


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        currentspeed = speed;
    }

    private void FixedUpdate()
    {
        motion = Vector3.zero;
        bool grounded = controller.isGrounded;
        if (grounded == true)
        {
            velocity = -gravity * Time.deltaTime;
        }
        else
        {
            velocity -= gravity * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {

        float inputX = Input.GetAxisRaw("Vertical") * currentspeed;
        float inputY = Input.GetAxisRaw("Horizontal") * currentspeed;

        if (controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                velocity = jumpforce;
            }
        }
        ApplyMovement();
    }


    void ApplyMovement()
    {
        float inputX = Input.GetAxisRaw("Vertical") * currentspeed;
        float inputY = Input.GetAxisRaw("Horizontal") * currentspeed;
        motion += transform.forward * inputX * Time.deltaTime;
        motion += transform.right * inputY * Time.deltaTime;
        motion.y += velocity * Time.deltaTime;
        controller.Move(motion);

    }
}    