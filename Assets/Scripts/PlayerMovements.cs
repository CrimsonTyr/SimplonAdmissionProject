using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;

    private CharacterController controller;

    private Vector3 verticalMotion = new Vector3(0, 0, 0);
    private Vector3 zAxisMotion = new Vector3(0, 0, 0);
    private Vector3 rotation = new Vector3(0, 0, 0);

    private string action = "idle";
    private bool jump = false;
    private string lastKeyPressed = null;
    private float lastTimeKeyPressed = -1;

    private bool isGrounded;
    private float gravity = -9.81f;
    private float jumpHeight;

    private Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckGround();
        AssignDefaultZValues();
        GetRotation();
        if (isGrounded)
        {
            GetPlayerAction();
            makeAction();
        }
        Move();
    }

    private void CheckGround()
    {
        if (transform.position.y <= -4.8f)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isGrounded = Physics.CheckSphere(transform.position, 0.2f, groundMask);
        if (isGrounded && verticalMotion.y < 0)
            verticalMotion.y = -2f;
    }

    private void AssignDefaultZValues()
    {
        zAxisMotion = new Vector3(0, 0, Input.GetAxis("Vertical"));
        zAxisMotion = transform.TransformDirection(zAxisMotion);
        if (action == "walk" || action == "walkback")
            zAxisMotion *= 4;
        else if (action == "run" || action == "dashback")
            zAxisMotion *= 10;
        else
            zAxisMotion *= 0;
    }

    private void GetRotation()
    {
        rotation.y = 0;
        if (Input.GetKey("right"))
            rotation.y = 1.5f;
        else if (Input.GetKey("left"))
            rotation.y = -1.5f;
    }

    private void GetPlayerAction()
    {
        if (Input.GetKeyDown("space"))
            jump = true;
        else if (Input.GetKey("up") || Input.GetKey("down"))
        {
            CheckKeyUp();
            CheckKeyDown();
        }
        else
            action = "idle";
    }

    private void CheckKeyUp()
    {
        if (lastKeyPressed == "up" && Input.GetKeyDown("up")
            && Time.time - lastTimeKeyPressed <= 0.5f)
        {
            lastKeyPressed = null;
            lastTimeKeyPressed = -1;
            action = "run";
        }
        else if (Input.GetKeyDown("up"))
        {
            lastKeyPressed = "up";
            lastTimeKeyPressed = Time.time;
            action = "walk";
        }
    }

    private void CheckKeyDown()
    {
        if (lastKeyPressed == "down" && Input.GetKeyDown("down")
            && Time.time - lastTimeKeyPressed <= 0.5f)
        {
            lastKeyPressed = null;
            lastTimeKeyPressed = -1;
            action = "dashback";
        }
        else if (Input.GetKeyDown("down"))
        {
            lastKeyPressed = "down";
            lastTimeKeyPressed = Time.time;
            action = "walkback";
        }
    }

    private void makeAction()
    {
        if (jump == true)
            Jump();
        else if (action == "walk" || action == "walkback")
            Walk();
        else if (action == "run" || action == "dashback")
            Run();
        else
            Idle();
    }

    private void Idle()
    {
        zAxisMotion *= 0;
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Walk()
    {
        zAxisMotion *= 1;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        zAxisMotion *= 1.2f;
        anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }
    
    private void Jump()
    {
        if (action == "walk")
            jumpHeight = 2;
        else if (action == "run")
            jumpHeight = 3;
        else
            jumpHeight = 1.5f;
        verticalMotion.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        jump = false;
        if (action == "run")
            anim.SetTrigger("RunningJump");
        else
            anim.SetTrigger("Jump");
    }

    private void Move()
    {
        controller.Move(zAxisMotion * Time.deltaTime);
        verticalMotion.y += gravity * Time.deltaTime;
        controller.Move(verticalMotion * Time.deltaTime);
        transform.Rotate(rotation, Space.Self);
    }
}